using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Server
{
    class Client : IComparable
    {
        Guid clientNumber;
        string userName;
        string clientSocket;
        NetworkStream clientStream;
      
        public Client(string clientSocket, NetworkStream stream, string userName)
        {
            this.clientNumber = Guid.NewGuid();
            this.clientSocket = clientSocket;
            this.clientStream = stream;
            this.userName = userName;
        }
        public Guid ClientNumber
        {
            get { return clientNumber; }
            set { clientNumber = value; }
        }
        public string ClientSocket
        {
            get { return clientSocket; }
        }
        public override string ToString()
        {
            return Convert.ToString("Client Socket: " + clientSocket + "  Client Number: " + clientNumber);  //add username once that's worked out
        }

        public int CompareTo(object client)
        {
            Client otherClient = (Client)client;
            return this.clientNumber.CompareTo(otherClient.clientNumber);

        }

        public void Send(string message)
        {
            string fullMessage = userName + message;
            byte[] bytesTo = Encoding.ASCII.GetBytes(message);
            clientStream.Write(bytesTo, 0, bytesTo.Length);
            clientStream.Flush();
        }
    }
} 


