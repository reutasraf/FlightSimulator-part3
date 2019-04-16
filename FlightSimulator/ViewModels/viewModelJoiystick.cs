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
        private double aileron;
        private double elevator;
        private string rudder;
        private string throttle;
        //private Command command=new Command();
         
        

        public double Elevator {
            get
            {
                return elevator;
            }
            set
            {
                List<string> arg = new List<string>();
                elevator = value;
                if (elevator < -1)
                {
                    elevator = -1;
                }
                else if (elevator > 1)
                {
                    elevator = 1;
                }

                arg.Add("elevator");
                arg.Add(elevator.ToString());

                if (SingeltonCommand.Instance.GetIsConnect())
                {
                    SingeltonCommand.Instance.setInfo(arg);
                }


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


        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                List<string> arg = new List<string>();
                aileron = value;
                if (aileron < -1)
                {
                    aileron = -1;
                }
                else if (aileron > 1)
                {
                    aileron = 1;
                }

                arg.Add("aileron");
                arg.Add(aileron.ToString());

                if (SingeltonCommand.Instance.GetIsConnect())
                {
                    SingeltonCommand.Instance.setInfo(arg);
                }
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
