using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Pull.Common_Data_Structure
{
    /// <summary>
    /// for x or y header 
    /// </summary>
    public class HeaderInfo
    {
        /// <summary>
        /// FromCell and ToCell are counts not index
        /// for example
        /// a header like as follow 
        /// x x h h h h y
        /// x and y is something and h is header 
        /// so FromCell is 2 (two x) , and ToCell is 1 (one y)
        /// </summary>
        public int FromCell { get; set; } = -1;
        public int ToCell { get; set; } = -1;
        public List<string> Flag { get; set; } = new List<string>();
    }
}
