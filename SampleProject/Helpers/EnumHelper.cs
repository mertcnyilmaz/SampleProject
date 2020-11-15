using SampleProject.Consts;
using SampleProject.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleProject.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T value) where T : struct
        {
            var attributes = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return ((DescriptionAttribute)attributes[0]).Description;
        }
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {

                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                        
                }
                else
                {

                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                        
                }
            }

            throw new BusinessException(ExceptionMessageConsts.TYPE_NOT_FOUND_MESSAGE);
        }
    }
}
