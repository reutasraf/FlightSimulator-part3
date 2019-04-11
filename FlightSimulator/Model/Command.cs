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
        NetworkStream ns;

        public Command(){
            this.setNewMap();
            }


        public void connectServer()
        {

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            this.client = new TcpClient();
            this.client.Connect(ep);
            Console.WriteLine("You are connected");
            this.ns = client.GetStream();

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

        public void setAoutInfo(List <List<string>> path)
        {
                if (path.Count != 0)
                {
                    using (NetworkStream stream = new NetworkStream(client.Client, false))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        while (path.Count != 0)
                        {
                            List<string> thePath = path[0];
                            thePath.Add("\r\n");
                            path.RemoveAt(0);
                        string realPath = "";
                        int i = 0;
                        while (thePath.Count>0)
                        {
                            realPath = realPath + thePath[i];
                            i++;

                        }
                            byte[] data = System.Text.Encoding.ASCII.GetBytes(realPath);
                            Console.WriteLine(realPath);
                            writer.Write(data);
                            writer.Flush();
                        //wait two sec
                            Thread.Sleep(2000);
                        }
                    }
                }
                
            


        }

    }
}

