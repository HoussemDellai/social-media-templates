using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XamarinForms.Eventbrite.Models;
using XamarinForms.Services;

namespace XamarinForms.ViewModels
{
    public class EventbriteViewModel : INotifyPropertyChanged
    {

        private EventbriteEvents _eventbriteEvents;

        public EventbriteEvents EventbriteEvents
        {
            get { return _eventbriteEvents; }
            set
            {
                _eventbriteEvents = value; 
                OnPropertyChanged();
            }
        }

        public EventbriteViewModel()
        {

            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            
            var eventbriteService = new EventbriteService();

            EventbriteEvents = await eventbriteService.GetEventsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
