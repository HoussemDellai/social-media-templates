using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinForms.Models;

namespace XamarinForms.ViewModels
{
    public class InstagramViewModel : INotifyPropertyChanged
    {
        private List<InstagramItem> _instagramItems;

        public List<InstagramItem> InstagramItems
        {
            get { return _instagramItems; }
            set
            {
                _instagramItems = value;
                OnPropertyChanged();
            }
        }

        public InstagramViewModel()
        {
            InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(
                "https://www.instagram.com/xamarinhq/media/"
                        //"https://api.instagram.com/v1/users/469744406/media/recent?client_id=88a92ed981d74235a5a2be3cf549cb59"
                        );

            JObject response = JsonConvert.DeserializeObject<dynamic>(json);

            var items = response.Value<JArray>("items");

            try
            {

                var instagramItems = new List<InstagramItem>();

                foreach (var item in items)
                {
                    var instagramItem = new InstagramItem
                    {
                        UserName = item.Value<JObject>("user").Value<string>("username"),
                        FullName = item.Value<JObject>("user").Value<string>("full_name"),
                        ProfilePicture = item.Value<JObject>("user").Value<string>("profile_picture"),
                        LowResolutionUrl = item.Value<JObject>("images").Value<JObject>("low_resolution").Value<string>("url"),
                        StandardResolutionUrl = item.Value<JObject>("images").Value<JObject>("standard_resolution").Value<string>("url"),
                        ThumbnailUrl = item.Value<JObject>("images").Value<JObject>("thumbnail").Value<string>("url"),
                        Text = item.Value<JObject>("caption").Value<string>("text"),
                        CreatedTime = item.Value<JObject>("caption").Value<string>("created_time"),
                        LikesCount = item.Value<JObject>("likes").Value<int>("count"),
                        CommentsCount = item.Value<JObject>("comments").Value<int>("count"),
                    };

                    instagramItems.Add(instagramItem);
                }

                InstagramItems = instagramItems;
            }
            catch (Exception exception)
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}