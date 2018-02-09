using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace WebAppSelectDropdownList
{
    public static class Utils
    {

        public static SelectList ToSelectList(this IEnumerable _itens)
        {
            return new SelectList(_itens);
        }

        public static SelectList ToSelectList(this IEnumerable _itens, object selectedValue)
        {
            return new SelectList(_itens, selectedValue);
        }

        public static SelectList ToSelectList(this IEnumerable _itens, string dataValueField, string dataTextField)
        {
            return new SelectList(_itens, dataTextField, dataTextField);
        }

        public static SelectList ToSelectList(this IEnumerable _itens, string dataValueField, string dataTextField, object selectedValue)
        {
            return new SelectList(_itens, dataTextField, dataTextField, selectedValue);
        }

        public static SelectList ToSelectList(this IEnumerable _itens, string dataValueField, string dataTextField, object selectedValue, string dataGroupField)
        {
            return new SelectList(_itens, dataTextField, dataTextField, selectedValue, dataGroupField);
        }
    }
}
