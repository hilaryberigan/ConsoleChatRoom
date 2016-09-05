using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Server
{
    class Server
    {
        Thread listenThread;
        TcpListener listener;
        ClientManager clientManager = new ClientManager();
        int counter;


        public void startServer()
        {
            Console.WriteLine("The server is running at port 8888...");

            listener = new TcpListener(IPAddress.Any, 8888);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        public void ListenForClients()
        {
            listener.Start();
            counter = 0;
            Console.WriteLine("Waiting for a connection.....");
            Thread broadcastThread = new Thread(new ThreadStart(clientManager.SendToAll));
            broadcastThread.Start();

            while (true)
            {
                counter += 1;
                TcpClient clientSocket = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");
                Console.WriteLine("Client No: " + Convert.ToString(counter) + " joined.");

                clientManager.startHandlingClient(clientSocket);
                
            }

        }
    }
}
