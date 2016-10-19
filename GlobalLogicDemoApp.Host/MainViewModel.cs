using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GlobalLogicDemoApp.Host.Annotations;
using GlobalLogigDemoApp.Services;
using GlobalLogigDemoApp.Services.Domain;
using GlobalLogigDemoApp.Services.Enums;
using GlobalLogigDemoApp.Services.Formatter;
using GlobalLogigDemoApp.Services.Repositories;

namespace GlobalLogicDemoApp.Host
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        private readonly IPostsRepository _postrepository;
        private Post _selectedItem;
        private FormatEnum _formatEnum;
        private ICommentsRepository _commentsRepository;
        private string _info;
        private string _comments;
        private IFormatterFactory _formatterFactory;

        public MainViewModel(IPostsRepository postrepository, ICommentsRepository commentsRepository, IFormatterFactory formatterFactory)
        {
            _formatterFactory = formatterFactory;
            _commentsRepository = commentsRepository;
            _postrepository = postrepository;

            PostsCommand = new AsyncCommand<IEnumerable<Post>>(postrepository.GetPosts);
        }

        //public NotifyTaskCompletion<IEnumerable<Post>> Posts { get; set; }
        //public IEnumerable<Post> Posts { get; set; }


        public IAsyncCommand PostsCommand { get; set; }

        public Post SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                    _selectedItem = value;
                    OnPropertyChanged();
                    UpdateAdditionalInfo();
            }
        }

        public FormatEnum FormatEnum 
        {
            get { return _formatEnum; }
            set
            {
                if(_formatEnum == value)
                    return;
                
                _formatEnum = value;
                OnPropertyChanged();
                if (SelectedItem == null)
                    return;
                UpdateAdditionalInfo();
            }
        }


        public string Comment
        {
            get
            {
                return _comments; 
                
            }

            set
            {
                _comments = value;
                 OnPropertyChanged();
            }
        }

        private void UpdateAdditionalInfo()
        {
            var comments = new NotifyTaskCompletion<IEnumerable<Comment>>(_commentsRepository.GetComments(SelectedItem.Id));
            comments.PropertyChanged += comments_PropertyChanged;

           
        }

        void comments_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "Result")
            {

              var comments = ((NotifyTaskCompletion<IEnumerable<Comment>>) sender).Result.ToList();
               Comment = _formatterFactory.GetFormatter(FormatEnum).Convert(comments);
                
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
