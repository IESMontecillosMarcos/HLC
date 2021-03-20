using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLC_SimuladorEthernet
{
    class Trama
    {
        // WARNING: Deberia ser Clase Abstracta.

        // Atts.
        private int port;
        private int prior;
        private String msg;

        // Const.
        public Trama(int p, int pr, String m)
        {
            port = p;
            prior = pr;
            msg = m;
        }

        // Methods.
        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        public int Prior
        {
            get { return prior; }
            set { prior = value; }
        }
        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
    }
}
