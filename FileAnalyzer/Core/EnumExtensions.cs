using System;
using System.ComponentModel;
using System.Reflection;

namespace FileAnalyzer.Core
{
    public static class EnumExtensions
    {
        public static string GetExtension(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    }
}
