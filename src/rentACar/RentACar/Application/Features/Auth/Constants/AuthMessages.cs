namespace Application.Features.Auth.Constants;

public static class AuthMessages
{
    public const string EmailAuthenticatorDoesntExist = "Email Authenticator does not exist!";
    public const string OtpAuthenticatorDoesntExist = "Otp Authenticator does not exist!";
    public const string AlreadyVerifiedOtpAuthtenticatorExists = "Already verified Otp Authenticator exists!";
    public const string EmailActivationKeyDoesntExist = "Email Activation Key does not exist!";
    public const string UserDoesntExist = "User does not exist!";
    public const string UserAlreadyHasAnAuthenticator = "User already has an authenticator!";
    public const string RefreshTokenDoesntExist = "Refresh Token does not exist!";
    public const string InvalidRefreshToken = "Invalid Refresh Token!";
    public const string UserMailAlreadyExists = "User e-mail already exists!";
    public const string PasswordsDontMatch = "Passwords do not match!";
}
