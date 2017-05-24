using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KDZVERSH
{
    class logger
    {
        private static logger instance;

        private logger()
        {
        }

        public static logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new logger();
                }
                return instance;
            }
        }

        public void Log(string msg)
        {
            File.AppendAllText("logger.txt", $"{DateTime.Now} - {msg}" + "\t");
        }
    }

}
