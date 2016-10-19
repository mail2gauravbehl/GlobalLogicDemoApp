using System.Windows;
using GlobalLogigDemoApp.Services;
using GlobalLogigDemoApp.Services.Domain;
using GlobalLogigDemoApp.Services.Formatter;
using GlobalLogigDemoApp.Services.Repositories;

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
            ICommentsRepository commentsRepository = new CommentsRepository();
            IFormatterFactory formatterFactory = new FormatterFactory();
            DataContext = new MainViewModel(postsRepository, commentsRepository, formatterFactory);
        }
    }
}
