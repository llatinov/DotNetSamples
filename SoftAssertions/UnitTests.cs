using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftAssertions
{
    [TestClass]
    public class UnitTests
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
            _softAssertions.Add("Passing bool Add assertion", true, true);
            _softAssertions.Add("Passing string Add assertion", "SameString", "SameString");
            _softAssertions.Add("Passing int Add assertion", 1, 1);
            _softAssertions.AddTrue("Passing AddTrue assertion", true);
        }

        [TestMethod]
        public void TestFailingSoftAssertions()
        {
            _softAssertions.Add("Failing bool Add assertion", true, false);
            _softAssertions.Add("Failing string Add assertion", "SameString", "OtherString");
            _softAssertions.Add("Failing int Add assertion", 1, 2);
            _softAssertions.AddTrue("Failing AddTrue assertion", false);
        }

        [TestMethod]
        public void TestMixedSoftAssertions()
        {
            _softAssertions.Add("Passing bool Add assertion", true, true);
            _softAssertions.Add("Failing bool Add assertion", true, false);
            _softAssertions.Add("Passing string Add assertion", "SameString", "SameString");
            _softAssertions.Add("Failing string Add assertion", "SameString", "OtherString");
            _softAssertions.Add("Passing int Add assertion", 1, 1);
            _softAssertions.Add("Failing int Add assertion", 1, 2);
            _softAssertions.AddTrue("Passing AddTrue assertion", true);
            _softAssertions.AddTrue("Failing AddTrue assertion", false);
        }
    }
}