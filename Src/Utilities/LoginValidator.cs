namespace TechZone.Utilities;

public static class LoginValidator
{
    public static string? Validate(
        string username,
        string password)
    {
        if (string.IsNullOrWhiteSpace(username) &&
            string.IsNullOrWhiteSpace(password))
        {
            return "Please enter your username and password.";
        }

        if (string.IsNullOrWhiteSpace(username))
            return "Please enter your username.";

        return string.IsNullOrWhiteSpace(password) ? "Please enter your password." : null;
    }
}