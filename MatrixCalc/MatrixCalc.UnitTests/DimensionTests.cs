namespace MatrixCalc.UnitTests;

public class DimensionTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void IncreaseDimension_DimensionMoreThanUpperBound_DoNotIncrease()
    {
        var lowerBound = 2;
        var upperBound = 7;
        var startDimension = 4;
        var dimension = new Dimension(lowerBound, upperBound, startDimension);
        var currentMatrixDimension = upperBound;

        currentMatrixDimension = dimension.IncreaseDimension(currentMatrixDimension);

        Assert.That(currentMatrixDimension, Is.EqualTo(upperBound));
    }
}