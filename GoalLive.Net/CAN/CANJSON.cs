using System;
using System.Collections.Generic;

namespace GoalLive.Net.CAN
{
    public class Sport
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Id { get; set; }
    }

    public class Country
    {
        public string Alpha2 { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Sport Sport { get; set; }
        public int Id { get; set; }
        public string Flag { get; set; }
        public string Alpha2 { get; set; }
    }

    public class TeamColors
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string Text { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ShortName { get; set; }
        public Sport Sport { get; set; }
        public int UserCount { get; set; }
        public string NameCode { get; set; }
        public bool Disabled { get; set; }
        public bool National { get; set; }
        public int Type { get; set; }
        public int Id { get; set; }
        public Country Country { get; set; }
        public List<object> SubTeams { get; set; }
        public TeamColors TeamColors { get; set; }
        public FieldTranslations FieldTranslations { get; set; }
    }

    public class FieldTranslations
    {
        public NameTranslation NameTranslation { get; set; }
        public ShortNameTranslation ShortNameTranslation { get; set; }
    }

    public class NameTranslation
    {
        public string Ar { get; set; }
    }

    public class ShortNameTranslation
    {
    }

    public class Status
    {
        public int Code { get; set; }
        public string Description { get { return _description; } set { _description = value; } }
        public string Type { get; set; }

        private string _description;
    }

    public class RoundInfo
    {
        public int Round { get; set; }
        public string Name { get; set; }
        public int CupRoundType { get; set; }
    }

    public class Changes
    {
        public List<string> ChangesList { get; set; }
        public long ChangeTimestamp { get; set; }
    }

    public class UniqueTournament
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Category Category { get; set; }
        public int UserCount { get; set; }
        public bool CrowdsourcingEnabled { get; set; }
        public bool HasPerformanceGraphFeature { get; set; }
        public int Id { get; set; }
        public bool HasEventPlayerStatistics { get; set; }
        public bool DisplayInverseHomeAwayTeams { get; set; }
    }

    public class Tournament
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Category Category { get; set; }
        public UniqueTournament UniqueTournament { get; set; }
        public int Priority { get; set; }
        public int Id { get; set; }
    }

    public class Season
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public bool Editor { get; set; }
        public int Id { get; set; }
    }

    public class HomeScore
    {
        public int Current { get; set; }
        public int Display { get; set; }
        public int Period1 { get; set; }
        public int Period2 { get; set; }
        public int Normaltime { get; set; }
    }

    public class AwayScore
    {
        public int Current { get; set; }
        public int Display { get; set; }
        public int Period1 { get; set; }
        public int Period2 { get; set; }
        public int Normaltime { get; set; }
    }

    public class Time
    {
        public int InjuryTime1 { get; set; }
        public int InjuryTime2 { get; set; }
        public long CurrentPeriodStartTimestamp { get; set; }
    }

    public class EventData
    {
        public Tournament Tournament { get; set; }
        public Season Season { get; set; }
        public RoundInfo RoundInfo { get; set; }
        public string CustomId { get; set; }
        public Status Status { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public HomeScore HomeScore { get; set; }
        public AwayScore AwayScore { get; set; }
        public Time Time { get; set; }
        public Changes Changes { get; set; }
        public bool HasGlobalHighlights { get; set; }
        public bool HasEventPlayerStatistics { get; set; }
        public bool HasEventPlayerHeatMap { get; set; }
        public int DetailId { get; set; }
        public bool CrowdsourcingDataDisplayEnabled { get; set; }
        public int Id { get; set; }
        public bool CrowdsourcingEnabled { get; set; }
        public long StartTimestamp { get; set; }
        public string Slug { get; set; }
        public bool FinalResultOnly { get; set; }
        public bool IsEditor { get; set; }
    }

    public class RootObject
    {
        public List<EventData> Events { get; set; }
    }
}

