namespace KpiScope.Core.ContributorAggregate;

public class ContributorStatus : SmartEnum<ContributorStatus>
{
  public static readonly ContributorStatus CoreTeam = new(nameof(CoreTeam), 1);
  public static readonly ContributorStatus Community = new(nameof(Community), 2);
  public static readonly ContributorStatus NotSet = new(nameof(NotSet), 3);

  public ContributorStatus(string name, int value) : base(name, value) { }
  public ContributorStatus():base("name", 10)
  {
  }
}

