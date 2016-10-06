using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GlobalLogicDemoApp.Host.Annotations;
using GlobalLogigDemoApp.Services;

namespace GlobalLogicDemoApp.Host
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IPostsRepository _postrepository;
        //private NotifyTaskCompletion<IEnumerable<Post>> _notifyTaskCompletion;

        public MainViewModel(IPostsRepository postrepository)
        {
            _postrepository = postrepository;
            //Posts = new NotifyTaskCompletion<IEnumerable<Post>>(postrepository.GetPosts());

            PostsCommand = new AsyncCommand<IEnumerable<Post>>(postrepository.GetPosts);
        }

        //public NotifyTaskCompletion<IEnumerable<Post>> Posts { get; set; }
        //public IEnumerable<Post> Posts { get; set; }

        private Post _selectedItem;
        public IAsyncCommand PostsCommand { get; set; }

        public Post SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                    _selectedItem = value;
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
