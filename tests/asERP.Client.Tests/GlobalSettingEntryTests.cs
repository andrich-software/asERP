using asERP.Client.Features.GlobalSettings.Models;

namespace asERP.Client.Tests;

/// <summary>
/// Verifies the row model behind the GlobalSettingsPage: label derivation from the key,
/// input-kind detection (secret / toggle / plain text) and the write-only secret hint.
/// </summary>
public class GlobalSettingEntryTests
{
    [TestCase("Email.SmtpHost", "SmtpHost")]
    [TestCase("Company.Name", "Name")]
    [TestCase("System.Language.Default", "Language.Default")]
    [TestCase("NoPrefix", "NoPrefix")]
    [TestCase(".LeadingDot", ".LeadingDot")]
    public void Label_IsKeySuffixAfterGroupPrefix(string key, string expectedLabel)
    {
        var entry = new GlobalSettingEntry(key, "value", isSecret: false, hasStoredValue: true);

        Assert.That(entry.Label, Is.EqualTo(expectedLabel));
    }

    [TestCase("True")]
    [TestCase("False")]
    [TestCase("true")]
    [TestCase("false")]
    public void BooleanValue_RendersAsToggle(string value)
    {
        var entry = new GlobalSettingEntry("System.Flag", value, isSecret: false, hasStoredValue: true);

        Assert.That(entry.IsBoolean, Is.True);
        Assert.That(entry.IsPlainText, Is.False);
    }

    [TestCase("")]
    [TestCase("yes")]
    [TestCase("smtp.example.org")]
    [TestCase("0")]
    public void NonBooleanValue_RendersAsPlainText(string value)
    {
        var entry = new GlobalSettingEntry("Email.SmtpHost", value, isSecret: false, hasStoredValue: true);

        Assert.That(entry.IsBoolean, Is.False);
        Assert.That(entry.IsPlainText, Is.True);
    }

    [Test]
    public void SecretEntry_IsNeverBooleanOrPlainText()
    {
        var entry = new GlobalSettingEntry("Email.SmtpPassword", "True", isSecret: true, hasStoredValue: true);

        Assert.That(entry.IsBoolean, Is.False);
        Assert.That(entry.IsPlainText, Is.False);
    }

    [Test]
    public void IsBoolean_IsDetectedOnce_LaterBooleanValueDoesNotLockTheRow()
    {
        var entry = new GlobalSettingEntry("Email.SmtpHost", "smtp.example.org", isSecret: false, hasStoredValue: true);

        entry.Value = "True";

        Assert.That(entry.IsBoolean, Is.False);
        Assert.That(entry.IsPlainText, Is.True);
    }

    [TestCase(true, true, true)]
    [TestCase(true, false, false)]
    [TestCase(false, true, false)]
    [TestCase(false, false, false)]
    public void ShowSecretHint_OnlyForSecretsWithStoredValue(bool isSecret, bool hasStoredValue, bool expected)
    {
        var entry = new GlobalSettingEntry("Email.SmtpPassword", string.Empty, isSecret, hasStoredValue);

        Assert.That(entry.ShowSecretHint, Is.EqualTo(expected));
    }

    [Test]
    public void BoolValue_WritesCanonicalStrings()
    {
        var entry = new GlobalSettingEntry("System.Flag", "false", isSecret: false, hasStoredValue: true);

        entry.BoolValue = true;
        Assert.That(entry.Value, Is.EqualTo("True"));

        entry.BoolValue = false;
        Assert.That(entry.Value, Is.EqualTo("False"));
    }

    [TestCase("True", true)]
    [TestCase("true", true)]
    [TestCase("False", false)]
    [TestCase("garbage", false)]
    [TestCase("", false)]
    public void BoolValue_ParsesStoredString(string value, bool expected)
    {
        var entry = new GlobalSettingEntry("System.Flag", value, isSecret: false, hasStoredValue: true);

        Assert.That(entry.BoolValue, Is.EqualTo(expected));
    }

    [Test]
    public void ValueChange_RaisesValueAndBoolValue()
    {
        var entry = new GlobalSettingEntry("System.Flag", "False", isSecret: false, hasStoredValue: true);
        var raised = new List<string?>();
        entry.PropertyChanged += (_, e) => raised.Add(e.PropertyName);

        entry.Value = "True";

        Assert.That(raised, Is.EquivalentTo(new[] { nameof(entry.Value), nameof(entry.BoolValue) }));
    }

    [Test]
    public void UnchangedValue_RaisesNothing()
    {
        var entry = new GlobalSettingEntry("System.Flag", "True", isSecret: false, hasStoredValue: true);
        var raised = 0;
        entry.PropertyChanged += (_, _) => raised++;

        entry.Value = "True";

        Assert.That(raised, Is.Zero);
    }
}
