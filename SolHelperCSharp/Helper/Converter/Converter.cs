using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Converter
{
    /// <summary>
    /// This class used for Convert base type to another base type. 
    /// </summary>
    public static class Converter
    {
        #region Static Methods

        /// <summary>
        ///  This method used for return an object of the specified type.
        /// </summary>
        /// <typeparam name="TType">Specify the return type</typeparam>
        /// <typeparam name="TValue">Specify the value type</typeparam>
        /// <param name="TValueObj">Specify the value</param>
        /// <returns>T</returns>
        public static TType ConvertTo<TType, TValue>(TValue TValueObj)
        {
            TType TTypeObj = default(TType);
            try
            {
                // If value object is null then throw the exception.
                if (TValueObj == null) throw new ArgumentNullException();

                // Convert an object of the specified type.
                TTypeObj = (TType) Convert.ChangeType(TValueObj, typeof (TType));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return TTypeObj;
        }

        #endregion


        #region Asynchronous Method

        /// <summary>
        /// This method used for return an object of the specified type Asynchronously.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="TValueObj"></param>
        /// <returns></returns>
        public static Task<TType> ConvertToAsync<TType, TValue>(TValue TValueObj)
        {
            TType TTypeObj = default(TType);
            try
            {
                return Task.Run<TType>(() => ConvertTo<TType,TValue>(TValueObj));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


    }
}
