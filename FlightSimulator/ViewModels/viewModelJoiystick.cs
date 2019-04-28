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
        
        //the Elevator property
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
                //check if connect alreadyand than set the info
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

                //check if connect alreadyand than set the info
                if (SingeltonCommand.Instance.GetIsConnect())
                {
                    SingeltonCommand.Instance.setInfo(list);
                }
                

            } }
        //the Throttle property
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

        //the aileron property
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
            
            string val = e.NewValue.ToString();
            this.Rudder = val;
        }
    }
}
