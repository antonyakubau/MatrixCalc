namespace MatrixCalc.UnitTests
{
    public class MatrixVMTests
    {
        private Mock<IMatrix> mockMatrix;
        [SetUp]
        public void Setup()
        {
            mockMatrix = new Mock<IMatrix>();   
        }

        [Test]
        public void CalculateMin_ListOfEntriesWithText_MinValueFound()
        {

        }
    }
}

