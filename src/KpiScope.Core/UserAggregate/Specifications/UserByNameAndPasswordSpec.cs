namespace KpiScope.Core.UserAggregate.Specifications;

public class UserByNameAndPasswordSpec:Specification<User>
{
    public UserByNameAndPasswordSpec(string name, string password)
    {
        Query
            .Where(u => u.Username == name && u.PasswordHash == password);
    }
}
