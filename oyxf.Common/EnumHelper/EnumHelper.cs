using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace oyxf.Common
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T e) //T为任意枚举类型
        {
            string desc = string.Empty;

            Type t = e.GetType();
            FieldInfo fi = t.GetField(e.ToString());
            if (!fi.IsDefined(typeof(EnumDescriptionAttribute), false))//是否定义了特性
            {
                return desc;
            }

            object[] objs = fi.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);//获取指定特性
            if (objs == null || objs.Length <= 0)
            {
                return desc;
            }

            EnumDescriptionAttribute[] arr = objs as EnumDescriptionAttribute[];
            foreach (EnumDescriptionAttribute item in arr)
            {
                desc += item.Desc + " | ";
            }
            desc = desc.TrimEnd(new char[] { ' ', '|', ' ' });

            return desc;
        }

        public static string GetDescription(this Enum e)
        {
            return GetDescription<Enum>(e);
        }
        public static string GetDescription<T>(this long value) //long -->  任意的Enum类型
        {
            T t = (T)Enum.Parse(typeof(T), value.ToString());
            return GetDescription<T>(t); //Enum --> Enum特性值
        }
    }
}
