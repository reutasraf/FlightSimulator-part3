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

        public Command com;
        private List<List<string>> myCommands = new List<List<string>>();
        
        //public viewModelAuto(Command com1)
        //{
        //    this.com = com1;
        //}
        
        private String commantFromUser;
        public String CommentFromUser
        {
            get
            {
                return commantFromUser;
            }
            set
            {
                this.Parser(value.ToString());
                commantFromUser = value;
                NotifyPropertyChanged("CommentFromUser");
               
            }
        }

        private ConsoleColor color;
        public ConsoleColor ColorCange
        {
            get
            {
                return color;
            }
            set
            {
                if (commantFromUser == "")
                {
                    color = ConsoleColor.White;
                }
                else
                {
                    color = ConsoleColor.Red;
                }

            }
        }
        private void OnClick1()
        {
            
        }


        public ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick1()));

            }
            
            set
            {

                com.setInfo(this.myCommands[0]);


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
            CommentFromUser = "";
        }
        

        private ICommand _sendCommand;
        public ICommand SendCommand
        {
            get
            {
                return _sendCommand ?? (_sendCommand =
                new CommandHandler(() => ClickSend()));
            }
        }
        private void ClickSend()
        {
            //client.toSimo(commantFromUser);
            NotifyPropertyChanged("ColorCange");
            CommentFromUser = "";
        }
        
        public ICommand WriteCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                new CommandHandler(() => UserWrite()));
            }
        }
        private void UserWrite()
        {

        }

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
