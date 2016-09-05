using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

using System.IO;

namespace Server
{
    public class ClientManager
    {
        
        byte[] bytesFrom = new byte[10025];
        string dataFromClient = null;
        string userName;
        
        TcpClient clientSocket;
        NetworkStream clientStream;


        Queue<string> messages = new Queue<string>();
        Tree<Client> TreeOfClients = new Tree<Client>();
        List<Client> clients = new List<Client>();


        public void startHandlingClient(TcpClient clientSocket)
        {
            this.clientSocket = clientSocket;
            clientStream = clientSocket.GetStream();
            Thread handleClient = new Thread(new ThreadStart(HandleClient));
            handleClient.Start();
        }
        public void HandleClient()
        {  
            ReceiveUserName();
            Client client = new Client(Convert.ToString(clientSocket), clientStream, userName);
            clients.Add(client);
            TreeOfClients.Insert(client);
            DoChat();
            //Thread clientChatThread = new Thread(new ThreadStart(DoChat));
            //clientChatThread.Start();
        }

        public void ReceiveUserName()
        {
            ReceiveMessage();

            userName = dataFromClient.Substring(20);
                
        }

        private void DoChat()

        {
            string quitMessage = userName + ": EXIT";
            try
            {
                while (true)
                {
                    ReceiveMessage();
                    if (dataFromClient.ToUpper() == quitMessage)
                    {
                        break;
                    }
                    messages.Enqueue(dataFromClient);
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

        }
    
        private void ReceiveMessage()
        {       
            int bytesRead = 0;

            

            bytesRead = clientStream.Read(bytesFrom, 0, bytesFrom.Length);
                   
            dataFromClient = Encoding.ASCII.GetString(bytesFrom, 0, bytesRead);

            Console.WriteLine("Received: {0}", dataFromClient);
                 
        }
                
        public void SendToAll()
        {
            while (true)
            {
                if (messages.Count > 0)
                {
                    string message = messages.Dequeue();

                    foreach (Client client in clients)
                    {
                        
                      
                        client.Send(message);
                        
                    }
                   }
                }
            }
        }
    }

  

