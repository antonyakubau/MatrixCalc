namespace MatrixCalc.UnitTests;

public class MatrixTests
{
    [SetUp]
    public void Setup()
    {
        Xamarin.Forms.Mocks.MockForms.Init();
    }

    [Test]
    public void UpdateMatrix_DimensionIs4_CorrectTypeOfChilds()
    {
        var matrix = new Matrix();
        var currentMatrixDimension = 4;
        int inputEntryCount = 0;
        int inputEntryCountCorrect = 16;
        int getInfoButtonCount = 0;
        int getInfoButtonCountCorrect = 8;
        int updateButtonCount = 0;
        int updateButtonCountCorrect = 1;

        matrix.UpdateMatrix(currentMatrixDimension);

        foreach (var child in matrix.Children)
        {
            if (child is InputEntry)
            {
                inputEntryCount++;
            }
            else
            if (child is GetInfoButton)
            {
                getInfoButtonCount++;
            }
            else
            if (child is UpdateButton)
            {
                updateButtonCount++;
            }
        }

        Assert.That(inputEntryCount, Is.EqualTo(inputEntryCountCorrect));
        Assert.That(getInfoButtonCount, Is.EqualTo(getInfoButtonCountCorrect));
        Assert.That(updateButtonCount, Is.EqualTo(updateButtonCountCorrect));
    }
}