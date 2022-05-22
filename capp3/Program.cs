using System;
using Validation;
using CronExpressionParser;
using Presentation;
using System.Collections.Generic;

namespace capp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use DI framework in production
            var validation = new ValidationService();
            var expressionParser = new ExpressionParser();
            var outputService = new ConsoleOutputService();

            //Validate arguments
            if (! validation.argumentCountIsValid(args))
            {
                return;
            }

            var cronExpressionList = expressionParser.ObjectifyCronExpression(args[0]);

            if (validation.cronExpressionsAreValid(cronExpressionList))
            {
                outputService.OutputCronExpressions(cronExpressionList);
            }

            Console.ReadKey();
        }
    }
}
