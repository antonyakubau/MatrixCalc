namespace MatrixCalc.UnitTests;

public class InputEntryTests
{
    [SetUp]
    public void Setup()
    {
        Xamarin.Forms.Mocks.MockForms.Init();
    }

    [Test]
    public void RestoreNumber_NullText_TextIsLastNumberWhenUnfocused()
    {
        var inputEntry = new InputEntry(0, 0);
        var lastNumber = inputEntry.Text;

        inputEntry.Focus();
        if (inputEntry.IsFocused)
        {
            inputEntry.Text = "";
        }
        else
            throw new Exception();
        inputEntry.Unfocus();

        Assert.That(inputEntry.Text, Is.EqualTo(lastNumber));
    }
}