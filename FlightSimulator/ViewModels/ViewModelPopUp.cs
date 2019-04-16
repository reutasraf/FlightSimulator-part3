using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;
namespace FlightSimulator.ViewModels
{
    class ViewModelPopUp
    {
        private ICommand _settingsCommand;
        private bool alredyConnect;

        public ViewModelPopUp()
        {
            this.alredyConnect = false;
        }

        public ICommand SettingsCommand
        {
            get
            {
                Console.WriteLine("_----------------------");
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClick()));
            }
            set
            {

            }
        }
        private void OnClick()
        {
            PopUp p = new PopUp();
            p.ShowDialog();
        }
        private ICommand _listenCommand;
        public ICommand ListenCommand
        {
            get
            {
                return _listenCommand ?? (_listenCommand =
                new CommandHandler(() => ToConnect()));
            }
            set
            {

            }
        }
        private void ToConnect()
        {

            if (!this.alredyConnect)
            {
                SingeltonServer.Instance.openServer();
                SingeltonCommand.Instance.connectServer();
                this.alredyConnect = true;
            }
            else
            {

                SingeltonServer.Instance.openServer();
                SingeltonCommand.Instance.connectServer();
                this.alredyConnect = true;
            }

        }
    }

}
