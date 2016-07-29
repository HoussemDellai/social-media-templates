using Xamarin.Forms;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class TwitterViewPage : ContentPage
    {

        public TwitterViewPage()
        {

            Title = "Twitter";
            BackgroundColor = Color.White;

            var twitterViewModel = new TwitterViewModel();

            BindingContext = twitterViewModel;

            var label = new Label
            {
                Text = "Tweets",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {
                var screenNameLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 22
                };
                var textLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 18
                };
                var image = new Image
                {
                    WidthRequest = 60,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start
                };
                var mediaImage = new Image();

                screenNameLabel.SetBinding(Label.TextProperty, new Binding("ScreenName"));
                textLabel.SetBinding(Label.TextProperty, new Binding("Text"));
                image.SetBinding(Image.SourceProperty, new Binding("ImageUrl"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("MediaUrl"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 5),
                        Children =
                        {
                            image,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    screenNameLabel,
                                    textLabel,
                                    mediaImage
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

            listView.SetBinding(ListView.ItemsSourceProperty, "Tweets");

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

// if you prefer to work with XAML code, 
// use the following which is similar to the above code
//
//<ContentPage.BindingContext>
//   <viewModels:TwitterViewModel/>
// </ContentPage.BindingContext>

// <StackLayout Padding = "5,10"
//              BackgroundColor="White">

//   <Label Text = "Tweets"
//          TextColor="Black"
//          FontSize="22"/>

//   <ListView ItemsSource = "{Binding Tweets}"
//             HasUnevenRows="True">
//     <ListView.ItemTemplate>
//       <DataTemplate>
//         <ViewCell>

//           <StackLayout Orientation = "Horizontal" >
//             < Image Source="{Binding ImageUrl}"
//                    WidthRequest="60"
//                    HeightRequest="60"
//                    VerticalOptions="Start"/>
             
//             <StackLayout Orientation = "Vertical" >
//               < Label Text="{Binding ScreenName}"
//                      TextColor="#2196F3"
//                      FontSize="22"/>
//               <Label Text = "{Binding Text}"
//                   TextColor="Black"
//                   FontSize="18"/>
//               <Image Source = "{Binding MediaUrl}" />
//             </ StackLayout >
//           </ StackLayout >


//         </ ViewCell >
//       </ DataTemplate >
//     </ ListView.ItemTemplate >
//   </ ListView >
// </ StackLayout >