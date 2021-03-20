using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLC_SimuladorEthernet
{
    interface Buffer
    {
        bool insertTrama(Trama t);    // Inserts a Trama in the buffer.
        Trama extractTrama();    // Extracts a Trama from the buffer.

        bool isEmpty();
        bool isFull();  // Not aplicabble to Unlimited Buffers!

        void showBuffer();  // Prints the Data of the Buffer.
    }
}
