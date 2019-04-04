using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public string Elevator {
            set { this.elevator = value;
                command.setInfo("gg");
            }
            
        }
        public string Rudder { set { this.rudder= value; } }
        public string Throttle {
            set { this.throttle = value;
                
            }
        }

        public string Aileron
        {
            set { this.aileron = value;
                
            }
        }
    }
}
