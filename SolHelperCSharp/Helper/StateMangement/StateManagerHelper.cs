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

        /// <summary>
        /// This method is used for store data with specified the key. 
        /// </summary>
        /// <typeparam name="T">Specify the name of type</typeparam>
        /// <param name="Key">Specify the name of key</param>
        /// <param name="Value">Specify the name of value</param>
        public static void Add<T>(String Key, T Value)
        {
            try
            {
                // Check key and value is null or not
                if (Key == String.Empty && Value == null) throw new ArgumentNullException();

                // Add a value with key.
                DicStateObj.Add(Key, Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method used for to get a value by specifying key.
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <returns>Object</returns>
        public static Object GetValue(String Key)
        {
            try
            {
                // Check key is empty or not
                if (Key != String.Empty) throw new ArgumentNullException();

                // Get the value based on specifying key
                return DicStateObj[Key];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       /// <summary>
        ///  This method used for to get a value with the specifying key.
       /// </summary>
       /// <typeparam name="T">Specify the name of type</typeparam>
       /// <param name="Key">Specify the name of key</param>
       /// <returns>T</returns>
        public static T GetValue<T>(String Key)
        {
            T TObj = default(T);
            try
            {
                // Check key is empty or not
                if (Key != String.Empty) throw new ArgumentNullException();

                TObj =(T) DicStateObj[Key];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return TObj;
        }

        /// <summary>
        /// This method used for to remove the value with the specified key.
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <returns>Boolean</returns>
        public static Boolean Remove(String Key)
        {
            try
            {
                // Check the key is emoty or not.
                if (Key == String.Empty) throw new ArgumentNullException();

                // Check the specified key find in Dic Object.
                if (DicStateObj.Count(LE => LE.Key == Key) >= 1)
                {
                    // if key find then remove the value with the specified key.
                    return DicStateObj.Remove(Key);
                }
                throw new KeyNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method used for to remove all values and keys.
        /// </summary>
        public static void RemoveAll()
        {
            try
            {
                // Remove all keys and values.
                DicStateObj.Clear();
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

        /// <summary>
        /// This method is used for store data Asynchronously.
        /// </summary>
        /// <typeparam name="T">Specify the name of type</typeparam>
        /// <param name="Key">Specify the name of key</param>
        /// <param name="Value">Specify the name of value</param>
        /// <returns>Task</returns>
        public static Task AddAsyanc<T>(String Key, T Value)
        {
            try
            {
                return Task.Run(() => Add<T>(Key, Value));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method used for to get a value asynchronously with the specified key.
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <returns>Object</returns>
        public static Task<Object> GetValueAsync(String Key)
        {
            try
            {
                return Task.Run<Object>(() => GetValue(Key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        ///  This method used for to get a value asynchronously with the specified key.
        /// </summary>
        /// <typeparam name="T">Specify the name of type.</typeparam>
        /// <param name="Key">Specify the name of key</param>
        /// <returns>T</returns>
        public static Task<T> GetValueAsync<T>(String Key)
        {
            try
            {
                return Task.Run<T>(() => GetValue<T>(Key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This method used for to remove the value asynchronously with the specified key.
        /// </summary>
        /// <param name="Key">Specify the name of key</param>
        /// <returns>Boolean</returns>
        public static Task<Boolean> RemoveAsync(String Key)
        {
            try
            {
                return Task.Run<Boolean>(() => Remove(Key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Task RemoveAllAsync()
        {
            try
            {
                return Task.Run(() => RemoveAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
