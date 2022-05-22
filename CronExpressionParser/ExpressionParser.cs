using ProjectConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectConstants;

namespace CronExpressionParser
{
    public interface IExpressionParser
    {
        List<CronExpression> ObjectifyCronExpression(string cronArguments);
    }
    public class ExpressionParser : IExpressionParser
    {
        public List<CronExpression> ObjectifyCronExpression(string cronArguments)
        {
            var argumentList = cronArguments.Split(Constants.CronExpressionDelimiter).ToList();

            var minuteCronExpression = new CronExpression("Minute", Constants.MinuteLabel, argumentList[0], Constants.MinMinuteValue, Constants.MaxMinuteValue);
            var hourCronExpression = new CronExpression("Hour", Constants.HourLabel, argumentList[1], Constants.MinHourValue, Constants.MaxHourValue);
            var dayofmonthCronExpression = new CronExpression("DayOfMonth", Constants.DayOfMonthLabel, argumentList[2], Constants.MinDayOfMonthValue, Constants.MaxDayOfMonthValue);
            var monthCronExpression = new CronExpression("Month", Constants.MonthLabel, argumentList[3], Constants.MinMonthValue, Constants.MaxMonthValue);
            var dayofweekCronExpression = new CronExpression("DayOfWeek", Constants.DayOfWeekLabel, argumentList[4], Constants.MinDayOfWeekValue, Constants.MaxDayOfWeekValue);
            var commandCronExpression = new CronExpression("Command", Constants.CommandLabel, argumentList[5]);

            var cronExpressionList = new List<CronExpression>();
            cronExpressionList.Add(minuteCronExpression);
            cronExpressionList.Add(hourCronExpression);
            cronExpressionList.Add(dayofmonthCronExpression);
            cronExpressionList.Add(monthCronExpression);
            cronExpressionList.Add(dayofweekCronExpression);
            cronExpressionList.Add(commandCronExpression);

            return cronExpressionList;
        }
    }

}
