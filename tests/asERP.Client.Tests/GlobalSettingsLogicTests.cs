using asERP.Client.Features.GlobalSettings.Models;
using asERP.Domain.Dtos.GlobalSettings;
using Tab = asERP.Client.Features.GlobalSettings.Models.GlobalSettingsLogic.Tab;

namespace asERP.Client.Tests;

/// <summary>
/// Verifies the grouping and save-payload rules behind the Superadmin GlobalSettingsPage:
/// key-prefix → tab mapping, group ordering, and the write-only secret semantics of the
/// bulk update payload.
/// </summary>
public class GlobalSettingsLogicTests
{
    [TestCase("Email.SmtpHost", "Email")]
    [TestCase("System.Language.Default", "System")]
    [TestCase("NoPrefix", "NoPrefix")]
    [TestCase(".LeadingDot", ".LeadingDot")]
    public void GroupPrefix_TakesTextBeforeFirstDot(string key, string expected)
    {
        Assert.That(GlobalSettingsLogic.GroupPrefix(key), Is.EqualTo(expected));
    }

    [TestCase("Email", Tab.Email)]
    [TestCase("email", Tab.Email)]
    [TestCase("Jwt", Tab.Authentication)]
    [TestCase("Telemetry", Tab.Observability)]
    [TestCase("Grafana", Tab.Observability)]
    [TestCase("ClickHouse", Tab.Observability)]
    [TestCase("Company", Tab.General)]
    [TestCase("SomethingNew", Tab.General)]
    public void ResolveTab_MapsKnownPrefixes_UnknownGoToGeneral(string prefix, Tab expected)
    {
        Assert.That(GlobalSettingsLogic.ResolveTab(prefix), Is.EqualTo(expected));
    }

    [Test]
    public void GeneralOrderIndex_UnknownPrefixes_SortAfterKnownOnes()
    {
        Assert.That(GlobalSettingsLogic.GeneralOrderIndex("Company"),
            Is.LessThan(GlobalSettingsLogic.GeneralOrderIndex("System")));
        Assert.That(GlobalSettingsLogic.GeneralOrderIndex("Notification"),
            Is.LessThan(GlobalSettingsLogic.GeneralOrderIndex("Zebra")));
        Assert.That(GlobalSettingsLogic.GeneralOrderIndex("company"),
            Is.EqualTo(GlobalSettingsLogic.GeneralOrderIndex("Company")));
    }

    [Test]
    public void BuildTabGroups_SplitsSettingsAcrossTabs()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
        [
            Setting("Email.SmtpHost", "smtp"),
            Setting("Jwt.Issuer", "asERP"),
            Setting("Grafana.Url", "https://grafana"),
            Setting("Company.Name", "ACME"),
        ], prefix => prefix);

        Assert.That(tabs[Tab.General].Select(g => g.Title), Is.EqualTo(new[] { "Company" }));
        Assert.That(tabs[Tab.Email].Select(g => g.Title), Is.EqualTo(new[] { "Email" }));
        Assert.That(tabs[Tab.Authentication].Select(g => g.Title), Is.EqualTo(new[] { "Jwt" }));
        Assert.That(tabs[Tab.Observability].Select(g => g.Title), Is.EqualTo(new[] { "Grafana" }));
    }

    [Test]
    public void BuildTabGroups_GeneralTab_UsesFixedOrderThenAlphabetical()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
        [
            Setting("Zebra.Key", "z"),
            Setting("Invoice.Prefix", "INV"),
            Setting("Aardvark.Key", "a"),
            Setting("Company.Name", "ACME"),
        ], prefix => prefix);

        Assert.That(tabs[Tab.General].Select(g => g.Title),
            Is.EqualTo(new[] { "Company", "Invoice", "Aardvark", "Zebra" }));
    }

    [Test]
    public void BuildTabGroups_EntriesWithinGroup_AreSortedByKey()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
        [
            Setting("Email.SmtpPort", "587"),
            Setting("Email.FromAddress", "noreply@example.org"),
            Setting("Email.SmtpHost", "smtp"),
        ], prefix => prefix);

        Assert.That(tabs[Tab.Email].Single().Entries.Select(e => e.Key),
            Is.EqualTo(new[] { "Email.FromAddress", "Email.SmtpHost", "Email.SmtpPort" }));
    }

    [Test]
    public void BuildTabGroups_MixedCasePrefixes_LandInOneGroup()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
        [
            Setting("Email.SmtpHost", "smtp"),
            Setting("EMAIL.SmtpPort", "587"),
        ], prefix => prefix);

        Assert.That(tabs[Tab.Email], Has.Count.EqualTo(1));
        Assert.That(tabs[Tab.Email].Single().Entries, Has.Count.EqualTo(2));
    }

    [Test]
    public void BuildTabGroups_AppliesTitleResolver()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
            [Setting("Email.SmtpHost", "smtp")],
            prefix => $"Localized {prefix}");

        Assert.That(tabs[Tab.Email].Single().Title, Is.EqualTo("Localized Email"));
    }

    [Test]
    public void BuildTabGroups_SecretFlagAndStoredHint_ArePassedThrough()
    {
        var tabs = GlobalSettingsLogic.BuildTabGroups(
            [Setting("Email.SmtpPassword", "", isSecret: true, hasValue: true)],
            prefix => prefix);

        var entry = tabs[Tab.Email].Single().Entries.Single();
        Assert.That(entry.IsSecret, Is.True);
        Assert.That(entry.ShowSecretHint, Is.True);
    }

    [Test]
    public void BuildUpdateInput_EmptySecret_IsNotSent()
    {
        var groups = Group(
            new GlobalSettingEntry("Email.SmtpPassword", "", isSecret: true, hasStoredValue: true),
            new GlobalSettingEntry("Email.SmtpHost", "smtp", isSecret: false, hasStoredValue: true));

        var input = GlobalSettingsLogic.BuildUpdateInput(groups);

        Assert.That(input.Settings.Select(s => s.Key), Is.EqualTo(new[] { "Email.SmtpHost" }));
    }

    [Test]
    public void BuildUpdateInput_FilledSecret_IsSentToRotate()
    {
        var groups = Group(new GlobalSettingEntry("Email.SmtpPassword", "new-secret", isSecret: true, hasStoredValue: true));

        var input = GlobalSettingsLogic.BuildUpdateInput(groups);

        Assert.That(input.Settings.Single().Key, Is.EqualTo("Email.SmtpPassword"));
        Assert.That(input.Settings.Single().Value, Is.EqualTo("new-secret"));
    }

    [Test]
    public void BuildUpdateInput_EmptyNonSecret_IsSent()
    {
        var groups = Group(new GlobalSettingEntry("Company.Slogan", "", isSecret: false, hasStoredValue: true));

        var input = GlobalSettingsLogic.BuildUpdateInput(groups);

        Assert.That(input.Settings.Single().Value, Is.Empty);
    }

    [Test]
    public void BuildUpdateInput_CollectsEntriesAcrossAllGroups()
    {
        var groups = new[]
        {
            new GlobalSettingGroup("A", [new GlobalSettingEntry("Company.Name", "ACME", false, true)]),
            new GlobalSettingGroup("B", [new GlobalSettingEntry("Email.SmtpHost", "smtp", false, true)]),
        };

        var input = GlobalSettingsLogic.BuildUpdateInput(groups);

        Assert.That(input.Settings.Select(s => s.Key),
            Is.EquivalentTo(new[] { "Company.Name", "Email.SmtpHost" }));
    }

    private static GlobalSettingDto Setting(string key, string value, bool isSecret = false, bool hasValue = true) =>
        new() { Key = key, Value = value, IsSecret = isSecret, HasValue = hasValue };

    private static GlobalSettingGroup[] Group(params GlobalSettingEntry[] entries) =>
        [new GlobalSettingGroup("Group", entries)];
}
