using Xamarin.Forms;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class EventbriteViewPage : ContentPage
    {

        public EventbriteViewPage()
        {

            Title = "Eventbrite";
            BackgroundColor = Color.White;

            var foursquareViewModel = new EventbriteViewModel();

            BindingContext = foursquareViewModel;

            var pageTitleLabel = new Label
            {
                Text = "Eventbrite",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {

                var eventNameLabel = new Label
                {
                    TextColor = Color.FromHex("#FF8832"),
                    FontSize = 20
                };
                eventNameLabel.SetBinding(Label.TextProperty, new Binding("Name.Text"));

                var eventStartLabel = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14
                };
                eventStartLabel.SetBinding(Label.TextProperty, new Binding("Start.Utc"));

                var eventEndLabel = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14
                };
                eventEndLabel.SetBinding(Label.TextProperty, new Binding("End.Utc"));

                var eventDescriptionLabel = new Label
                {
                    FontSize = 14,
                    TextColor = Color.Black,
                    HeightRequest = 100,
                };
                eventDescriptionLabel.SetBinding(Label.TextProperty, new Binding("Description.Text"));

                var eventAddressLabel = new Label
                {
                    FontSize = 14,
                    TextColor = Color.Gray,
                };
                eventAddressLabel.SetBinding(Label.TextProperty,
                    new Binding("Venue.Address.Localized_Address_Display"));

                var logoImage = new Image
                {
                    WidthRequest = 120,
                    HeightRequest = 65,
                    VerticalOptions = LayoutOptions.Start,
                };
                logoImage.SetBinding(Image.SourceProperty, new Binding("Logo.Url"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(0, 5, 0, 10),
                        Children =
                        {
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    logoImage,
                                    eventNameLabel,
                                }
                            },
                            eventAddressLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    eventStartLabel,
                                    eventEndLabel
                                }
                            },
                            eventDescriptionLabel,
                        }
                    }
                };
            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "EventbriteEvents.Events");

            listView.ItemTemplate = dataTemplate;

            Content = new StackLayout
            {
                Padding = new Thickness(5, 10),
                Children =
                {
                    pageTitleLabel,
                    listView
                }
            };
        }
    }
}