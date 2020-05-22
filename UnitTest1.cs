using NUnit.Framework;
using Lis;
using Moq;

namespace Lis.Tests
{
    public class Tests
    {
        private ITwoDigit _twoDigit;
        private INumberConverter _numberConverter;

        public Tests(ITwoDigit twoDigit, INumberConverter numberConverter)
        {
            this._twoDigit = twoDigit;
            this._numberConverter = numberConverter;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ExpectedTwoDigitWords()
        {
            var expectedResult = "sixteen ";
            var numberToSend = 16;
            var stringToSend = "sixteen ";

            Assert.AreEqual(Mock.Of<ITwoDigit>(x => x.NumToWords(numberToSend, stringToSend) == expectedResult), expectedResult);
            
        }

        [Test]
        public void ExpectedWords()
        {
            var expectedResult = "one thousand two hundred thirty four";
            var numberToSend = 1234;
            Assert.AreEqual(Mock.Of<INumberConverter>(x => x.ConvertToWords(numberToSend) == expectedResult),
                expectedResult);

        }

    }
}