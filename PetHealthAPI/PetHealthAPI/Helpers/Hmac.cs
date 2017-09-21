using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PetHealthAPI.Helpers
{
    public class Hmac
    {
        private const Int32 SaltSize = 32;
        public static String GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[SaltSize];
                rng.GetBytes(randomNumber);
                return Encoding.ASCII.GetString(randomNumber);
            }
        }

        public static String ComputeHMAC_SHA256_Password(String datastring, String saltstring)
        {
            byte[] data = Encoding.ASCII.GetBytes(datastring);
            byte[] salt = Encoding.ASCII.GetBytes(saltstring);
            using (var hmac = new HMACSHA256(salt))
            {
                return Encoding.ASCII.GetString(hmac.ComputeHash(data));
            }
        }
    }
}