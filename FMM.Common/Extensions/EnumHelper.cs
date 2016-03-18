using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace FMM.Common.Extensions
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="e">枚举类型</param>
        /// <returns></returns>
        public static string GetEnumDesc(this Enum e)
        {
            try
            {
                FieldInfo ms = e.GetType().GetField(e.ToString());
                if (ms == null) return "错误";
                DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])ms.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (EnumAttributes.Length > 0)
                {
                    return EnumAttributes[0].Description;
                }
                return e.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取枚举键值集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<object, object> GetEnumDictionary(this Type type)
        {
            FieldInfo[] fields = type.GetFields();
            var dic = new Dictionary<object, object>();
            foreach (FieldInfo field in fields)
            {
                string desription;
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs != null && objs.Length != 0)
                {
                    var da = (DescriptionAttribute)objs[0];
                    desription = da.Description;
                }
                else
                {
                    desription = field.Name;
                }
                if (field.Name.Equals("value__"))
                    continue;

                dic.Add(((int)Enum.Parse(type, field.Name)).ToString(), desription);
            }
            return dic;
        }

        /// <summary>
        /// 把一个字符串值转换为对应的枚举值
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="value">字符串值</param>
        /// <param name="defaultValue">默认枚举值</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T必须是一个枚举");
            }
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return defaultValue;
        }
    }
}
