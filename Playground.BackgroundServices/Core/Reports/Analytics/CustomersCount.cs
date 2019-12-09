﻿using Playground.BackgroundServices.Shared.Layouts;
using System;
using System.Linq;

namespace Playground.BackgroundServices.Reports.Analytics
{
    public static class CustomersCount
    {
        public static string Run(SalesLayout data)
        {
            if (data == null)
                throw new ArgumentNullException();

            var response = data.Customers.Distinct().Count();

            return $"CustomersCount: {response}";
        }
    }
}