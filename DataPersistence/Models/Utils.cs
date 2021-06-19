using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence.Models
{
    public class Utils
    {
        public static string getCurrentHour()
        {
            return DateTime.Now.Hour.ToString("00").PadLeft(2, '0') + ":00"; ;
        }
    }
}
