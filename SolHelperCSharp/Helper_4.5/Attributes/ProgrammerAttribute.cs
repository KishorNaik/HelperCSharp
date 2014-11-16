using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper_4._5.Attributes
{
    /// <summary>
    ///  Information about programmer of section of code.
    /// </summary>
   [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ProgrammerAttribute:System.Attribute
    {
        #region Constructor

        public ProgrammerAttribute()
        {
            // blank constructor
        }

        public ProgrammerAttribute(String ProgrammerName, String CreationDate, String ModifyDate,String Comment)
        {
            this.ProgrammerName = ProgrammerName; // Name of Programmer
            this.CreationDate = CreationDate; // Creation Date of Source Code.
            this.ModifyDate = ModifyDate; // Modify date of Source Code.
            this.Comment = Comment; // Comment on Source Code.
        }

        #endregion

        #region Property

       /// <summary>
       /// Specify the Name of the programmer.
       /// </summary>
        public String ProgrammerName { get; set; }

       /// <summary>
       ///  Specify the creation date of source code.
       /// </summary>
        public String CreationDate { get; set; }

        /// <summary>
        ///  Specify the modify date of source code.
        /// </summary>
        public String ModifyDate { get; set; }

       /// <summary>
       /// Specify the comment on source code or any issue. 
       /// </summary>
        public String Comment { get; set; }

       #endregion
    }
}
