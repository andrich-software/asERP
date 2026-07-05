using asERP.Client.Features.Auth.Services;

namespace asERP.Client.Tests;

public class ServerUrlUtilTests
{
    [TestCase("erp.example.org", "https://erp.example.org")]
    [TestCase("  erp.example.org  ", "https://erp.example.org")]
    [TestCase("erp.example.org/", "https://erp.example.org")]
    [TestCase("https://erp.example.org", "https://erp.example.org")]
    [TestCase("HTTPS://erp.example.org/", "HTTPS://erp.example.org")]
    [TestCase("http://localhost:5000/", "http://localhost:5000")]
    [TestCase("erp.example.org/api/", "https://erp.example.org/api")]
    public void Normalize_AddsSchemeAndTrimsTrailingSlash(string input, string expected)
    {
        Assert.That(ServerUrlUtil.Normalize(input), Is.EqualTo(expected));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Normalize_EmptyInput_ReturnsEmpty(string? input)
    {
        Assert.That(ServerUrlUtil.Normalize(input), Is.Empty);
    }

    [TestCase("erp.example.org", ExpectedResult = true)]
    [TestCase("https://erp.example.org", ExpectedResult = true)]
    [TestCase("http://localhost:5000", ExpectedResult = true)]
    [TestCase(null, ExpectedResult = false)]
    [TestCase("", ExpectedResult = false)]
    [TestCase("   ", ExpectedResult = false)]
    [TestCase("https://", ExpectedResult = false)]
    [TestCase("not a url", ExpectedResult = false)]
    public bool IsValid_RequiresAbsoluteHttpUriWithHost(string? input) =>
        ServerUrlUtil.IsValid(input);
}
