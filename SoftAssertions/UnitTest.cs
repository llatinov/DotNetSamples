using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftAssertions
{
    [TestClass]
    public class UnitTest
    {
        private SoftAssertions _softAssertions;

        [TestInitialize]
        public void SetUp()
        {
            _softAssertions = new SoftAssertions();
        }

        [TestCleanup]
        public void TearDown()
        {
            _softAssertions.AssertAll();
        }

        [TestMethod]
        public void TestPassingSoftAssertions()
        {
            _softAssertions.Add("Passing Add assertion", true, true);
            _softAssertions.AddTrue("Passing AddTrue assertion", true);
        }

        [TestMethod]
        public void TestFalingSoftAssertions()
        {
            _softAssertions.Add("Failing Add assertion", true, false);
            _softAssertions.AddTrue("Failing AddTrue assertion", false);
        }

        [TestMethod]
        public void TestMixedSoftAssertions()
        {
            _softAssertions.Add("Passing Add assertion", true, true);
            _softAssertions.Add("Failing Add assertion", true, false);
            _softAssertions.AddTrue("Passing AddTrue assertion", true);
            _softAssertions.AddTrue("Failing AddTrue assertion", false);
        }
    }
}