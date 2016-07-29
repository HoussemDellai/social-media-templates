using Xamarin.Forms;
using XamarinForms.Models;
using XamarinForms.ViewModels;

namespace XamarinForms.Views
{
    public class YoutubeViewPage : ContentPage
    {

        public YoutubeViewPage()
        {

            Title = "Youtube";
            BackgroundColor = Color.White;

            var youtubeViewModel = new YoutubeViewModel();

            BindingContext = youtubeViewModel;

            var label = new Label
            {
                Text = "Youtube",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {

                var channelTitleLabel = new Label
                {
                    TextColor = Color.Maroon,
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
                var viewCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var likeCountLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var dislikeCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var favoriteCountLabel = new Label
                {
                    TextColor = Color.FromHex("#2196F3"),
                    FontSize = 14
                };
                var commentCountLabel = new Label
                {
                    TextColor = Color.FromHex("#0D47A1"),
                    FontSize = 14
                };
                var mediaImage = new Image
                {
                    HeightRequest = 200
                };

                channelTitleLabel.SetBinding(Label.TextProperty, new Binding("ChannelTitle"));
                titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
                descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("HighThumbnailUrl"));
                viewCountLabel.SetBinding(Label.TextProperty, new Binding("ViewCount", BindingMode.Default, null, null, "{0:n0} views"));
                likeCountLabel.SetBinding(Label.TextProperty, new Binding("LikeCount", BindingMode.Default, null, null, "{0:n0} likes"));
                dislikeCountLabel.SetBinding(Label.TextProperty, new Binding("DislikeCount", BindingMode.Default, null, null, "{0:n0} dislike"));
                commentCountLabel.SetBinding(Label.TextProperty, new Binding("CommentCount", BindingMode.Default, null, null, "{0:n0} comments"));
                favoriteCountLabel.SetBinding(Label.TextProperty, new Binding("FavoriteCount", BindingMode.Default, null, null, "{0:n0} favorite"));

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(5, 10),
                        Children =
                        {
                            channelTitleLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    viewCountLabel,
                                    likeCountLabel,
                                    dislikeCountLabel,
                                }
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                TranslationY = -7,
                                Children =
                                {
                                    favoriteCountLabel,
                                    commentCountLabel
                                }
                            },
                            titleLabel,
                            mediaImage,
                            descriptionLabel,
                        }
                    }
                };
            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "YoutubeItems");

            listView.ItemTemplate = dataTemplate;

            listView.ItemTapped += ListViewOnItemTapped;

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

        private void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var youtubeItem = itemTappedEventArgs.Item as YoutubeItem;

            // You can use Plugin.Share nuget package to open video in browser
            //CrossShare.Current.OpenBrowser("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId);
        }
    }
}

///// if you prefer to work with XAML code, 
///// use the following which is similar to the above code


//  <ContentPage.BindingContext>
//    <viewModels:YoutubeViewModel/>
//  </ContentPage.BindingContext>

//  <StackLayout Padding = "5,10"
//               BackgroundColor="White">

//    <Label Text = "Youtube"
//           TextColor="Black"
//           FontSize="22"/>

//    <ListView ItemsSource = "{Binding YoutubeItems}"
//              HasUnevenRows="True">
//      <ListView.ItemTemplate>
//        <DataTemplate>
//          <ViewCell>

//            <StackLayout Orientation = "Vertical"
//                         Padding="10,10,10,20">
//              <Label Text = "{Binding ChannelTitle}"
//                     TextColor="Maroon"
//                     FontSize="22"/>
//              <StackLayout Orientation = "Horizontal" >
//                < Label Text="{Binding ViewCount, StringFormat='{0:n0} views'}"
//                       TextColor="#0D47A1"
//                       FontSize="14"/>
//                <Label Text = "{Binding LikeCount, StringFormat='{0:n0} likes'}"
//                       TextColor="#2196F3"
//                       FontSize="14"/>
//                <Label Text = "{Binding DislikeCount, StringFormat='{0:n0} dislikes'}"
//                         TextColor="#0D47A1"
//                         FontSize="14"/>
//              </StackLayout>
//              <StackLayout Orientation = "Horizontal"
//                           TranslationY="-7">
//                <Label Text = "{Binding FavoriteCount, StringFormat='{0:n0} favorites'}"
//                      TextColor="#2196F3"
//                      FontSize="14"/>
//                <Label Text = "{Binding CommentCount, StringFormat='{0:n0} comments'}"
//                       TextColor="#0D47A1"
//                       FontSize="14"/>
//              </StackLayout>
//              <Label Text = "{Binding Title}"
//                     TextColor="Black"
//                     FontSize="16"/>
//              <Image Source = "{Binding HighThumbnailUrl}"
//                     HeightRequest="200"/>
//              <Label Text = "{Binding Description}"
//                     TextColor="Gray"
//                     FontSize="14"/>
//            </StackLayout>

//          </ViewCell>
//        </DataTemplate>
//      </ListView.ItemTemplate>
//    </ListView>
//  </StackLayout>