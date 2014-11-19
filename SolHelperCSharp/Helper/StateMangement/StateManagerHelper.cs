using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.StateMangement
{
    /// <summary>
    /// This class used for store data within application.
    /// </summary>
    public static class StateManagerHelper
    {
        #region Declaration

        // Assign dictionary object to store data with specified the key.
        private static Dictionary<String, Object> DicStateObj = new Dictionary<string, object>();

        #endregion

        #region Property

        /// <summary>
        /// This property used for store a data.
        /// </summary>
        public static Dictionary<String, Object> State
        {
            get { return DicStateObj; }
            set { DicStateObj = value; }
        }

        /// <summary>
        /// This is property used for to get the number keys and values.
        /// </summary>
        public static int Count
        {
            get { return DicStateObj.Count; }
        }
        #endregion

        #region Static Method

        /// <summary>
        /// This method is used for store data with specified the key. 
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <param name="Value">Specify the name of value</param>
        public static void Add(String Key, Object Value)
        {
            try
            {
                // Check key and value is null or not
                if (Key==String.Empty && Value == null) throw new ArgumentNullException();

                // Add a value with key.
                DicStateObj.Add(Key, Value);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Asynchronous Method

        /// <summary>
        /// This method is used for store data Asynchronously.
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <param name="Value">Specify the name of value</param>
        /// <returns>Task</returns>
        public static Task AddAsync(String Key, Object Value)
        {
            try
            {
                //Async Operation
                return Task.Run(() => Add(Key, Value));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
