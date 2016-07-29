using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LinqToTwitter;
using $rootnamespace$.Models;

namespace $rootnamespace$.ViewModels
{
    public class TwitterViewModel : INotifyPropertyChanged
    {

        private List<Tweet> _tweets;
        public List<Tweet> Tweets
        {
            get { return _tweets; }
            set
            {
                if (_tweets == value)
                    return;

                _tweets = value;
                OnPropertyChanged();
            }
        }

        public TwitterViewModel()
        {
            InitTweetsAsync();
        }

        public async Task InitTweetsAsync()
        {

            var auth = new ApplicationOnlyAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "kpq2mqKjL6mKWKlpwkBWKiOQi",
                    ConsumerSecret = "ac9bOcnvSTRU8fEc1Woom4n5c0zlf5iuaoO7gMnsfS4wOK0YDF",
                },
            };

            await auth.AuthorizeAsync();

            var ctx = new TwitterContext(auth);

            Search searchResponse = await
                (from search in ctx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == "Twitter"
                 select search)
                .SingleAsync();

            Tweets =
                (from tweet in searchResponse.Statuses
                 select new Tweet
                 {
                     StatusID = tweet.StatusID,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text,
                     ImageUrl = tweet.User.ProfileImageUrl
                 })
                .ToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
