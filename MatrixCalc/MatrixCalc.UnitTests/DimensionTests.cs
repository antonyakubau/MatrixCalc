namespace MatrixCalc.UnitTests;

public class DimensionTests
{
    Dimension _dimension;
    [SetUp]
    public void Setup()
    {
        var lowerBound = 2;
        var upperBound = 7;
        var startDimension = 4;
        _dimension = new Dimension(lowerBound, upperBound, startDimension);
    }

    [Test]
    public void IncreaseDimension_DimensionMoreThanUpperBound_DoNotIncrease()
    {
        var currentMatrixDimension = _dimension.UpperBound;

        currentMatrixDimension = _dimension.IncreaseDimension(currentMatrixDimension);

        Assert.That(currentMatrixDimension, Is.EqualTo(_dimension.UpperBound));
    }

    [Test]
    public void DecreaseDimension_DimensionLessThanLowerBound_DoNotDecrease()
    {
        var currentMatrixDimension = _dimension.LowerBound;

        currentMatrixDimension = _dimension.DecreaseDimension(currentMatrixDimension);

        Assert.That(currentMatrixDimension, Is.EqualTo(_dimension.LowerBound));
    }
}