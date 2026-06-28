<?php declare(strict_types=1);

namespace Maerp\Analytics\Storefront\Controller;

use Shopware\Core\System\SalesChannel\SalesChannelContext;
use Shopware\Core\System\SystemConfig\SystemConfigService;
use Shopware\Storefront\Controller\StorefrontController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

/**
 * Same-origin collector that proxies storefront beacons to asToolkit. The secret tracking token is read from
 * the plugin config and added here — it never reaches the browser. When a customer is logged in, a
 * pseudonymised reference (cid) is computed and forwarded so asToolkit can attribute product views.
 */
#[Route(defaults: ['_routeScope' => ['storefront']])]
class CollectorController extends StorefrontController
{
    public function __construct(private readonly SystemConfigService $systemConfig)
    {
    }

    #[Route(
        path: '/astoolkit-analytics/c',
        name: 'frontend.astoolkit.collect',
        methods: ['POST'],
        defaults: ['XmlHttpRequest' => true, 'csrf_protected' => false, '_httpCache' => false]
    )]
    public function collect(Request $request, SalesChannelContext $context): Response
    {
        $serverUrl = trim((string) $this->systemConfig->get('MaerpAnalytics.config.serverUrl'));
        $token = (string) $this->systemConfig->get('MaerpAnalytics.config.trackingToken');

        // Always 204, never leak whether the plugin is configured.
        if ($serverUrl === '' || $token === '') {
            return new Response(null, Response::HTTP_NO_CONTENT);
        }
        $serverUrl = rtrim($serverUrl, '/');

        $beacon = json_decode((string) $request->getContent(), true);
        if (!is_array($beacon)) {
            return new Response(null, Response::HTTP_NO_CONTENT);
        }

        $customer = $context->getCustomer();
        if ($customer !== null) {
            $identifier = $customer->getCustomerNumber() ?: $customer->getId();
            $beacon['cid'] = $this->computeCid((string) $identifier, $token);
        } else {
            unset($beacon['cid']); // never trust a client-supplied cid
        }

        $visitorIp = $request->getClientIp() ?? '';
        $visitorUa = (string) $request->headers->get('User-Agent', '');

        $this->proxyToMaerp($serverUrl . '/api/v1/storefront/e', $token, $visitorIp, $visitorUa, $beacon);

        return new Response(null, Response::HTTP_NO_CONTENT);
    }

    /**
     * cid = HMAC-SHA256(key = SHA256(token . ":cid"), data = customer identifier). A token-derived sub-key
     * keeps the HMAC key distinct from the bearer token while needing only one configured secret.
     */
    private function computeCid(string $customerNumber, string $token): string
    {
        $key = hash('sha256', $token . ':cid', true); // raw 32 bytes
        return hash_hmac('sha256', $customerNumber, $key); // hex
    }

    /**
     * Fire-and-forget forward to asToolkit with a tight timeout, so the beacon response is never blocked on
     * the upstream call.
     */
    private function proxyToMaerp(string $endpoint, string $token, string $ip, string $ua, array $beacon): void
    {
        $payload = json_encode($beacon);
        if ($payload === false) {
            return;
        }

        $ch = curl_init($endpoint);
        if ($ch === false) {
            return;
        }

        curl_setopt_array($ch, [
            CURLOPT_POST           => true,
            CURLOPT_POSTFIELDS     => $payload,
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_TIMEOUT        => 2,
            CURLOPT_CONNECTTIMEOUT => 1,
            CURLOPT_HTTPHEADER     => [
                'Content-Type: application/json',
                'X-Storefront-Token: ' . $token,
                'X-Forwarded-For: ' . $ip,
                'User-Agent: ' . $ua,
            ],
        ]);

        curl_exec($ch);
        curl_close($ch);
    }
}
