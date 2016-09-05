using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class ClientProgram
    {

        static void Main(string[] args)
        {
            

            ClientConnection clientConnection = new ClientConnection();

            
            clientConnection.Connect();
            clientConnection.SetUp();
            clientConnection.DoChat();

            //        byte[] receiveMessage = new byte[256];
            //        string data = null;
            //    }



            //            int bytesRead;

            //            while (true)
            //            {
            //                Console.Write("Entry: ");

            //                string sendMessage = Console.ReadLine();
            //                NetworkStream stream = client.GetStream();

            //                byte[] bytes = Encoding.ASCII.GetBytes(sendMessage);
            //                Console.WriteLine("Transmitting...");

            //                stream.Write(bytes, 0, bytes.Length);


            //                Console.WriteLine("Sent: {0}", sendMessage); 


            //                    //try
            //                    //{
            //                        bytesRead = stream.Read(receiveMessage, 0, receiveMessage.Length);
            //                    //}
            //                    //catch
            //                    //{
            //                    //    break;
            //                    //}
            //                    //if (bytesRead == 0)
            //                    //{
            //                    //break;
            //                    //}
            //                    data = Encoding.ASCII.GetString(receiveMessage, 0, bytesRead);
            //                    Console.WriteLine("Received: {0}", data);
            //            }
            //            client.Close();
            //        }
            //        catch (Exception exception)
            //        {
            //            Console.WriteLine("Error...." + exception.StackTrace);
            //        }
            //        Console.ReadLine();
            //    }

            //    //public void CheckEndLoop()

            //    // {

            //    // }
            //}
        }
    }
}