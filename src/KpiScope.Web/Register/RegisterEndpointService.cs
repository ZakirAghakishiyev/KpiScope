using Ardalis.SharedKernel;
using KpiScope.Core.UserAggregate.Specifications;
using UserAgg=KpiScope.Core.UserAggregate;
using System.Net;
using System.Net.Mail;

namespace KpiScope.Web.Register;

public class RegisterEndpointService(IRepository<UserAgg.User> _userRepository)
{
    public async Task<RegisterResponse?> RegisterAsync(RegisterRequest req, CancellationToken ct)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password) || string.IsNullOrWhiteSpace(req.Email))
            {
                throw new ArgumentException("Username, Password, and Email are required.");
            }

            var existingUser = await _userRepository.FirstOrDefaultAsync(new UserByMailorNameSpec(req.Email, req.Username), ct);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            var user = new UserAgg.User() { Username = req.Username, PasswordHash = req.Password, Email = req.Email, CompanyId = req.ComapanyId };
            var createdUser = await _userRepository.AddAsync(user, ct);
            if (createdUser == null)
            {
                throw new InvalidOperationException("User creation failed.");
            }
            await _userRepository.UpdateAsync(user, ct);
            
            return new RegisterResponse
            {
                Id = createdUser.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
        catch (ArgumentException ex)
        {
            Log.Error(ex, "Missing required fields during registration.");
            return new RegisterResponse{Username=null!,Email=ex.Message};
        }
        catch (InvalidOperationException ex)
        {
            Log.Error(ex, "Already Exsisting User");
            return new RegisterResponse{Username=null!,Email=ex.Message};
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Exception Occured");
            return new RegisterResponse{Username=null!,Email=ex.Message};
        }
    }
}
