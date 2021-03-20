using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLC_SimuladorEthernet
{
    class BufferSecundario : Buffer
    {
        // List to save Tramas.
        List<Trama> port_one;
        List<Trama> port_two;
        List<Trama> port_three;

        // Const.
        public BufferSecundario()
        {
            port_one = new List<Trama>();
            port_two = new List<Trama>();
            port_three = new List<Trama>();
        }

        // Methods.
        public Trama extractTrama()
        {
            // Impossible to do this on an UNLIMITED Array of Tramas. Update: Unnecesary*
            return null;
        }

        public bool insertTrama(Trama t)
        {

            switch (t.Port)
            {
                case 1:
                    port_one.Add(t);
                    return true;
                    break;
                case 2:
                    port_two.Add(t);
                    return true;
                    break;
                case 3:
                    port_three.Add(t);
                    return true;
                    break;
                default:
                    Console.WriteLine("Error. How did you even got here! LOL");
                    return false;
                    break;
            }
        }

        public bool isEmpty()
        {
            //IEnumerator p1 = port_one.GetEnumerator();
            //IEnumerator p2 = port_two.GetEnumerator();
            //IEnumerator p3 = port_three.GetEnumerator();

            foreach(Trama t in port_one)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine("Tramas en Puerto 1!");
                    return false;
                }
            }
            foreach (Trama t in port_two)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine("Tramas en Puerto 2!");
                    return false;
                }
            }
            foreach (Trama t in port_three)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine("Tramas en Puerto 3!");
                    return false;
                }
            }
            return true;

        }

        public bool isFull()
        {
            // Bruh, esto no se llena ni aunque lo intentes. Bueno, si se llenase, tambien explotara. D:
            return false;
        }

        public void showBuffer()
        {
            Console.WriteLine("Puerto 1: ");
            foreach (Trama t in port_one)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine(" : Port: " + t.Port + " Prior: " + t.Prior + " Msg: " + t.Msg);
                }
            }

            Console.WriteLine("Puerto 2: ");
            foreach (Trama t in port_two)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine(" : Port: " + t.Port + " Prior: " + t.Prior + " Msg: " + t.Msg);
                }
            }

            Console.WriteLine("Puerto 3: ");
            foreach (Trama t in port_three)
            {
                if (t.Prior != -1)
                {
                    Console.WriteLine(" : Port: " + t.Port + " Prior: " + t.Prior + " Msg: " + t.Msg);
                }
            }
        }
    }
}
