// Label handling for the WASM head (invoked via [JSImport] from LabelService.wasm.cs).
// download: Blob + <a download> click. print: hidden iframe + contentWindow.print()
// so the browser's print dialog (incl. printer selection) takes over.
globalThis.asERPLabels = {
    _toBlobUrl: function (contentType, base64) {
        const binary = atob(base64);
        const bytes = new Uint8Array(binary.length);
        for (let i = 0; i < binary.length; i++) {
            bytes[i] = binary.charCodeAt(i);
        }
        return URL.createObjectURL(new Blob([bytes], { type: contentType }));
    },

    download: function (fileName, contentType, base64) {
        const url = this._toBlobUrl(contentType, base64);
        const anchor = document.createElement("a");
        anchor.href = url;
        anchor.download = fileName;
        document.body.appendChild(anchor);
        anchor.click();
        anchor.remove();
        // Give the browser time to start the download before the URL is revoked.
        setTimeout(() => URL.revokeObjectURL(url), 60000);
    },

    print: function (contentType, base64) {
        const url = this._toBlobUrl(contentType, base64);
        try {
            const iframe = document.createElement("iframe");
            iframe.style.display = "none";
            iframe.src = url;
            iframe.onload = function () {
                try {
                    iframe.contentWindow.focus();
                    iframe.contentWindow.print();
                } catch (e) {
                    console.warn("asERPLabels.print: iframe print failed, opening tab", e);
                    window.open(url, "_blank");
                }
            };
            document.body.appendChild(iframe);
            // Generous delay: the frame must stay alive while the print dialog is open.
            setTimeout(() => { iframe.remove(); URL.revokeObjectURL(url); }, 300000);
        } catch (e) {
            console.warn("asERPLabels.print: falling back to window.open", e);
            window.open(url, "_blank");
            setTimeout(() => URL.revokeObjectURL(url), 300000);
        }
    }
};
