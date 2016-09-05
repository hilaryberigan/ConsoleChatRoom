using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Client
{
    class ClientConnection
    {
        IPAddress ipAddress = IPAddress.Parse("192.168.1.76");
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream;
        string userName;

        byte[] receiveMessage = new byte[256];
        string data = null;
        public void Connect()
        {
            try
            {
                Console.WriteLine("Connecting....");

                clientSocket.Connect(ipAddress, 8888);

                Console.WriteLine("Connected");



                Thread receivingThread = new Thread(new ThreadStart(ReceiveMessages));
                receivingThread.Start();

                //start chat 
              
            }

            catch (Exception exception)
            {
                Console.WriteLine("Error...." + exception.StackTrace);
                Console.ReadLine();
            }
        }


            public void SetUp()
            {
            stream = clientSocket.GetStream();

            Console.WriteLine("Welcome to ChatterBox.\nPLease enter a username with only letters and numbers:");
            userName = Console.ReadLine();
            SendMessage("New Client Username: " + userName);

            Console.WriteLine("Press {Enter} to join the chat room");
            Console.ReadLine();
            Console.Clear();
           
            
            }

            public void DoChat()
            {
            Console.WriteLine("Thank you for joining the chat. Type your message and press {enter} to send. Type the word 'exit' at any time to quit.");
            

            while (true)
            {

                string chatMessage = Console.ReadLine();
                SendMessage(userName + ": " + chatMessage);
              
                if (chatMessage.ToUpper() == "EXIT")
                {
                    break;
                }
            }
       
        }            
        
        public void SendMessage(string message)

        {
            try
            {
                //Console.Write("Entry: ");                

                //string sendMessage = fullMessage.Substring(7);

                byte[] bytes = Encoding.ASCII.GetBytes(message);

                stream.Write(bytes, 0, bytes.Length);

                //Console.WriteLine("Sent: {0}", sendMessage);
            }
            catch(Exception exception)
            {
                Console.WriteLine("Error...." + exception.StackTrace);
            }
        }


        public void ReceiveMessages()

        {
 
            try
            {
                while (clientSocket.Connected)
                {
                    int bytesRead = stream.Read(receiveMessage, 0, receiveMessage.Length);
                    data = Encoding.ASCII.GetString(receiveMessage, 0, bytesRead);
                    Console.WriteLine("{0}", data);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error...." + exception.StackTrace);
            }
            Console.ReadLine();
        }
    }
}