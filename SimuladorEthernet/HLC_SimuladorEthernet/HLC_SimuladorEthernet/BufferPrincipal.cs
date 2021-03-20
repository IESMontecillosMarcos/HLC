using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HLC_SimuladorEthernet
{
    class BufferPrincipal : Buffer
    {
        // Array de INTs , para testear.
        private Trama[] tramas;

        // Const.
        public BufferPrincipal()
        {           
            // ATENCION: Una trama con prioridad -1 sera considerada VACIO en el array.
            tramas = new Trama[4];
            for (int i = 0; i < 4; i++)
            {
                tramas[i] = new Trama(0, -1, "");
            }
        }

        // Methods.
        public Trama extractTrama()
        {                  
            Trama trama_a = tramas[0];

            for (int i = 0; i < 4; i++)
            {
                // Compare Tramas Array.
                if (trama_a.Prior < tramas[i].Prior)
                {
                    trama_a = tramas[i];
                }
            }

            // Borrado de tramas de BP.
            for (int i = 2; i < 4; i++)
            {
                if (tramas[i] == trama_a)
                {
                    // Borrado de Trama.
                    tramas[i].Prior = -1;
                }
            }

            return trama_a;
        }

        public bool insertTrama(Trama t)
        {            
            if (!isFull())
            {                
                // Insert.
                for (int i = 0; i < 4; i++)
                {
                    if (tramas[i].Prior == -1)
                    {
                        tramas[i] = t;
                        Console.WriteLine("Trama inserted succesfully!");
                        return true;
                    }                    
                }
            }
            return false;
        }

        public bool isEmpty()
        {
            for (int i = 0; i < 4; i++)
            {
                if (tramas[i].Prior != -1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isFull()
        {
            for (int i = 0; i < 4; i++)
            {
                if (tramas[i].Prior == -1)
                {
                    return false;
                }
            }
            return true;
        }

        public void showBuffer()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Trama: " + i + " : Port: " + tramas[i].Port+" Prior: "+ tramas[i].Prior+ " Msg: "+tramas[i].Msg);
            }
        }
    }
}
