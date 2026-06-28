<?php
/**
 * Plugin Name:       asToolkit Web Analytics
 * Plugin URI:        https://www.astoolkit.de/
 * Description:        First-party, privacy-friendly web analytics for your WooCommerce store, reporting
 *                     into your asToolkit server. The tracking token never reaches the browser — beacons are
 *                     proxied server-side. No cookies, IPs are masked server-side.
 * Version:           1.0.0
 * Author:            Martin Andrich Softwareentwicklung
 * License:           GPL-2.0-or-later
 * Requires PHP:      7.4
 * Text Domain:       astoolkit-analytics
 *
 * Security model:
 *  - The browser only ever talks to THIS shop (same-origin REST route). The secret token is added here,
 *    server-side, and forwarded to asToolkit — it is never exposed in page source or network traffic.
 *  - When a customer is logged in, a pseudonymised reference (cid = HMAC of the customer id, keyed by a
 *    value derived from the token) is computed here and forwarded, so asToolkit can attribute product views
 *    to a known customer without ever receiving the raw customer number in the browser.
 */

if (!defined('ABSPATH')) {
    exit; // No direct access.
}

final class MaERP_Analytics
{
    const OPT_SERVER_URL = 'astoolkit_analytics_server_url';
    const OPT_TOKEN      = 'astoolkit_analytics_token';

    const REST_NAMESPACE = 'astoolkit/v1';
    const REST_ROUTE     = '/c'; // first-party collector: /wp-json/astoolkit/v1/c

    public static function init()
    {
        add_action('admin_menu', [__CLASS__, 'register_settings_page']);
        add_action('admin_init', [__CLASS__, 'register_settings']);
        add_action('rest_api_init', [__CLASS__, 'register_rest_route']);
        add_action('wp_enqueue_scripts', [__CLASS__, 'enqueue_tracker']);
    }

    // -------------------------------------------------------------------------
    // Settings page
    // -------------------------------------------------------------------------

    public static function register_settings_page()
    {
        add_options_page(
            __('asToolkit Web Analytics', 'astoolkit-analytics'),
            __('asToolkit Analytics', 'astoolkit-analytics'),
            'manage_options',
            'astoolkit-analytics',
            [__CLASS__, 'render_settings_page']
        );
    }

    public static function register_settings()
    {
        register_setting('astoolkit_analytics', self::OPT_SERVER_URL, [
            'type'              => 'string',
            'sanitize_callback' => [__CLASS__, 'sanitize_url'],
            'default'           => '',
        ]);
        register_setting('astoolkit_analytics', self::OPT_TOKEN, [
            'type'              => 'string',
            'sanitize_callback' => 'sanitize_text_field',
            'default'           => '',
        ]);
    }

    public static function sanitize_url($value)
    {
        $value = trim((string) $value);
        return rtrim(esc_url_raw($value), '/');
    }

    public static function render_settings_page()
    {
        if (!current_user_can('manage_options')) {
            return;
        }
        ?>
        <div class="wrap">
            <h1><?php esc_html_e('asToolkit Web Analytics', 'astoolkit-analytics'); ?></h1>
            <p><?php esc_html_e('Connect this store to your asToolkit server. Generate a tracking token in asToolkit (Sales channel → Web analytics) and paste it here.', 'astoolkit-analytics'); ?></p>
            <form action="options.php" method="post">
                <?php settings_fields('astoolkit_analytics'); ?>
                <table class="form-table" role="presentation">
                    <tr>
                        <th scope="row"><label for="astoolkit_url"><?php esc_html_e('asToolkit Server URL', 'astoolkit-analytics'); ?></label></th>
                        <td>
                            <input name="<?php echo esc_attr(self::OPT_SERVER_URL); ?>" id="astoolkit_url" type="url"
                                   class="regular-text" placeholder="https://erp.example.com"
                                   value="<?php echo esc_attr(get_option(self::OPT_SERVER_URL, '')); ?>" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row"><label for="astoolkit_token"><?php esc_html_e('Tracking Token', 'astoolkit-analytics'); ?></label></th>
                        <td>
                            <input name="<?php echo esc_attr(self::OPT_TOKEN); ?>" id="astoolkit_token" type="password"
                                   class="regular-text" autocomplete="off"
                                   value="<?php echo esc_attr(get_option(self::OPT_TOKEN, '')); ?>" />
                            <p class="description"><?php esc_html_e('Stored on the server only — never sent to the browser.', 'astoolkit-analytics'); ?></p>
                        </td>
                    </tr>
                </table>
                <?php submit_button(); ?>
            </form>
        </div>
        <?php
    }

    private static function is_configured()
    {
        return get_option(self::OPT_SERVER_URL, '') !== '' && get_option(self::OPT_TOKEN, '') !== '';
    }

    // -------------------------------------------------------------------------
    // Front-end tracker injection
    // -------------------------------------------------------------------------

    public static function enqueue_tracker()
    {
        if (is_admin() || !self::is_configured()) {
            return;
        }

        $version = '1.0.0';
        $core_url = plugins_url('assets/astoolkit-s.js', __FILE__);
        $glue_url = plugins_url('assets/astoolkit-wc.js', __FILE__);

        wp_register_script('astoolkit-analytics-core', $core_url, [], $version, true);
        wp_register_script('astoolkit-analytics-wc', $glue_url, ['astoolkit-analytics-core', 'jquery'], $version, true);

        $config = [
            'endpoint' => esc_url_raw(rest_url(self::REST_NAMESPACE . self::REST_ROUTE)),
        ];

        // Product context on single-product pages → emitted as a ProductView.
        if (function_exists('is_product') && is_product()) {
            global $product;
            if (!$product && function_exists('wc_get_product')) {
                $product = wc_get_product(get_the_ID());
            }
            if ($product) {
                $config['product'] = [
                    'ref'      => (string) $product->get_id(),
                    'name'     => $product->get_name(),
                    'value'    => (float) $product->get_price(),
                    'currency' => get_woocommerce_currency(),
                ];
            }
        }

        wp_localize_script('astoolkit-analytics-core', 'astoolkitTrackConfig', $config);
        wp_enqueue_script('astoolkit-analytics-core');
        wp_enqueue_script('astoolkit-analytics-wc');
    }

    // -------------------------------------------------------------------------
    // Same-origin collector → server-side proxy to asToolkit
    // -------------------------------------------------------------------------

    public static function register_rest_route()
    {
        register_rest_route(self::REST_NAMESPACE, self::REST_ROUTE, [
            'methods'             => 'POST',
            'callback'            => [__CLASS__, 'handle_beacon'],
            'permission_callback' => '__return_true', // public: anonymous visitors send beacons
        ]);
    }

    public static function handle_beacon(WP_REST_Request $request)
    {
        // Always answer 204 quickly and never leak configuration state.
        if (!self::is_configured()) {
            return new WP_REST_Response(null, 204);
        }

        $beacon = $request->get_json_params();
        if (!is_array($beacon)) {
            return new WP_REST_Response(null, 204);
        }

        $server_url = get_option(self::OPT_SERVER_URL, '');
        $token      = get_option(self::OPT_TOKEN, '');

        // Attach pseudonymised customer reference when a customer is logged in.
        $user_id = get_current_user_id();
        if ($user_id > 0) {
            $beacon['cid'] = self::compute_cid((string) $user_id, $token);
        } else {
            unset($beacon['cid']); // never trust a client-supplied cid
        }

        $visitor_ip = self::visitor_ip();
        $visitor_ua = isset($_SERVER['HTTP_USER_AGENT']) ? (string) $_SERVER['HTTP_USER_AGENT'] : '';

        $endpoint = $server_url . '/api/v1/storefront/e';

        // Fire-and-forget: don't block the beacon response on the upstream call.
        wp_remote_post($endpoint, [
            'timeout'  => 2,
            'blocking' => false,
            'headers'  => [
                'Content-Type'        => 'application/json',
                'X-Storefront-Token'  => $token,
                'X-Forwarded-For'     => $visitor_ip,
                'User-Agent'          => $visitor_ua,
            ],
            'body'     => wp_json_encode($beacon),
        ]);

        return new WP_REST_Response(null, 204);
    }

    /**
     * cid = HMAC-SHA256(key = SHA256(token . ":cid"), data = customer id). A token-derived sub-key keeps
     * the HMAC key separate from the bearer token while needing only one configured secret.
     */
    private static function compute_cid($customer_number, $token)
    {
        $key = hash('sha256', $token . ':cid', true); // raw 32 bytes
        return hash_hmac('sha256', $customer_number, $key); // hex
    }

    private static function visitor_ip()
    {
        // The shop server is the immediate peer; REMOTE_ADDR is the real visitor unless behind a proxy.
        // If the store itself sits behind a trusted proxy, prefer the left-most X-Forwarded-For hop.
        if (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
            $parts = explode(',', (string) $_SERVER['HTTP_X_FORWARDED_FOR']);
            return trim($parts[0]);
        }
        return isset($_SERVER['REMOTE_ADDR']) ? (string) $_SERVER['REMOTE_ADDR'] : '';
    }
}

MaERP_Analytics::init();
