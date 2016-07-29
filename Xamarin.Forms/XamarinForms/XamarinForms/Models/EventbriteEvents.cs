using System;
using System.Collections.Generic;

namespace XamarinForms.Eventbrite.Models
{
    
    public class EventbriteEvents
    {
        public Pagination Pagination { get; set; }
        public List<Event> Events { get; set; }
        public Location Location { get; set; }
    }

    public class Pagination
    {
        public int ObjectCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }

    public class Location
    {
        public string Latitude { get; set; }
        public string Within { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
    }

    public class Event
    {
        public Name Name { get; set; }
        public Description Description { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public Start Start { get; set; }
        public End End { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public bool Listed { get; set; }
        public bool Shareable { get; set; }
        public bool OnlineEvent { get; set; }
        public int TxTimeLimit { get; set; }
        public bool HideStartDate { get; set; }
        public bool HideEndDate { get; set; }
        public string Locale { get; set; }
        public bool IsLocked { get; set; }
        public string PrivacySetting { get; set; }
        public bool IsSeries { get; set; }
        public bool IsSeriesParent { get; set; }
        public bool IsReservedSeating { get; set; }
        public string LogoId { get; set; }
        public string OrganizerId { get; set; }
        public string VenueId { get; set; }
        public string CategoryId { get; set; }
        public object SubcategoryId { get; set; }
        public string FormatId { get; set; }
        public string ResourceUri { get; set; }
        public Logo Logo { get; set; }
        public Venue Venue { get; set; }
    }

    public class Name
    {
        public string Text { get; set; }
        public string Html { get; set; }
    }

    public class Description
    {
        public string Text { get; set; }
        public string Html { get; set; }
    }

    public class Start
    {
        public string Timezone { get; set; }
        public DateTime Local { get; set; }
        public DateTime Utc { get; set; }
    }

    public class End
    {
        public string Timezone { get; set; }
        public DateTime Local { get; set; }
        public DateTime Utc { get; set; }
    }

    public class Logo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string AspectRatio { get; set; }
        public string EdgeColor { get; set; }
        public bool EdgeColorSet { get; set; }
    }

    public class Venue
    {
        public Address Address { get; set; }
        public string ResourceUri { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public object Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Localized_Address_Display { get; set; }
    }

}