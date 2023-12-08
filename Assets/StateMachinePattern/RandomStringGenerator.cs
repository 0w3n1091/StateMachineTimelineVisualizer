using System;

namespace StateMachinePattern
{
    public class RandomStringGenerator
    {
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
}