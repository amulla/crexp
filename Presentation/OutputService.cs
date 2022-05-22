using System;
using System.Collections.Generic;
using CronExpressionParser;
using ProjectConstants;

namespace Presentation
{
    public interface IOutputService
    {
        void OutputCronExpressions(List<CronExpressionParser.CronExpression> cronExpressionList);
    }
    public class ConsoleOutputService : IOutputService
    {
        public void OutputCronExpressions(List<CronExpressionParser.CronExpression> cronExpressionList)
        {
            foreach (CronExpressionParser.CronExpression cronExpression in cronExpressionList)
            {
                var displayLabel = cronExpression.Label;
                var displayValue = FormatCronExpressionForDisplay(cronExpression);
                var displayOutput = string.Format(Constants.OutputFormat, displayLabel, displayValue);

                Console.WriteLine(displayOutput);
            }
        }

        private string FormatCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            var returnString = string.Empty;

            if (cronExpression.Type == CronType.Any)
            {
                return FormatAnyCronExpressionForDisplay(cronExpression);
            }

            if (cronExpression.Type == CronType.Command)
            {
                return FormatCommandCronExpressionForDisplay(cronExpression);
            }

            if (cronExpression.Type == CronType.Integer)
            {
                return FormatIntegerCronExpressionForDisplay(cronExpression);
            }

            if(cronExpression.Type == CronType.List)
            {
                return FormatListCronExpressionForDisplay(cronExpression);
            }

            if (cronExpression.Type == CronType.Range)
            {
                return FormatRangeCronExpressionForDisplay(cronExpression);
            }

            if (cronExpression.Type == CronType.Step)
            {
                return FormatStepCronExpressionForDisplay(cronExpression);
            }

            return returnString;
        }

        private string FormatAnyCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            var returnString = string.Empty;

            for (int i = cronExpression.MinimumValue; i <= cronExpression.MaximumValue; i++)
            {
                returnString += i;
                returnString += Constants.ListOutputDelimiter;
            }

            return returnString;
        }

        private string FormatCommandCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            return cronExpression.Value;
        }

        private string FormatIntegerCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            return cronExpression.Value;
        }

        private string FormatListCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            var returnString = string.Empty;

            var listValues = cronExpression.Value.Split(Constants.CronSplitDelimiter);
            foreach(var value in listValues)
            {
                returnString += value;
                returnString += Constants.ListOutputDelimiter;
            }

            return returnString;
        }

        private string FormatRangeCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            var returnString = string.Empty;
            var listValues = cronExpression.Value.Split(Constants.CronRangeDelimiter);
            var rangeStart = int.Parse(listValues[0]);
            var rangeEnd = int.Parse(listValues[1]);

            for (int i=rangeStart; i<=rangeEnd;i++)
            {
                returnString += i;
                returnString += Constants.ListOutputDelimiter;
            }

            return returnString;
        }

        private string FormatStepCronExpressionForDisplay(CronExpressionParser.CronExpression cronExpression)
        {
            var returnString = string.Empty;
            var listValues = cronExpression.Value.Split(Constants.CronStepDelimiter);
            var stepStart = cronExpression.MinimumValue;
            var stepEnd = cronExpression.MaximumValue;
            var stepValue = int.Parse(listValues[1]);

            for (int i = stepStart; i <= stepEnd; i += stepValue)
            {
                returnString += i;
                returnString += Constants.ListOutputDelimiter;
            }

            return returnString;
        }
    }
}
