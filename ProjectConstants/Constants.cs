using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectConstants
{

    public class Constants
    {
        public const int ExpectedArgumantCount = 1;
        public const int ExpectedCronExpressionCount = 6;
        public const char CronExpressionDelimiter = ' ';
        public const char CronSplitDelimiter = ',';
        public const char CronRangeDelimiter = '-';
        public const char CronStepDelimiter = '/';
        public const string ListOutputDelimiter = " ";
        public const string MinuteLabel = "minute";
        public const string HourLabel = "hour";
        public const string DayOfMonthLabel = "day of month";
        public const string MonthLabel = "month";
        public const string DayOfWeekLabel = "day of week";
        public const string CommandLabel = "command";
        public const int MinMinuteValue = 0;
        public const int MaxMinuteValue = 59;
        public const int MinHourValue = 0;
        public const int MaxHourValue = 23;
        public const int MinDayOfMonthValue = 1;
        public const int MaxDayOfMonthValue = 31;
        public const int MinMonthValue = 1;
        public const int MaxMonthValue = 12;
        public const int MinDayOfWeekValue = 0;
        public const int MaxDayOfWeekValue = 6;
        public const string OutputFormat = "{0,-14}{1,-62}";
    }

    public enum CronType
    {
        Any,
        Integer,
        List,
        Range,
        Step,
        Command
    }
}
