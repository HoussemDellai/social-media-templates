using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinForms.Models;

namespace XamarinForms.ViewModels
{
    public class FlickrViewModel : INotifyPropertyChanged
    {
        private List<FlickrItem> _flickrItems;

        public List<FlickrItem> FlickrItems
        {
            get { return _flickrItems; }
            set
            {
                _flickrItems = value;
                OnPropertyChanged();
            }
        }

        public FlickrViewModel()
        {
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {
            var httpClient = new HttpClient();

            // use this link to get an api_key : https://www.flickr.com/services/apps/create/noncommercial/?
            // use this website to get the user_id : http://idgettr.com/

            var json = await httpClient.GetStringAsync(
                "https://api.flickr.com/services/rest/?&method=flickr.people.getPublicPhotos&api_key=" 
                + "849d1e8d743ee3e67a987227697a4946"
                //+ "YOUR_API_KEY" 
                + "&user_id=105927588@N08&format=json&per_page=15&extras=description,date_upload,owner_name,tags,machine_tags,views,media,path_alias,url_sq,url_m,url_o");

            json = json.Replace("jsonFlickrApi(", "").Replace(")", "");

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var photos = response.Value<JObject>("photos").Value<JArray>("photo");

                var flickrItems = new List<FlickrItem>();

                foreach (var photo in photos)
                {
                    var instagramItem = new FlickrItem
                    {
                        OwnerName = photo.Value<string>("ownername"),
                        PathAlias = photo.Value<string>("pathalias"),
                        Title = photo.Value<string>("title"),
                        Published = photo.Value<string>("dateupload"),
                        SmallImageUrl = photo.Value<string>("url_sq"),
                        MediumImageUrl = photo.Value<string>("url_m"),
                        LargeImageUrl = photo.Value<string>("url_o"),
                        Views = photo.Value<int>("views"),
                        Description = photo.Value<JObject>("description").Value<string>("_content"),
                        OwnerImageUrl = "http://c1.staticflickr.com/" 
                        + photo.Value<string>("farm") 
                        + "/" 
                        + photo.Value<string>("server") 
                        + "/buddyicons/" 
                        + photo.Value<string>("owner") 
                        + "_l.jpg",
                    };

                    flickrItems.Add(instagramItem);
                }

                FlickrItems = flickrItems;
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