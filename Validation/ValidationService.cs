using System.Linq;
using System.Collections.Generic;
using CronExpressionParser;
using ProjectConstants;

namespace Validation
{
    public interface IValidationService
    {
        bool argumentCountIsValid(string[] args);
        bool cronExpressionsAreValid(List<CronExpression> cronExpressionList);
    }
    public class ValidationService : IValidationService
    {
        public bool argumentCountIsValid(string[] args)
        {
            if (args.Length == Constants.ExpectedArgumantCount)
            {
                if (CorrectNumberOfCronExpressions(args[0]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool cronExpressionsAreValid(List<CronExpression> cronExpressionList)
        {
            if (! CorrectNumberOfCronExpressions (cronExpressionList.Count))
            {
                return false;
            }

            if (! WellFormattedCronExpression(cronExpressionList))
            {
                return false;
            }

            return true;
        }

        private bool CorrectNumberOfCronExpressions(int expressionCount)
        {
            if (expressionCount != Constants.ExpectedCronExpressionCount)
            {
                return false;
            }

            return true;
        }

        private bool CorrectNumberOfCronExpressions(string cronExpressions)
        {
            string[] cronExpression = cronExpressions.Split(Constants.CronExpressionDelimiter);
            if (cronExpression.Count() != Constants.ExpectedCronExpressionCount)
            {
                return false;
            }

            return true;
        }

        private bool WellFormattedCronExpression(List<CronExpression> cronExpressionList)
        {
            if (cronExpressionList.Where(value => value.Type == CronType.Command).Count() != 1)
            {
                return false;
            }

            return true;
        }
    }
}
