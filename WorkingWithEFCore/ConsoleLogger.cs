﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace WorkingWithEFCore
{
    class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        // Если логгер использует неуправляемые ресурсы, то здесь
        // можно освободить память
        public void Dispose() { }
    }

    public class ConsoleLogger : ILogger
    {
        // Если логгер применяет неуправляемые ресурсы, то здесь
        // можно вернуть класс, реализующий IDisposable
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // во избежание ведения лишних журналов можно отфильтровать
            // по уровню логгирования
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            // Занести в журнал уровень логгирования и идентификатор события
            Write($"Level: {logLevel}, Event ID: {eventId}");

            // Вывод только состояния или исключения при наличии
            if (state != null)
            {
                Write($", State: {state}");
            }
            if (exception != null)
            {
                Write($", Exception: {exception}");
            }
            WriteLine();
        }
    }
}
