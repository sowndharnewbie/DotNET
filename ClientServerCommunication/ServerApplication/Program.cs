using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApplication
{
 
    class Program
    {
        
        public static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int port = 8080;
                //IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                IPAddress localAddress = IPAddress.Any;

                server = new TcpListener(localAddress, port);

                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected");

                    NetworkStream stream = client.GetStream();

                    while (true)
                    {

                        byte[] data = new byte[256];
                        int bytesRead = stream.Read(data, 0, data.Length);
                        string message = Encoding.ASCII.GetString(data, 0, bytesRead);
                        Console.WriteLine($"Received:{message}");

                        if (message.ToLower()=="close")
                        {
                            Console.WriteLine("Closing the connection");
                            break;
                        }
                        Console.WriteLine("Enter a response: ");
                        string serverInput=Console.ReadLine();
                        byte[] response = Encoding.ASCII.GetBytes(serverInput);
                        stream.Write(response, 0, response.Length);
                    }
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Stop();
                Console.ReadKey();
            }
        }

       

    }
}
