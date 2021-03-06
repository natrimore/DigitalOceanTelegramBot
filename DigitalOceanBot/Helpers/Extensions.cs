﻿using System;

namespace DigitalOceanBot.Helpers
{
    public static class Extensions
    {
        public static T CastObject<T>(this object obj)
        {
            if (obj != null)
            {
                return (T)obj;
            }

            throw new ArgumentNullException(nameof(obj));
        }

        public static string GetDefaultIfStringEmpty(this string text)
        {
            return string.IsNullOrEmpty(text) ? "None" : text;
        }
    }
}
