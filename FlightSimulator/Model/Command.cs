using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;


using System.Net;
using System.IO;

namespace FlightSimulator
{
    public class Command
    {

        public Dictionary<string, double> pathRead = new Dictionary<string, double>();
        public Dictionary<string, string> dict = new Dictionary<string, string>();
        TcpClient client;
        TcpListener server;
        NetworkStream ns;
        private bool IsConnect;
       

        public Command(){

            IsConnect = false;
            this.setNewMap();
            }


        public void connectServer()
        {
            
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            this.server = new TcpListener(ep);
            this.client = new TcpClient();
            this.client.Connect(ep);
              Console.WriteLine("You are connected");
            this.ns = client.GetStream();
            this.IsConnect = true;

        }
        public  bool GetIsConnect()
        {
            return this.IsConnect;
        }

        
    
        private void setNewMap()
        {
            this.dict.Add("aileron","/controls/flight/aileron" );
            this.dict.Add("elevator","/controls/flight/elevator");
            this.dict.Add("rudder","/controls/flight/rudder");
            this.dict.Add("throttle","/controls/engines/current-engine/throttle");
        }

        public void setInfo(List<string> path)
        {
            string p = "set ";
            p =p+ this.dict[path[0]];
            p = p + " ";
            p=p+ path[1];
            p = p + "\r\n";

            byte[] byteTime = Encoding.ASCII.GetBytes(p.ToString());    
            this.ns.Write(byteTime, 0, byteTime.Length);

        }

        public void setAoutInfo(List <List<string>> s)
        {
            {

                Thread thread = new Thread(() =>
                {
                    if (s.Count != 0)
                    {
                        using (NetworkStream stream = new NetworkStream(this.client.Client, false))
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {

                            while (s.Count != 0)
                            {
                                List<string> temp = s[0];
                                temp.Add("\r\n");
                                s.RemoveAt(0);
                                string path = this.Concat(temp);

                                byte[] data = System.Text.Encoding.ASCII.GetBytes(path);
                                Console.WriteLine(path);
                                writer.Write(data);
                                writer.Flush();
                                Thread.Sleep(2000);
                            }
                        }
                    }


                }); thread.Start();
            }
        }

        private string Concat(List<String> thePath)
        {
            string r = "";
            for (int i = 0; i < thePath.Count; i++)
            {
                r += thePath[i];
            }
            return r;
        }


        public void close()
        {
            this.client.Close();
            this.server.Stop();
        }

    }
}

