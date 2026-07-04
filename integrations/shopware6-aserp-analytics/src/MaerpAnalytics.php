<?php declare(strict_types=1);

namespace Maerp\Analytics;

use Shopware\Core\Framework\Plugin;

/**
 * asERP Web Analytics plugin for Shopware 6.
 *
 * Injects a small first-party tracker into the storefront and exposes a same-origin collector route that
 * proxies beacons to the configured asERP server. The secret tracking token is added server-side here and
 * never reaches the browser.
 */
class MaerpAnalytics extends Plugin
{
}
