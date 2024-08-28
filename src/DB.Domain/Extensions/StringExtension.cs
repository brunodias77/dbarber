using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool NotEmpty([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value);

    }
}