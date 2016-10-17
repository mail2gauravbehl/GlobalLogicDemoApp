using System.Threading.Tasks;
using System.Windows.Input;

namespace GlobalLogicDemoApp.Host
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}