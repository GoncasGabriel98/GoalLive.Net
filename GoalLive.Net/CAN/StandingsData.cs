using System.Collections.Generic;

public class StandingsData
{
    public List<Group> Standings { get; set; }
}

public class Group
{
    public Tournament Tournament { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public List<Row> Rows { get; set; }
    public int Id { get; set; }
    public long UpdatedAtTimestamp { get; set; }
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

public class Category
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public Sport Sport { get; set; }
    public int Id { get; set; }
    public string Flag { get; set; }
}

public class Sport
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public int Id { get; set; }
}

public class UniqueTournament
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string PrimaryColorHex { get; set; }
    public string SecondaryColorHex { get; set; }
    public Category Category { get; set; }
    public int UserCount { get; set; }
    public bool HasPerformanceGraphFeature { get; set; }
    public int Id { get; set; }
    public bool DisplayInverseHomeAwayTeams { get; set; }
}

public class Row
{
    public Team Team { get; set; }
    public List<object> Descriptions { get; set; }
    public Promotion Promotion { get; set; }
    public int Position { get; set; }
    public int Matches { get; set; }
    public int Wins { get; set; }
    public int ScoresFor { get; set; }
    public int ScoresAgainst { get; set; }
    public int Id { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
    public int Points { get; set; }
}

public class Team
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string ShortName { get; set; }
    public string Gender { get; set; }
    public Sport Sport { get; set; }
    public int UserCount { get; set; }
    public string NameCode { get; set; }
    public int Ranking { get; set; }
    public bool Disabled { get; set; }
    public bool National { get; set; }
    public int Type { get; set; }
    public int Id { get; set; }
    public TeamColors TeamColors { get; set; }
    public FieldTranslations FieldTranslations { get; set; }
}

public class TeamColors
{
    public string Primary { get; set; }
    public string Secondary { get; set; }
    public string Text { get; set; }
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

public class Promotion
{
    public string Text { get; set; }
    public int Id { get; set; }
}
