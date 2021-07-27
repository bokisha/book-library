using System;
using System.Collections.Generic;
using BookLibrary.Models;

namespace BookLibrary.Enums
{
    public static class EnumHelper
    {
        public static IEnumerable<SelectItemByIdModel> GetSelectItems(Type enumType)
        {
            var list = new List<SelectItemByIdModel>();
            foreach (int i in Enum.GetValues(enumType))
            {
                list.Add(new SelectItemByIdModel
                {
                    Value = i,
                    Description = Enum.GetName(enumType, i)
                });
            }

            return list;
        }
    }
}
