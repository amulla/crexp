using System;
using System.Collections.Generic;
using System.Text;
using ProjectConstants;
using static ProjectConstants.Constants;

namespace CronExpressionParser
{
    public class CronExpression
    {
        public string Name;
        public string Label;
        public string Value;
        public int MinimumValue;
        public int MaximumValue;
        public CronType Type;

        public CronExpression(string name, string label, string value)
        {
            Name = name;
            Label = label;
            Value = value;
            Type = GetCronType(value, 0, 0);
        }
        public CronExpression(string name, string label, string value, int minimumValue, int maximumValue)
        {
            Name = name;
            Label = label;
            Value = value;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            Type = GetCronType(value, minimumValue, maximumValue);
        }

        private CronType GetCronType(string value, int min, int max)
        {
            if (Any(value))
            {
                return CronType.Any;
            }

            if (CronInteger(value, min, max))
            {
                return CronType.Integer;
            }

            if (CronList(value))
            {
                return CronType.List;
            }

            if (CronRange(value))
            {
                return CronType.Range;
            }

            if (CronStep(value))
            {
                return CronType.Step;
            }

            return CronType.Command;
        }

        private bool Any(string value)
        {
            return value == "*";
        }

        private bool CronInteger(string value, int min, int max)
        {
            int parsedValue = int.TryParse(value, out parsedValue) ? parsedValue : -1;
            bool isInRange = (parsedValue >= min && parsedValue <= max);

            return isInRange;
        }

        private bool CronList (string value)
        {
            string[] parsedValues = value.Split(Constants.CronSplitDelimiter);
            foreach (string parsedValue in parsedValues)
            {
                int integerValue = int.TryParse(parsedValue, out integerValue) ? integerValue : -1;
                if (integerValue == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CronRange (string value)
        {
            string[] parsedValues = value.Split(Constants.CronRangeDelimiter);
            if (parsedValues.Length != 2)
            {
                return false;
            }

            foreach (string parsedValue in parsedValues)
            {
                int integerValue = int.TryParse(parsedValue, out integerValue) ? integerValue : -1;
                if (integerValue == -1)
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool CronStep (string value)
        {
            string[] parsedValues = value.Split(Constants.CronStepDelimiter);
            if (parsedValues.Length != 2)
            {
                return false;
            }

            if (parsedValues[0] != "*")
            {
                return false;
            }

            int integerValue = int.TryParse(parsedValues[1], out integerValue) ? integerValue : -1;
            if (integerValue == -1)
            {
                return false;
            }

            return true;
        }

    }
}
