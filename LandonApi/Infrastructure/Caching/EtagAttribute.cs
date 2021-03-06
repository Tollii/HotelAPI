﻿using System;
using LandonApi.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LandonApi.Infrastructure.Caching
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EtagAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new EtagHeaderFilter();
        }

        public bool IsReusable => true;
    }
}