using System.Collections.Generic;

namespace XamarinForms.Models
{

    public class Meta
    {
        public int Code { get; set; }
        public string RequestId { get; set; }
    }

    public class Item
    {
        public int UnreadCount { get; set; }
    }

    public class Notification
    {
        public string Type { get; set; }
        public Item Item { get; set; }
    }

    public class Filter
    {
        public string Name { get; set; }
        public string Key { get; set; }
    }

    public class SuggestedFilters
    {
        public string Header { get; set; }
        public List<Filter> Filters { get; set; }
    }

    public class Ne
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Sw
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class SuggestedBounds
    {
        public Ne Ne { get; set; }
        public Sw Sw { get; set; }
    }

    public class Item3
    {
        public string Summary { get; set; }
        public string Type { get; set; }
        public string ReasonName { get; set; }
    }

    public class Reasons
    {
        public int Count { get; set; }
        public List<Item3> Items { get; set; }
    }

    public class Contact
    {
        public string Phone { get; set; }
        public string FormattedPhone { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string FacebookUsername { get; set; }
        public string FacebookName { get; set; }
    }

    public class Location
    {
        public string Address { get; set; }
        public string CrossStreet { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Distance { get; set; }
        public string Cc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<string> FormattedAddress { get; set; }
        public string PostalCode { get; set; }
    }

    public class Icon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }
        public Icon Icon { get; set; }
        public bool Primary { get; set; }
    }

    public class Stats
    {
        public int CheckinsCount { get; set; }
        public int UsersCount { get; set; }
        public int TipCount { get; set; }
    }

    public class Hours
    {
        public bool IsOpen { get; set; }
        public bool IsLocalHoliday { get; set; }
        public string Status { get; set; }
    }

    public class Photo
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Photo Photo { get; set; }
    }

    public class Item4
    {
        public string Id { get; set; }
        public int CreatedAt { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public User User { get; set; }
        public string Visibility { get; set; }
    }

    public class Group2
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public List<Item4> Items { get; set; }
    }

    public class Photos
    {
        public int Count { get; set; }
        public List<Group2> Groups { get; set; }
    }

    public class HereNow
    {
        public int Count { get; set; }
        public string Summary { get; set; }
        public List<object> Groups { get; set; }
    }

    public class Photo2
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User2
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Photo2 Photo { get; set; }
    }

    public class Item5
    {
        public string Id { get; set; }
        public int CreatedAt { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public User2 User { get; set; }
        public string Visibility { get; set; }
    }

    public class FeaturedPhotos
    {
        public int Count { get; set; }
        public List<Item5> Items { get; set; }
    }

    public class Price
    {
        public int Tier { get; set; }
        public string Message { get; set; }
        public string Currency { get; set; }
    }

    public class Menu
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string Anchor { get; set; }
        public string Url { get; set; }
        public string MobileUrl { get; set; }
        public string ExternalUrl { get; set; }
    }

    public class VenuePage
    {
        public string Id { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
    }

    public class Delivery
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public Provider Provider { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public List<Category> Categories { get; set; }
        public bool Verified { get; set; }
        public Stats Stats { get; set; }
        public double Rating { get; set; }
        public string RatingColor { get; set; }
        public int RatingSignals { get; set; }
        public Hours Hours { get; set; }
        public Photos Photos { get; set; }
        public HereNow HereNow { get; set; }
        public FeaturedPhotos FeaturedPhotos { get; set; }
        public string Url { get; set; }
        public Price Price { get; set; }
        public bool? AllowMenuUrlEdit { get; set; }
        public bool? HasMenu { get; set; }
        public Menu Menu { get; set; }
        public VenuePage VenuePage { get; set; }
        public string StoreId { get; set; }
        public Delivery Delivery { get; set; }
    }

    public class Likes
    {
        public int Count { get; set; }
        public List<object> Groups { get; set; }
        public string Summary { get; set; }
    }

    public class Todo
    {
        public int Count { get; set; }
    }

    public class Photo3
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User3
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Photo3 Photo { get; set; }
        public string Type { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Photo4
    {
        public string Id { get; set; }
        public int CreatedAt { get; set; }
        public Source Source { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Visibility { get; set; }
    }

    public class Tip
    {
        public string Id { get; set; }
        public int CreatedAt { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string CanonicalUrl { get; set; }
        public Likes Likes { get; set; }
        public bool LogView { get; set; }
        public int AgreeCount { get; set; }
        public int DisagreeCount { get; set; }
        public string LastVoteText { get; set; }
        public Todo Todo { get; set; }
        public User3 User { get; set; }
        public Photo4 Photo { get; set; }
        public string Photourl { get; set; }
        public string Url { get; set; }
    }

    public class Item2
    {
        public Reasons Reasons { get; set; }
        public Venue Venue { get; set; }
        public List<Tip> Tips { get; set; }
        public string ReferralId { get; set; }
    }

    public class Group
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<Item2> Items { get; set; }
    }

    public class Response
    {
        public SuggestedFilters SuggestedFilters { get; set; }
        public string HeaderLocation { get; set; }
        public string HeaderFullLocation { get; set; }
        public string HeaderLocationGranularity { get; set; }
        public int TotalResults { get; set; }
        public SuggestedBounds SuggestedBounds { get; set; }
        public List<Group> Groups { get; set; }
    }

    public class FoursquareVenues
    {
        public Meta Meta { get; set; }
        public List<Notification> Notifications { get; set; }
        public Response Response { get; set; }
    }
}
