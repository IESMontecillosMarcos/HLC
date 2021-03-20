using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLC_SimuladorEthernet
{
    class BusP
    {

        public bool liberar(Trama a,Trama b, BufferSecundario bs)
        {
            if (!bs.insertTrama(a))
            {
                return false;
            }

            if (!bs.insertTrama(b))
            {
                return false;
            }

            return true;
        }
    }
}
