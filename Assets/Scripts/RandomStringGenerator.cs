using System;

public class RandomStringGenerator
{
    /// <summary>
    /// Generates a random string of specified length.
    /// </summary>
    /// <param name="length">The length of the random string to generate.</param>
    /// <returns>A random string of specified length.</returns>
    public static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        string randomString = "";
    
        for (int i = 0; i < length; i++)
            randomString += chars[random.Next(chars.Length)];

        return randomString;
    }
}