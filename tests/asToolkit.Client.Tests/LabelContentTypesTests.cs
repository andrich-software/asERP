using asToolkit.Client.Features.Shippings.Services;

namespace asToolkit.Client.Tests;

public class LabelContentTypesTests
{
    [TestCase("application/pdf", ExpectedResult = ".pdf")]
    [TestCase("application/PDF", ExpectedResult = ".pdf")]
    [TestCase("image/gif", ExpectedResult = ".gif")]
    [TestCase("image/png", ExpectedResult = ".png")]
    [TestCase("application/octet-stream", ExpectedResult = ".bin")]
    [TestCase(null, ExpectedResult = ".bin")]
    public string GetExtension_MapsMimeTypes(string? contentType) =>
        LabelContentTypes.GetExtension(contentType);

    [TestCase("application/pdf", ExpectedResult = true)]
    [TestCase("image/gif", ExpectedResult = false)]
    [TestCase(null, ExpectedResult = false)]
    public bool IsPdf_DetectsPdf(string? contentType) =>
        LabelContentTypes.IsPdf(contentType);
}
