using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Helper.Registry
{
    public static class RegistryHelper
    {
        #region Declaration

        private static RegistryKey RegistryKeyObj = null;

        #endregion 

        #region Public Methods

        /// <summary>
        /// Create a value 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boolean Write(String Path, String Key, Object Value)
        {
            Boolean Flag = false;
            try
            {
                // Check the Path,Key and Value is null or not. 
                if (Path == String.Empty && Key == String.Empty && Value == null)
                    throw new ArgumentNullException();

                // Create a new subkey or open existing subkey.
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey(Path);

                // Open subkey for write a value
                RegistryKeyObj = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(Path, true);

                // Set the Specified Key and Value
                RegistryKeyObj.SetValue(Key, Value);

                Flag = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Flag;
        }


        #endregion

        #region Asynchronous Methods

        public static Task<Boolean> WriteAsync(String Path, String Key, Object Value)
        {
            try
            {
                return Task.Run<Boolean>(() => Write(Path, Key, Value));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
