using Resort.Domain.SharedKernel;

namespace Resort.Domain.LandingPages;

public sealed class SignUp : AggregateRoot<Guid>
{
    private SignUp()
    {
    }

    public string Username { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string ConfirmPassword { get; private set; }

    public SignUp(Guid id, string username, string phoneNumber,
        string email, string password, string confirmPassword) : base(id)
    {
        Username = username;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}