using System.Windows.Input;
using WichtelApp.Commands;

namespace WichtelApp.UI
{
    public class MainViewModel
    {
        private ICommand myTestCommand = new TestCommand();
        private ICommand mySendTestMailCommand = new SendTestMailCommand();
        private ICommand mySendCommand = new SendMailsCommand();

        public ICommand TestCommand => this.myTestCommand;

        public ICommand SendTestMailCommand => this.mySendTestMailCommand;

        public ICommand SendCommand => this.mySendCommand;
    }
}
