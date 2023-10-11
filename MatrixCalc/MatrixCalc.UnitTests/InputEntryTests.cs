using System;
using MatrixCalc.Model;

namespace MatrixCalc.UnitTests
{
	public class InputEntryTests
	{
        InputEntry _inputEntry;

        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            _inputEntry = new InputEntry(0, 0);
        }

        [Test]
        public void UpdateResults_NewTextOfEntry_RaiseUpdateResultsDelegate()
        {
            bool Raised = false;

            UpdateResultsDelegate.UpdateResults += () => { Raised = true; };
            _inputEntry.Text = "999";

            Assert.That(Raised, Is.True);
        }

        [Test]
        [TestCase("123")]
        [TestCase("99jj")]
        [TestCase("8")]
        public void UpdateResults_NewTextValueIsNumeric_ReplaceWithNewText(string newValue)
        {
            var oldValue = _inputEntry.Text;

            if (oldValue == newValue)
                return;

            _inputEntry.Text = newValue;

            Assert.That(_inputEntry.Text, Is.Not.SameAs(oldValue));
        }
    }
}

