using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class DBHelper
    {
        public static string ConnectionString()
        {
            return @"server=AMAANSHEIKH;database=POS_db;Integrated Security=SSPI;";        
        }

    }
}
