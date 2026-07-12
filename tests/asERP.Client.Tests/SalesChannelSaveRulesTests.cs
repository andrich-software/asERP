using asERP.Client.Features.SalesChannels.Models;
using asERP.Domain.Enums;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="SalesChannelEditModel.CanSaveCore"/> — the per-SalesChannelType
/// required-field matrix behind the edit page's Save button — and the DB-port rule it uses.
/// Create mode requires the secret; edit mode keeps the stored secret when the field stays
/// empty (the API never returns it to the client).
/// </summary>
public class SalesChannelSaveRulesTests
{
    /// <summary>Fully valid baseline; individual cases blank out what they test.</summary>
    private static bool CanSave(
        SalesChannelType type,
        bool isEditMode = false,
        string name = "Channel",
        string url = "https://shop.example.org",
        string username = "user",
        string password = "secret",
        string dbHost = "db.example.org",
        string dbName = "wordpress",
        string dbPort = "3306",
        bool hasSelectedWarehouse = true) =>
        SalesChannelEditModel.CanSaveCore(
            type, isEditMode, name, url, username, password, dbHost, dbName, dbPort, hasSelectedWarehouse);

    [TestCase(SalesChannelType.PointOfSale)]
    [TestCase(SalesChannelType.Shopware6)]
    [TestCase(SalesChannelType.WooCommerce)]
    [TestCase(SalesChannelType.WooCommerceDatabase)]
    [TestCase(SalesChannelType.eBay)]
    [TestCase(SalesChannelType.Amazon)]
    public void EveryType_RequiresNameAndWarehouse(SalesChannelType type)
    {
        Assert.Multiple(() =>
        {
            Assert.That(CanSave(type), Is.True, "valid baseline should be savable");
            Assert.That(CanSave(type, name: ""), Is.False, "missing name");
            Assert.That(CanSave(type, name: "   "), Is.False, "whitespace name");
            Assert.That(CanSave(type, hasSelectedWarehouse: false), Is.False, "no warehouse selected");
        });
    }

    [TestCase(SalesChannelType.PointOfSale)]
    [TestCase(SalesChannelType.eBay)]
    [TestCase(SalesChannelType.Amazon)]
    public void PosAndOAuthTypes_NeedNoUrlOrCredentials(SalesChannelType type)
    {
        Assert.That(CanSave(type, url: "", username: "", password: "", dbHost: "", dbName: ""), Is.True);
    }

    [TestCase(SalesChannelType.Shopware6)]
    [TestCase(SalesChannelType.WooCommerce)]
    public void CredentialTypes_RequireUrlUsernameAndPasswordOnCreate(SalesChannelType type)
    {
        Assert.Multiple(() =>
        {
            Assert.That(CanSave(type, url: ""), Is.False, "missing URL");
            Assert.That(CanSave(type, username: ""), Is.False, "missing username");
            Assert.That(CanSave(type, password: ""), Is.False, "missing password on create");
            Assert.That(CanSave(type, isEditMode: true, password: ""), Is.True,
                "empty password on edit keeps the stored secret");
        });
    }

    [Test]
    public void WooCommerceDatabase_AdditionallyRequiresDbHostAndDbName()
    {
        const SalesChannelType type = SalesChannelType.WooCommerceDatabase;
        Assert.Multiple(() =>
        {
            Assert.That(CanSave(type, url: ""), Is.False, "URL stays required (image downloads)");
            Assert.That(CanSave(type, username: ""), Is.False, "missing DB user");
            Assert.That(CanSave(type, dbHost: ""), Is.False, "missing DB host");
            Assert.That(CanSave(type, dbName: ""), Is.False, "missing DB name");
            Assert.That(CanSave(type, dbPort: "70000"), Is.False, "invalid DB port");
            Assert.That(CanSave(type, dbPort: ""), Is.True, "empty port falls back to 3306");
            Assert.That(CanSave(type, password: ""), Is.False, "missing DB password on create");
            Assert.That(CanSave(type, isEditMode: true, password: ""), Is.True,
                "empty DB password on edit keeps the stored secret");
        });
    }

    [TestCase("", ExpectedResult = true)]
    [TestCase("   ", ExpectedResult = true)]
    [TestCase("1", ExpectedResult = true)]
    [TestCase("3306", ExpectedResult = true)]
    [TestCase("65535", ExpectedResult = true)]
    [TestCase("0", ExpectedResult = false)]
    [TestCase("-1", ExpectedResult = false)]
    [TestCase("65536", ExpectedResult = false)]
    [TestCase("abc", ExpectedResult = false)]
    [TestCase("33.06", ExpectedResult = false)]
    public bool IsDbPortValid_AllowsEmptyOrTcpPortRange(string port) =>
        SalesChannelEditModel.IsDbPortValid(port);
}
