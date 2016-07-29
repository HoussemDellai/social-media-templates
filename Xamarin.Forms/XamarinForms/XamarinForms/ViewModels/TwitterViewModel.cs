using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LinqToTwitter;
using XamarinForms.Models;

namespace XamarinForms.ViewModels
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
                    // Please use this link to create a new app in Twitter
                    // https://apps.twitter.com/app/new
                    // so you can get ConsumerKey and ConsumerSecret
                    //ConsumerKey = "******",
                    //ConsumerSecret = "*******",
                    ConsumerKey = "kpq2mqKjL6mKWKlpwkBWKiOQi",
                    ConsumerSecret = "ac9bOcnvSTRU8fEc1Woom4n5c0zlf5iuaoO7gMnsfS4wOK0YDF",
                },
            };

            await auth.AuthorizeAsync();

            var ctx = new TwitterContext(auth);

            var tweets = await
                (from tweet 
                 in ctx.Status
                 where tweet.Type == StatusType.User 
                       && tweet.ScreenName == "HoussemDellai"
                       && tweet.Count == 30
                 select tweet)
                .ToListAsync();

            Tweets = (from tweet 
                      in tweets
                      select new Tweet
                      {
                          StatusID = tweet.StatusID,
                          ScreenName = tweet.User.ScreenNameResponse,
                          Text = tweet.Text,
                          ImageUrl = tweet.User.ProfileImageUrl,
                          MediaUrl = tweet?.Entities?.MediaEntities?.FirstOrDefault()?.MediaUrl
                      })
                .ToList();

            //Search searchResponse = await
            //    (from search in ctx.Search
            //     where search.Type == SearchType.Search &&
            //           search.Query == "VisualStudio"
            //     select search)
            //    .SingleAsync();

            //Tweets =
            //    (from tweet in searchResponse.Statuses
            //     select new Tweet
            //     {
            //         StatusID = tweet.StatusID,
            //         ScreenName = tweet.User.ScreenNameResponse,
            //         Text = tweet.Text,
            //         ImageUrl = tweet.User.ProfileImageUrl
            //     })
            //    .ToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
