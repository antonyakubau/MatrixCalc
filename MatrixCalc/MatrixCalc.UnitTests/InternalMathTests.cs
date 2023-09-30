namespace MatrixCalc.UnitTests;

public class InternalMathTests
{
    [SetUp]
    public void Setup()
    {
        Xamarin.Forms.Mocks.MockForms.Init();
    }

    [Test]
    public void CalculateMin_ListOfEntriesWithText_MinValueFound()
    {
        var internalMath = new InternalMath();
        var EntryList = new List<InputEntry>()
        {
            new InputEntry() {Text = "8"},
            new InputEntry() {Text = "19"},
            new InputEntry() {Text = "2"},
            new InputEntry() {Text = "742"},
            new InputEntry() {Text = "954"},
            new InputEntry() {Text = "345"},
            new InputEntry() {Text = "99"}
        };
        var Min = internalMath.CalculateMin(EntryList);
        Assert.That(Min, Is.EqualTo(2));
    }
}
