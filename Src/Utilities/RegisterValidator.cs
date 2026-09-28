namespace TechZone.Utilities;

public static class RegisterValidator
{
    public static string? Validate(
        string username,
        string password,
        string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(username) &&
            string.IsNullOrWhiteSpace(password) &&
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            return "Please fill in all fields.";
        }
        
        if (string.IsNullOrWhiteSpace(username))
            return "Please enter your username.";

        if (username.Length < 3)
            return "Username must be at least 3 characters.";

        if (string.IsNullOrWhiteSpace(password))
            return "Please enter your password.";

        if (password.Length < 6)
            return "Password must be at least 6 characters.";

        if (string.IsNullOrWhiteSpace(confirmPassword))
            return "Please confirm your password.";

        if (password != confirmPassword)
            return "Passwords do not match.";

        return null;
    }

}