namespace MatrixCalc.UnitTests;

public class InternalMathTests
{
    InternalMath _internalMath;
    List<InputEntry> _entryList;

    [SetUp]
    public void Setup()
    {
        Xamarin.Forms.Mocks.MockForms.Init();
        _internalMath = new InternalMath();
        _entryList = new List<InputEntry>()
        {
            new InputEntry() {Text = "1"},
            new InputEntry() {Text = "99"},
            new InputEntry() {Text = "800"},
            new InputEntry() {Text = "200"},
            new InputEntry() {Text = "100"}
        };
    }

    [Test]
    public void CalculateMin_ListOfEntriesWithText_MinValueFound()
    {
        var minValue = _internalMath.CalculateMin(_entryList);

        Assert.That(minValue, Is.EqualTo(1));
    }

    [Test]
    public void CalculateMax_ListOfEntriesWithText_MaxValueFound()
    {
        var maxValue = _internalMath.CalculateMax(_entryList);

        Assert.That(maxValue, Is.EqualTo(800));
    }

    [Test]
    public void CalculateAverage_ListOfEntriesWithText_AverageValueFound()
    {
        var averageValue = _internalMath.CalculateAverage(_entryList);

        Assert.That(averageValue, Is.EqualTo(240));
    }

    [Test]
    public void CalculateSum_ListOfEntriesWithText_SumValueFound()
    {
        var sumValue = _internalMath.CalculateSum(_entryList);

        Assert.That(sumValue, Is.EqualTo(1200));
    }
}
