using Xamarin.Forms;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class FlickrViewPage : ContentPage
    {

        public FlickrViewPage()
        {

            Title = "Flickr";
            BackgroundColor = Color.White;

            var flickrViewModel = new FlickrViewModel();

            BindingContext = flickrViewModel;

            var label = new Label
            {
                Text = "Flickr",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {
                var screenNameLabel = new Label
                {
                    TextColor = Color.FromHex("#009688"),
                    FontSize = 22
                };
                var titleLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 16
                };
                var descriptionLabel = new Label
                {
                    TextColor = Color.Gray,
                    FontSize = 14
                };
                var viewsLabel = new Label
                {
                    TextColor = Color.FromHex("#00897B"),
                    FontSize = 14
                };
                var ownerImage = new Image
                {
                    WidthRequest = 60,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start
                };
                var mediaImage = new Image
                {
                    HeightRequest = 200
                };

                screenNameLabel.SetBinding(Label.TextProperty, new Binding("OwnerName"));
                titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
                descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
                ownerImage.SetBinding(Image.SourceProperty, new Binding("OwnerImageUrl"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("MediumImageUrl"));
                viewsLabel.SetBinding(Label.TextProperty, new Binding("Views", BindingMode.Default, null, null, "{0:n0} views"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 5),
                        Children =
                        {
                            ownerImage,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    screenNameLabel,
                                    viewsLabel,
                                    titleLabel,
                                    mediaImage,
                                    descriptionLabel,
                                }
                            }
                        }
                    }
                };
            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "FlickrItems");

            listView.ItemTemplate = dataTemplate;

            Content = new StackLayout
            {
                Padding = new Thickness(5, 10),
                Children =
                {
                    label,
                    listView
                }
            };
        }
    }
}

///// if you prefer to work with XAML code, 
///// use the following which is similar to the above code


// <ContentPage.BindingContext>
//   <viewModels:FlickrViewModel/>
// </ContentPage.BindingContext>

// <StackLayout Padding = "5,10"
//              BackgroundColor="White">

//   <Label Text = "Flickr"
//          TextColor="Black"
//          FontSize="22"/>

//   <ListView ItemsSource = "{Binding FlickrItems}"
//             HasUnevenRows="True">
//     <ListView.ItemTemplate>
//       <DataTemplate>
//         <ViewCell>

//           <StackLayout Orientation = "Horizontal" >
//             < Image Source="{Binding OwnerImageUrl}"
//                    WidthRequest="60"
//                    HeightRequest="60"
//                    VerticalOptions="Start"/>

//             <StackLayout Orientation = "Vertical" >
//               < Label Text="{Binding OwnerName}"
//                      TextColor="#1c5380"
//                      FontSize="22"/>
//               <Label Text = "{Binding Views, StringFormat='{0:n0} views'}"
//                      TextColor="#517fa4"
//                      FontSize="14"/>
//               <Label Text = "{Binding Title}"
//                      TextColor="Black"
//                      FontSize="16"/>
//               <Image Source = "{Binding MediumImageUrl}"
//                      HeightRequest="200"/>
//               <Label Text = "{Binding Description}"
//                      TextColor="Gray"
//                      FontSize="14"/>
//             </StackLayout>
//           </StackLayout>

//         </ViewCell>
//       </DataTemplate>
//     </ListView.ItemTemplate>
//   </ListView>
// </StackLayout>