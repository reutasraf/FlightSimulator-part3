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
        private Command command;

        public viewModelJoiystick(Command com1)
        {
            this.command = com1;
        }

        public string Elevator {
            set { this.elevator = value;
                //command.setInfo("gg");
            }
            
        }
        public string Rudder {
            set {
                List<string> list = new List<string>();
                list.Add("rudder");
                list.Add(value);
                this.rudder= value;
                command.setInfo(list);


            } }
        public string Throttle {
            set { this.throttle = value;
                
            }
        }

        public string Aileron
        {
            set { this.aileron = value;
                
            }
        }
        public void SaveSettings1(RoutedPropertyChangedEventArgs<double> e)
        {
            this.command = new Command();
            //this.command.connectClient();
            string val = e.NewValue.ToString();
            this.Rudder = val;
        }
    }
}
