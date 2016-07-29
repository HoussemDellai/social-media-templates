using Xamarin.Forms;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class FoursquareViewPage : ContentPage
    {

        public FoursquareViewPage()
        {

            Title = "Foursquare";
            BackgroundColor = Color.White;

            var foursquareViewModel = new FoursquareViewModel();

            BindingContext = foursquareViewModel;

            var pageTitleLabel = new Label
            {
                Text = "Foursquare",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {

                var venueNameLabel = new Label
                {
                    TextColor = Color.FromHex("#2d5be3"),
                    FontSize = 22
                };
                var venueRatingLabel = new Label
                {
                    TextColor = Color.White,
                    FontSize = 24
                };
                var checkinsCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var usersCountLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var tipCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var distanceLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var categoriesNameLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var formattedAddress0Label = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14
                };
                var formattedAddress1Label = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14,
                    TranslationY = -5
                };
                var featuredPhotosImage = new Image
                {
                    HeightRequest = 200
                };
                var tipsTextLabel = new Label
                {
                    FontSize = 15,
                    TextColor = Color.Gray,
                };

                venueNameLabel.SetBinding(Label.TextProperty, new Binding("Venue.Name"));
                venueRatingLabel.SetBinding(Label.TextProperty, new Binding("Venue.Rating"));
                checkinsCountLabel.SetBinding(Label.TextProperty, new Binding("Venue.Stats.CheckinsCount", BindingMode.Default, null, null, "{0:n0} checkins"));
                usersCountLabel.SetBinding(Label.TextProperty, new Binding("Venue.Stats.UsersCount", BindingMode.Default, null, null, "{0:n0} users"));
                tipCountLabel.SetBinding(Label.TextProperty, new Binding("Venue.Stats.TipCount", BindingMode.Default, null, null, "{0:n0} tips"));
                distanceLabel.SetBinding(Label.TextProperty, new Binding("Venue.Location.Distance", BindingMode.Default, null, null, "{0:n0} m away"));
                categoriesNameLabel.SetBinding(Label.TextProperty, new Binding("Venue.Categories[0].Name", BindingMode.Default, null, null, "{0:n0} category"));
                formattedAddress0Label.SetBinding(Label.TextProperty, new Binding("Venue.Location.FormattedAddress[0]"));
                formattedAddress1Label.SetBinding(Label.TextProperty, new Binding("Venue.Location.FormattedAddress[1]"));
                tipsTextLabel.SetBinding(Label.TextProperty, new Binding("Tips[0].Text"));
                featuredPhotosImage.SetBinding(Image.SourceProperty, new Binding("Venue.FeaturedPhotos.Items[0].Suffix", BindingMode.Default, null, null, "https://irs1.4sqi.net/img/general/355x200{0}"));


                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(10, 0, 10, 20),
                        Children =
                        {
                            venueNameLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new Grid
                                    {
                                        BackgroundColor = Color.FromHex("#0D47A1"),
                                        Padding = new Thickness(5, 0),
                                        Children =
                                        {
                                            venueRatingLabel
                                        }
                                    },
                                    new StackLayout
                                    {
                                        Orientation = StackOrientation.Vertical,
                                        Children =
                                        {
                                             new StackLayout
                                             {
                                                 Orientation = StackOrientation.Horizontal,
                                                 Children =
                                                 {
                                                     checkinsCountLabel,
                                                     usersCountLabel,
                                                     tipCountLabel
                                                 }
                                             },
                                             new StackLayout
                                             {
                                                 Orientation = StackOrientation.Horizontal,
                                                 TranslationY = -7,
                                                 Children =
                                                 {
                                                     distanceLabel,
                                                     categoriesNameLabel,
                                                 }
                                             }
                                        }
                                    }
                                }
                            },
                            formattedAddress0Label,
                            formattedAddress1Label,
                            featuredPhotosImage,
                            tipsTextLabel,
                            new Grid
                            {
                                HeightRequest = 2,
                                BackgroundColor = Color.Gray
                            }
                        }
                    }
                };
            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "FoursquareVenues.Response.Groups[0].Items");

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

///// if you prefer to work with XAML code, 
///// use the following which is similar to the above code


//  <ContentPage.BindingContext>
//    <viewModels:FoursquareViewModel/>
//  </ContentPage.BindingContext>
//
//  <StackLayout Padding = "5,10"
//               BackgroundColor="White">
//
//    <Label Text = "Foursquare"
//           TextColor="Black"
//           FontSize="22"/>
//
//    <ListView ItemsSource = "{Binding FoursquareVenues.Response.Groups[0].Items}"
//              HasUnevenRows="True">
//      <ListView.ItemTemplate>
//        <DataTemplate>
//          <ViewCell>
//
//            <StackLayout Orientation = "Vertical"
//                       Padding="10,0,10,20">
//              <Label Text = "{Binding Venue.Name}"
//                     TextColor="#2d5be3"
//                     FontSize="22"/>
//              <StackLayout Orientation = "Horizontal" >
//                < Grid BackgroundColor="#0D47A1"
//                      Padding="5,0">
//                  <Label Text = "{Binding Venue.Rating}"
//                         TextColor="White"
//                         FontSize="24"/>
//                </Grid>
//                <StackLayout Orientation = "Vertical" >
//                  < StackLayout Orientation="Horizontal">
//                    <Label Text = "{Binding Venue.Stats.CheckinsCount, StringFormat='{0:n0} checkins'}"
//                           TextColor="#0D47A1"
//                           FontSize="14"/>
//                    <Label Text = "{Binding Venue.Stats.UsersCount, StringFormat='{0:n0} users'}"
//                           TextColor="#2196F3"
//                           FontSize="14"/>
//                    <Label Text = "{Binding Venue.Stats.TipCount, StringFormat='{0:n0} tips'}"
//                             TextColor="#0D47A1"
//                             FontSize="14"/>
//                  </StackLayout>
//                  <StackLayout Orientation = "Horizontal"
//                               TranslationY="-7">
//                    <Label Text = "{Binding Venue.Location.Distance, StringFormat='{0:n0} m away'}"
//                          TextColor="#2196F3"
//                          FontSize="14"/>
//                    <Label Text = "{Binding Venue.Categories[0].Name, StringFormat='{0:n0} category'}"
//                           TextColor="#0D47A1"
//                           FontSize="14"/>
//                  </StackLayout>
//                </StackLayout>
//              </StackLayout>
//              <Label Text = "{Binding Venue.Location.FormattedAddress[0]}"
//                     TextColor="Gray"
//                     FontSize="14"/>
//              <Label Text = "{Binding Venue.Location.FormattedAddress[1]}"
//                     TextColor="Gray"
//                     FontSize="14"
//                     TranslationY="-5"/>
//              <Image Source = "{Binding Venue.FeaturedPhotos.Items[0].Suffix, StringFormat='https://irs1.4sqi.net/img///general/355x200{0}'}"
//                     HeightRequest="200"/>
//              <Label Text = "{Binding Tips[0].Text}"
//                     TextColor="Gray"
//                     FontSize="15"/>
//              <Grid HeightRequest = "2"
//                    BackgroundColor="Gray"/>
//            </StackLayout>
//
//          </ViewCell>
//        </DataTemplate>
//      </ListView.ItemTemplate>
//    </ListView>
//  </StackLayout>