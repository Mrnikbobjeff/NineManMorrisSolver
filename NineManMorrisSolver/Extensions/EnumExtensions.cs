﻿using System;
namespace NineManMorrisSolver.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
