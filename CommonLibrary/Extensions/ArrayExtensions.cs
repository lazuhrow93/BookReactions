using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Checks to see if the array is null or empty
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object[] array)
        {
            return (array is null || array.Count() == 0);
        }

        /// <summary>
        /// Grab the middle element. (array.Length - 1)/2
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static object? Middle(this object[] array)
        {
            if (array.Count() == 0)
                return null;
            return array[(array.Length - 1)/2];
        }
    }
}
