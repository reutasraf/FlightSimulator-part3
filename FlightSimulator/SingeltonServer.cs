using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator
{
    //singelton class to the server
    class SingeltonServer
    {

        private static Server m_Instance = null;
        public static Server Instance
        {
            get
            {
                //if not exist create it
                if (m_Instance == null)
                {
                    m_Instance = new Server();
                }
                return m_Instance;
            }
        }
    }
}

