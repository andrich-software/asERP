# MSIX logo assets

Pre-rendered PNG assets for the MSIX package, copied by
`.github/workflows/aserp-desktop-setup-release.yml` into the package's
`Assets/` folder.

| File | Size | Source |
|---|---|---|
| `StoreLogo.png` | 50x50 | `src/asERP.Client/Assets/Icons/icon.svg`, full-bleed on navy `#131D33` |
| `Square150x150Logo.png` | 150x150 | `src/asERP.Client/Assets/Icons/icon.svg`, full-bleed on navy `#131D33` |
| `Square44x44Logo.png` | 44x44 | `src/asERP.Client/Assets/Icons/icon.svg`, rounded corners, transparent background |
| `Wide310x150Logo.png` | 310x150 | `src/asERP.Client/Assets/Logo/logo_horizontal_dark.svg` centered at 70% width on navy `#131D33` |

To regenerate after a logo change, rasterize the SVGs with any SVG renderer
(e.g. a small Svg.Skia console app, Inkscape, or ImageMagick) at the sizes
above and overwrite the PNGs here.
