using Xamarin.Forms;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class InstagramViewPage : ContentPage
    {

        public InstagramViewPage()
        {
            Title = "Instagram";

            BackgroundColor = Color.White;

            var twitterViewModel = new InstagramViewModel();

            BindingContext = twitterViewModel;

            var label = new Label
            {
                Text = "Instagram",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {
                var screenNameLabel = new Label
                {
                    TextColor = Color.FromHex("#1c5380"),
                    FontSize = 22
                };
                var textLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 14
                };
                var likesLabel = new Label
                {
                    TextColor = Color.FromHex("#517fa4"),
                    FontSize = 14
                };
                var commentsLabel = new Label
                {
                    TextColor = Color.FromHex("#517fa4"),
                    FontSize = 14
                };
                var profileImage = new Image
                {
                    WidthRequest = 60,
                    HeightRequest = 60,
                    VerticalOptions = LayoutOptions.Start
                };
                var mediaImage = new Image
                {
                    HeightRequest = 200
                };

                screenNameLabel.SetBinding(Label.TextProperty, new Binding("UserName"));
                textLabel.SetBinding(Label.TextProperty, new Binding("Text"));
                profileImage.SetBinding(Image.SourceProperty, new Binding("ProfilePicture"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("StandardResolutionUrl"));
                likesLabel.SetBinding(Label.TextProperty, new Binding("LikesCount", BindingMode.Default, null, null, "{0:n0} likes |"));
                commentsLabel.SetBinding(Label.TextProperty, new Binding("CommentsCount", BindingMode.Default, null, null, "{0:n0} likes"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 5),
                        Children =
                        {
                            profileImage,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    screenNameLabel,
                                    new StackLayout
                                    {
                                        Orientation = StackOrientation.Horizontal,
                                        Children =
                                        {
                                            likesLabel,
                                            commentsLabel,
                                        }
                                    },
                                    textLabel,
                                    mediaImage,
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

            listView.SetBinding(ListView.ItemsSourceProperty, "InstagramItems");

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


//  <ContentPage.BindingContext>
//    <viewModels:InstagramViewModel/>
//  </ContentPage.BindingContext>

//  <StackLayout Padding = "5,10"
//               BackgroundColor="White">

//    <Label Text = "Instagram"
//           TextColor="Black"
//           FontSize="22"/>

//    <ListView ItemsSource = "{Binding InstagramItems}"
//              HasUnevenRows="True">
//      <ListView.ItemTemplate>
//        <DataTemplate>
//          <ViewCell>

//            <StackLayout Orientation = "Horizontal" >
//              < Image Source="{Binding ProfilePicture}"
//                     WidthRequest="60"
//                     HeightRequest="60"
//                     VerticalOptions="Start"/>

//              <StackLayout Orientation = "Vertical" >
//                < Label Text="{Binding UserName}"
//                       TextColor="#1c5380"
//                       FontSize="22"/>
//                <StackLayout Orientation = "Horizontal" >
//                  < Label Text="{Binding LikesCount, StringFormat='{0:n0} likes | '}"
//                         TextColor="#517fa4"
//                         FontSize="14"/>
//                  <Label Text = "{Binding CommentsCount, StringFormat='{0:n0} comments'}"
//                         TextColor="#517fa4"
//                         FontSize="14"/>
//                </StackLayout>
//                <Label Text = "{Binding Text}"
//                       TextColor="Black"
//                       FontSize="18"/>
//                <Image Source = "{Binding StandardResolutionUrl}"
//                       HeightRequest="200"/>

//              </StackLayout>
//            </StackLayout>

//          </ViewCell>
//        </DataTemplate>
//      </ListView.ItemTemplate>
//    </ListView>
//  </StackLayout>