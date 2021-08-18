﻿using Adverts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adverts.Common.Helper
{
    public static class SqlQueryHelper
    {
        public static string WhereConditions(this FilteringModel filteringModel)
        {
            StringBuilder sqlQuery = new StringBuilder();

            List<string> conditions = new List<string>();

            if (filteringModel.categoryId > 0) conditions.Add($"categoryId={filteringModel.categoryId}");
            if (filteringModel.price > 0) conditions.Add($"price={filteringModel.price}");
            if (!string.IsNullOrEmpty(filteringModel.fuel)) conditions.Add($"fuel='{filteringModel.fuel}'");
            if (!string.IsNullOrEmpty(filteringModel.gear)) conditions.Add($"gear='{filteringModel.gear}'");

            if (conditions.Any())
                sqlQuery.Append(" WHERE " + string.Join(" AND ", conditions.ToArray()));

            return sqlQuery.ToString();
        }


        public static string SortingConditions(this SortingModel sortingModel)
        {
            StringBuilder sqlQuery = new StringBuilder();
            List<string> sortingConditions = new List<string>();

            if (sortingModel.year) sortingConditions.Add("year");
            if (sortingModel.km) sortingConditions.Add("km");
            if (sortingModel.price) sortingConditions.Add("price");

            if (sortingConditions.Any())
                sqlQuery.Append("ORDER BY" + string.Join(" , ", sortingConditions.ToArray()));
            else
                sqlQuery.Append("ORDER BY id");
            return sqlQuery.ToString();
        }
    }
}
