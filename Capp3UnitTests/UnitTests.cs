using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;
using CronExpressionParser;
using static ProjectConstants.Constants;

namespace Capp3UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private readonly ValidationService _validationService;
        private readonly ExpressionParser _expressionParser;

        public UnitTests()
        {
            _validationService = new ValidationService();
            _expressionParser = new ExpressionParser();
        }

        [TestMethod]
        public void NumberOfArgumentsIsValid()
        {
            var args = new string[] { "* * * * * sometext" };
            var result = _validationService.argumentCountIsValid(args);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ZeroNumberOfArgumentsIsInvalid()
        {
            var args = new string[] { };
            var result = _validationService.argumentCountIsValid(args);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MoreThanOneArgumentsIsInvalid()
        {
            var args = new string[] { "* * * * *", "2nd arg" };
            var result = _validationService.argumentCountIsValid(args);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseExpressionAndStoreinObject()
        {
            var args = new string("*/15 0 1,15 * 1-5 /usr/bin/find");
            var result = _expressionParser.ObjectifyCronExpression(args);
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void CronExpressionIsValid()
        {
            var args = new string("*/15 0 1,15 * 1-5 /usr/bin/find");
            var cronExpressions = _expressionParser.ObjectifyCronExpression(args);
            var result = _validationService.cronExpressionsAreValid(cronExpressions);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CronExpressionIsValid2()
        {
            var args = new string("* 0 1,15 * */2 /usr/bin/find");
            var cronExpressions = _expressionParser.ObjectifyCronExpression(args);
            var result = _validationService.cronExpressionsAreValid(cronExpressions);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CronExpressionIsValid3()
        {
            var args = new string("0 0 1 * * /usr/bin/find");
            var cronExpressions = _expressionParser.ObjectifyCronExpression(args);
            var result = _validationService.cronExpressionsAreValid(cronExpressions);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CronExpressionIsNotValid()
        {
            var args = new string("1/15 0 1,15 * 1-5 /usr/bin/find");
            var cronExpressions = _expressionParser.ObjectifyCronExpression(args);
            var result = _validationService.cronExpressionsAreValid(cronExpressions);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CronExpressionIsNotValid2()
        {
            var args = new string("*/15/30 0 1,15 * 1-5 /usr/bin/find");
            var cronExpressions = _expressionParser.ObjectifyCronExpression(args);
            var result = _validationService.cronExpressionsAreValid(cronExpressions);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CronExpressionIsNotValid3()
        {
            var args = new string("*");
            var cronExpression = args.Split(' ');
            var result = _validationService.argumentCountIsValid(cronExpression);
            Assert.IsFalse(result);
        }
    }
}
