using System.Windows.Input;
using WichtelApp.Commands;

namespace WichtelApp.UI
{
    public class MainViewModel
    {
        private ICommand myTestTombolaCommand = new TestTombolaCommand();
        private ICommand mySendTestMailCommand = new SendTestMailCommand();
        private ICommand mySendCommand = new SendMailsCommand();

        public ICommand TestTombolaCommand => this.myTestTombolaCommand;

        public ICommand SendTestMailCommand => this.mySendTestMailCommand;

        public ICommand SendCommand => this.mySendCommand;
    }
}
