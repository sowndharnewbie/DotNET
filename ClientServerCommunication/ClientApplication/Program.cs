using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverIp="127.0.0.1";
            int port = 8080;
            try
            {
                TcpClient client = new TcpClient(serverIp,port);
                Console.WriteLine("Connected to the server");

                NetworkStream stream= client.GetStream();

                while (true)
                {
                    Console.WriteLine("Enter a msg: ");
                    string msg =Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    stream.Write(data, 0, data.Length);

                    if (msg.ToLower() == "close")
                    {
                        Console.WriteLine("Closing the connection as requested.");
                        break;
                    }

                    byte[] buffer = new byte[256];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received:{response}");
                }

                client.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
