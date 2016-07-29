using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinForms.Models;

namespace XamarinForms.ViewModels
{
    public class FoursquareViewModel : INotifyPropertyChanged
    {

        // use this link to get an api_key : https://foursquare.com/developers/register/
        private const string ClientId = "0VI3W11FN5LCQTIPASLFUUWSAX515QF4TTY1L4VAKWPPB4IO";
        private const string ClientSecret = "M4ALRFCDHONLXSSULN23EDKDJG14WD2GC00OCADD5KKYAUFO";
        private const string v = "20160611";
        private const string venueId = "40a55d80f964a52020f31ee3";

        // doc : https://developer.foursquare.com/docs/venues/search
        private string apiUrlForVenues = $"https://api.foursquare.com/v2/venues/explore?ll=40.7,-74&client_id={ClientId}&client_secret={ClientSecret}&v={v}&radius=1000&venuePhotos=1";

        private FoursquareVenues _foursquareVenues;

        public FoursquareVenues FoursquareVenues
        {
            get { return _foursquareVenues; }
            set
            {
                _foursquareVenues = value;
                OnPropertyChanged();
            }
        }

        public FoursquareViewModel()
        {
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForVenues);

            FoursquareVenues = JsonConvert.DeserializeObject<FoursquareVenues>(json);
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