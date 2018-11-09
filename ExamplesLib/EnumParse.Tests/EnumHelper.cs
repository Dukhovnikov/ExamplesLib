using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamplesLib.EnumParseTests
{
    public static class EnumHelper
    {
        public static TEnum Parse<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
        }

        public static TEnum Parse<TEnum>(this string value, bool ignoreCase, TEnum defaultValue) where TEnum : struct
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            return EnumHelper.Parse<TEnum>(value, ignoreCase);
        }
        private static readonly Dictionary<string, Dictionary<string, string>> _enumValueDescriptionByEnumType = new Dictionary<string, Dictionary<string, string>>();
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public static string GetDescription(this Enum value)
        {
            string typeName = value.GetType().FullName;
            _lock.EnterUpgradeableReadLock();
            try
            {
                Dictionary<string, string> descriptions;
                if (!_enumValueDescriptionByEnumType.TryGetValue(typeName, out descriptions))
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        descriptions = GetEnumValueDescriptions(value);
                        _enumValueDescriptionByEnumType[typeName] = descriptions;
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                string result;
                if (descriptions.TryGetValue(value.ToString(), out result))
                {
                    return result;
                }

                return string.Empty;
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        private static Dictionary<string, string> GetEnumValueDescriptions(Enum value)
        {
            var enumType = value.GetType();
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var field in enumType.GetFields())
            {
                string description = field.Name;
                var descriptionAttribute = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                if (descriptionAttribute != null)
                {
                    description = descriptionAttribute.Description;
                }
                result[field.Name] = description;
            }

            return result;
        }
    }
}
