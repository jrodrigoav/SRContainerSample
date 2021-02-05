using System;

namespace SRContainerSample.Web.Models.Accuweather
{
    public class PostalCodeSearchResultItem
    {
        public int Version { get; init; }
        public string Key { get; init; }
        public string Type { get; init; }
        public int Rank { get; init; }
        public string LocalizedName { get; init; }
        public string EnglishName { get; init; }
        public string PrimaryPostalCode { get; init; }
        public IdLocalizedEnglish Region { get; init; }
        public IdLocalizedEnglish Country { get; init; }
        //public AdministrativeArea AdministrativeArea { get; init; }
        //public TimeZone TimeZone { get; init; }
        //public GeoPosition GeoPosition { get; init; }
    }
    public class IdLocalizedEnglish
    {
        public string ID { get; init; }
        public string LocalizedName { get; init; }
        public string EnglishName { get; init; }
    }

    public class Country
    {
        public string ID { get; init; }
        public string LocalizedName { get; init; }
        public string EnglishName { get; init; }
    }

    public class AdministrativeArea : IdLocalizedEnglish
    {        
        public int Level { get; init; }
        public string LocalizedType { get; init; }
        public string EnglishType { get; init; }
        public string CountryID { get; init; }
    }

    public class TimeZone
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public int GmtOffset { get; init; }
        public bool IsDaylightSaving { get; init; }
        public DateTime NextOffsetChange { get; init; }
    }

    public class UnitBase
    {
        public int Value { get; init; }
        public string Unit { get; init; }
        public int UnitType { get; init; }
    }
    public class Elevation
    {
        public UnitBase Metric { get; init; }
        public UnitBase Imperial { get; init; }
    }

    public class GeoPosition
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public Elevation Elevation { get; init; }
    }
}
