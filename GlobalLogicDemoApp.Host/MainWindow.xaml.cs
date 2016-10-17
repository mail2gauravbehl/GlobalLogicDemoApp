using System.Windows;
using GlobalLogigDemoApp.Services;

namespace GlobalLogicDemoApp.Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TODO: Can be injected through DI container
            IPostsRepository postsRepository = new PostsRepository();
            DataContext = new MainViewModel(postsRepository);
        }
    }
}
