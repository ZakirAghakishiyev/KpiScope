using System.IdentityModel.Tokens.Jwt;
using Ardalis.SharedKernel;
using UserAgg=KpiScope.Core.UserAggregate;
using KpiScope.Core.UserAggregate.Specifications;

namespace KpiScope.Web.Login;

public class LoginEndpoint(IRepository<UserAgg.User> _userRepository, JwtTokenService _tokenService) : Endpoint<LoginRequest, LoginResponse>
{
    private readonly TimeSpan _cacheExpiry = TimeSpan.FromMinutes(300);

    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        string tokenId = Guid.NewGuid().ToString();
        string cacheKey = $"jwt:{tokenId}";

        if (await _userRepository.FirstOrDefaultAsync(new UserByNameAndPasswordSpec(req.Username, req.Password), ct) is not UserAgg.User user)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var token = await _tokenService.GenerateTokenAsync(req);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);        
        await SendAsync(new LoginResponse { Token = jwt });
    }
}

