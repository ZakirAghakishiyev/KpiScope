namespace KpiScope.Core.UserAggregate.Specifications;

public class UserByMailorNameSpec:Specification<User>
{
    public UserByMailorNameSpec(string mail, string username)
    {
        Query.Where(u => u.Email == mail || u.Username == username);
    }
}
