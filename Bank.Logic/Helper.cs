using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    public class Helper
    {
        private static Helper current;
        public static Helper Current { get { return current; } private set { current = value; } }

        public Api Api { get; private set; }
        //User
        //Storage

        private Helper()
        {
            Api = new Api();
        }

        public static void Initialize()
        {
            Current = new Helper();
        }
    }
}
