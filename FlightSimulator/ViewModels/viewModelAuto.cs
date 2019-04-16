using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class viewModelAuto : BaseNotify
    {
        private bool isConnect=false;
        //public Command com=new Command();
        private List<List<string>> myCommands = new List<List<string>>();
        private int count;
        private string data="";
        public viewModelAuto()
        {
            count = 0;
        }
       

        private String fromUser="";
        public String FromUser
        {
            get
            {
                if (!(fromUser == ""))
                {
                    NotifyPropertyChanged("ColorCange");
                }
                return fromUser;
            }
            set
            {
                
                this.data = value;
                fromUser = value;
                NotifyPropertyChanged("FromUser");
                NotifyPropertyChanged("ColorCange");

            }
        }

        private String color;
        public String ColorCange
        {
            get
            {
                if(count== 0)
                {
                    color = "White";
                    count++;
                }
                else if (fromUser == "")
                {
                    color = "White";
                    count++;

                }
                else
                {
                    color = "Pink";
                }
                return color;
            }
            
        }
        private void OkCommand()
        {
            this.Parser(this.data);
            //if (!this.isConnect)
            //{
                  
            //    //SingeltonCommand.Instance.connectServer();
            //    this.isConnect = true;
            //}
            if (SingeltonCommand.Instance.GetIsConnect())
            {
                SingeltonCommand.Instance.setAoutInfo(this.myCommands);
            }
           

        }

        public ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OkCommand()));

            }
        }

        
        private ICommand _clearCommand; 
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => ClickClear()));
            }
        }
        private void ClickClear()
        {
            FromUser = "";
        }
        

        //private ICommand _sendCommand;
        //public ICommand SendCommand
        //{
        //    get
        //    {
        //        return _sendCommand ?? (_sendCommand =
        //        new CommandHandler(() => ClickSend()));
        //    }
        //}
        //private void ClickSend()
        //{
        //    //client.toSimo(commantFromUser);
        //    NotifyPropertyChanged("ColorCange");
        //    CommentFromUser = "";
        //}
        
        //public ICommand WriteCommand
        //{
        //    get
        //    {
        //        return _clearCommand ?? (_clearCommand =
        //        new CommandHandler(() => UserWrite()));
        //    }
        //}
        //private void UserWrite()
        //{

        //}

        private void Parser(string s)
        {
            int listIndex = this.myCommands.Count;
            string temp = "";
            List<string> oneList = new List<string>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (i + 1 == s.Length)
                {
                    temp += s[i];
                    oneList.Add(temp);


                    this.myCommands.Add(oneList);
                    oneList = new List<string>();
                    temp = "";
                    i += 1;
                }

                else if ((s[i] == '\r' && i < s.Length && s[i + 1] == '\n'))
                {

                    if (temp != "")
                    {
                        oneList.Add(temp);

                    }
                    this.myCommands.Add(oneList);
                    //oneList.Clear();
                    oneList = new List<string>();
                    temp = "";
                    i += 1;

                    continue;
                }
                else if (s[i] == ' ')
                {
                    temp = temp + " ";
                    oneList.Add(temp);

                    temp = "";
                }
                else
                {
                    temp += s[i];
                }

            }
        }
    

}


}
