using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBChart
{
    public class MonthData
    {
        private string month;
        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }
        private int count;
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="month"></param>
        /// <param name="count"></param>
        public MonthData(string month, int count)
        {
            this.month = month;
            this.count = count;
        }
    }
}
