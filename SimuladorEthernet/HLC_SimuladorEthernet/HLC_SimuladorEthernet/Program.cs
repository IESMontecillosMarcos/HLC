using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLC_SimuladorEthernet
{
    class Program
    {
        // Falta por IMplementar:
        // - Pasar una Trama generica al constructor para identifcar despues el tipo TCP o UDP.
        // - IMPROTANT: Bus Tarjeta Red -> BuffP.
        // - Un mensaje de bienvenida que recuerde al usuario lo sexy que se ve hoy B) .

        // Errores conocidos:
        // - Liberacion de Trama, de bufP > bufS. El borrado de la trama se comporta de forma incorrecta.


        static void Main(string[] args)
        {
            // Atts.
            int opt=-1;
            int insert_port;
            int insert_prior;
            String insert_msg;
            int insert_trama;
            bool success;   // Flag para comprobar si als operaciones se han realizado correctamente.

            Random port = new Random();
            Random prior = new Random();
            Random msg = new Random();

            List<Trama> array_tramas;

            Trama trama1 = new Trama(port.Next(1,4), prior.Next(1,11), msg.Next(0, 50).ToString());
            Trama trama2 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama3 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama4 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama5 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama6 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama7 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama8 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama9 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());
            Trama trama10 = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());

            Trama aleatoria;

            Trama trama_a;    // Used for operational purposes, like liberando BusPrincipal.
            Trama trama_b;

            BufferPrincipal bufP = new BufferPrincipal();
            BufferSecundario bufS = new BufferSecundario();

            BusP busprincipal = new BusP();      // Mueve el flujo de datos al Buffer Secundario, bufS.

            // Start of Program.

            array_tramas = new List<Trama>();
            array_tramas.Add(trama1);
            array_tramas.Add(trama2);
            array_tramas.Add(trama3);
            array_tramas.Add(trama4);
            array_tramas.Add(trama5);
            array_tramas.Add(trama6);
            array_tramas.Add(trama7);
            array_tramas.Add(trama8);
            array_tramas.Add(trama9);
            array_tramas.Add(trama10);

            Console.WriteLine("========================");
            Console.WriteLine(">> Tramas List: ");
            foreach (Trama t in array_tramas)
            {
                Console.WriteLine(" : Port: " + t.Port + " Prior: " + t.Prior + " Msg: " + t.Msg);
            }
            Console.WriteLine("========================");

            while (opt != 0)
            {
                menu();
                opt = Convert.ToInt32(Console.ReadLine());


                switch (opt)
                {
                    case 1:
                        Console.WriteLine(">> Mostrar Buffer Principal.");
                        bufP.showBuffer();
                        break;
                    case 2:
                        Console.WriteLine(">> Mostrar Buffer Secundario.");
                        bufS.showBuffer();
                        break;
                    case 3:
                        Console.WriteLine(">> Insertar Trama en Buffer Principal.");

                        //Console.WriteLine(">> Que Trama desea insertar?");
                        //printTramasList(array_tramas);
                        //insert_trama = Convert.ToInt32(Console.ReadLine());

                        aleatoria = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());

                        success = bufP.insertTrama(aleatoria);

                        if (success)
                        {
                            Console.WriteLine("Nice B)");
                        } else
                        {
                            // BussP lleno seguramente!
                            Console.WriteLine("Como!? >:O ");

                            // Liberar BusP.
                            trama_a = bufP.extractTrama();
                            trama_b = bufP.extractTrama();

                            // BusPrincipal a rodar!! (Referencia a transformers :3)
                            if (busprincipal.liberar(trama_a, trama_b, bufS))
                            {
                                // No libera correctamente. La extracion de la trama desde bufP no funciona como deberia, extrae las tramas correctamente.
                                // Pero no "elimina/pone Prior -1" a la trama al salir de la extracion. Por lo tanto la inserccion en el bufS funciona
                                // pero no como deberia consecuencia de esto. Revisar.
                                Console.WriteLine("Error liberando tramas.");
                            }
                        }

                        break;
                    case 4:
                        Console.WriteLine(">> Insertar Trama en Buffer Secundario.");

                        aleatoria = new Trama(port.Next(1, 4), prior.Next(1, 11), msg.Next(0, 50).ToString());

                        success = bufS.insertTrama(aleatoria);

                        if (success)
                        {
                            Console.WriteLine("Nice B)");
                        }
                        else
                        {
                            Console.WriteLine("Como!? >:O ");
                        }
                        break;
                    case 5:
                        Console.WriteLine(">> Mostrar Tramas.");
                        printTramasList(array_tramas);
                        break;
                    case 6:
                        Console.WriteLine(">> Crear Trama.");

                        Console.WriteLine(">> Inserte Puerto Destino: ");
                        insert_port = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(">> Inserte Prioridad: ");
                        insert_prior = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(">> Inserte Mensaje: ");
                        insert_msg = Console.ReadLine();

                        array_tramas.Add(new Trama(insert_port, insert_prior, insert_msg));

                        Console.WriteLine(">> Trama insertada!");
                        break;
                    case 0:
                        Console.WriteLine(">> Salir.");
                        break;
                }
            }

        }

        public static void printTramasList(List<Trama> array)
        {
            int n = 0;

            Console.WriteLine("========================");
            Console.WriteLine(">> Tramas List: ");
            foreach (Trama t in array)
            {
                n++;
                Console.WriteLine(">> ["+n+"] : Port: " + t.Port + " Prior: " + t.Prior + " Msg: " + t.Msg);
            }
            Console.WriteLine("========================");
        }

        public static void menu()
        {
            Console.WriteLine(">> 1. Mostrar Buffer Principal.");
            Console.WriteLine(">> 2. Mostrar Buffer Secundario.");
            Console.WriteLine(">> 3. Insertar Trama en Buffer Principal.");
            Console.WriteLine(">> 4. Insertar Trama en Buffer Secundario.");
            Console.WriteLine(">> 5. Mostrar Tramas.");
            Console.WriteLine(">> 6. Crear Trama.");
            Console.WriteLine(">> 0. Salir.");
        }
    }
}