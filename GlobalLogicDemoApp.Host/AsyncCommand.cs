using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GlobalLogicDemoApp.Host.Annotations;

namespace GlobalLogicDemoApp.Host
{
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<Task<TResult>> _command;
        private NotifyTaskCompletion<TResult> _execution;
        public AsyncCommand(Func<Task<TResult>> command)
        {
            _command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override Task ExecuteAsync(object parameter)
        {
            if (_command == null)
                return null;
            Execution = new NotifyTaskCompletion<TResult>(_command());
           return Execution.TaskCompletion;
        }

        // Raises PropertyChanged
        public NotifyTaskCompletion<TResult> Execution 
        {
            get { return _execution; }
            private set
            {
                _execution = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}