namespace MatrixCalc.UnitTests;

public class MatrixTests_UpdateMatrix
{
    private Matrix _matrix;

    [SetUp]
    public void Setup()
    {
        Xamarin.Forms.Mocks.MockForms.Init();
        _matrix = new Matrix();
    }

    [Test]
    [TestCase(4, 25)]
    [TestCase(1, 4)]
    [TestCase(9, 100)]
    public void UpdateMatrix_MatrixDimension_CorrectNumberOfChilds
        (int currentMatrixDimension, int numberOfChilds)
    {
        _matrix.UpdateMatrix(currentMatrixDimension);

        Assert.That(_matrix.Children.Count, Is.EqualTo(numberOfChilds));
    }

    [Test]
    [TestCase(4, 16, 8, 1)]
    [TestCase(1, 1, 2, 1)]
    [TestCase(9, 81, 18, 1)]
    public void UpdateMatrix_MatrixDimension_CorrectTypeOfChilds(
        int currentMatrixDimension,
        int inputEntryCountCorrect,
        int getInfoButtonCountCorrect,
        int updateButtonCountCorrect)
    {
        int inputEntryCount = 0;
        int getInfoButtonCount = 0;
        int updateButtonCount = 0;

        _matrix.UpdateMatrix(currentMatrixDimension);

        foreach (var child in _matrix.Children)
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

    [Test]
    [TestCase(4)]
    [TestCase(1)]
    [TestCase(9)]
    public void UpdateMatrix_Updated_LinesAreAssigned(int currentMatrixDimension)
    {
        _matrix.UpdateMatrix(currentMatrixDimension);

        Assert.That(_matrix.Lines.Count, Is.EqualTo(_matrix.ButtonList.Count));
    }

    [Test]
    [TestCase(4)]
    [TestCase(1)]
    [TestCase(9)]
    [Ignore("Line logic should be improved")]
    public void UpdateMatrix_Updated_LineIdEqualToButtonLine(int currentMatrixDimension)
    {
        _matrix.UpdateMatrix(currentMatrixDimension);
        bool IsLineEqual = false;

        foreach (var button in _matrix.ButtonList)
        {
            for (int lineId = 0; lineId < _matrix.Lines.Count; lineId++)
            {
                if (lineId == button.LineId)
                {
                    IsLineEqual = true;
                    break;
                }
            }
            Assert.That(IsLineEqual, Is.True);
            IsLineEqual = false;
        }
    }
}