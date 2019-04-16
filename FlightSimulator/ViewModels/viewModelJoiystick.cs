using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulator.Model;


namespace FlightSimulator.ViewModels
{
    
    public class viewModelJoiystick
    {
        private string aileron;
        private string elevator;
        private string rudder;
        private string throttle;
        //private Command command=new Command();
         
        

        public string Elevator {
            set {
                this.elevator = value;
                //command.setInfo("gg");
                //SingeltonCommand.Instance.setInfo(list);
    
            }
            
        }
        public string Rudder {
            set {
                List<string> list = new List<string>();
                list.Add("rudder");
                list.Add(value);
                //this.rudder= value;
                //SingeltonCommand.Instance.connectServer();
                //if it already connect-set the info
                if (SingeltonCommand.Instance.GetIsConnect())
                {
                    SingeltonCommand.Instance.setInfo(list);
                }
                //command.setInfo(list);

            } }
        public string Throttle {
            set
            {
                List<string> list = new List<string>();
                list.Add("throttle");
                list.Add(value);
                //this.rudder= value;

                //if it already connect-set the info
                if (SingeltonCommand.Instance.GetIsConnect())
                {
                    SingeltonCommand.Instance.setInfo(list);
                }
            }
        }


        public string Aileron
        {
            set { this.aileron = value;
                
            }
        }
        public void SaveSettings1(RoutedPropertyChangedEventArgs<double> e)
        {
            //this.command = new Command();
            //this.command.connectClient();
            string val = e.NewValue.ToString();
            this.Rudder = val;
        }
    }
}
