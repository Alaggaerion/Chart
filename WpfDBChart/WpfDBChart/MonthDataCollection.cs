using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;

namespace WpfDBChart
{
    public class MonthDataCollection : Collection<MonthData>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MonthDataCollection ()
        {
            CountMonths();            
        }

        /// <summary>
        /// Count all months entries
        /// </summary>
        public void CountMonths()
        {
            DBConnect connector = new DBConnect();

            for (int month = 1; month <= 12; month++)
            {
                connector.CountMonth(month);
                this.Add(new MonthData(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), connector.CountResult));
            }
        }
    }
}
