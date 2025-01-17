﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.NewtonsoftJson
{
    internal static class NewtonsoftJsonLoggerExtensions
    {
        private static readonly Action<ILogger, Exception> _jsonInputFormatterException;

        private static readonly Action<ILogger, string, Exception> _jsonResultExecuting;

        static NewtonsoftJsonLoggerExtensions()
        {
            _jsonInputFormatterException = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(1, "JsonInputException"),
                "JSON input formatter threw an exception.");

            _jsonResultExecuting = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(1, "JsonResultExecuting"),
                "Executing JsonResult, writing value of type '{Type}'.");
        }

        public static void JsonInputException(this ILogger logger, Exception exception)
        {
            _jsonInputFormatterException(logger, exception);
        }

        public static void JsonResultExecuting(this ILogger logger, object value)
        {
            var type = value == null ? "null" : value.GetType().FullName;
            _jsonResultExecuting(logger, type, null);
        }
    }
}
