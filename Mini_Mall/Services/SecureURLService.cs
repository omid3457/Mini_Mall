using System.Security.Cryptography;
using System.Text;

namespace Fitness_ClubV1.Services
{
    public class SecureURLService
    {
        public readonly byte[] _key = [];
        public readonly IConfiguration _configuration;
        
        public SecureURLService(IConfiguration configuration)
        {
            _configuration = configuration;
            var key = _configuration["SecureKey:SecretKey"] ?? throw new InvalidOperationException("Key not found");
            
            _key = Encoding.UTF8.GetBytes(key);
        }
        public string Create(int id)
        {

            string payload = id.ToString();

            string encodedpayload = Base64UrlEncode(Encoding.UTF8.GetBytes(payload));

            byte[] signature = HMACSHA256.HashData(_key, Encoding.UTF8.GetBytes(encodedpayload));

            string encodedsignature = Base64UrlEncode(signature);


            return $"{encodedpayload}.{encodedsignature}";
        }

        public string Create(string username)
        {

            string payload = username;

            string encodedpayload = Base64UrlEncode(Encoding.UTF8.GetBytes(payload));

            byte[] signature = HMACSHA256.HashData(_key, Encoding.UTF8.GetBytes(encodedpayload));

            string encodedsignature = Base64UrlEncode(signature);


            return $"{encodedpayload}.{encodedsignature}";
        }

        public T GetId<T>(string url)
        { 
            string[] parts = url.Split(".");
            string payload = parts[0];
            string receivedSignature = parts[1];
            byte[] exsigniture = HMACSHA256.HashData(_key, Encoding.UTF8.GetBytes(payload));
            byte[] actualSignature;

            try
            {
                actualSignature = Base64UrlDecode(receivedSignature);
            }

            catch
            {
                throw new DynamicException("SignatureDecodeFail", "IDK");
            }

            if (!CryptographicOperations.FixedTimeEquals(actualSignature, exsigniture))
                throw new DynamicException("SignatureTempored", "Signature don't match");
            try
            {
                string decodecpayload = Encoding.UTF8.GetString(Base64UrlDecode(payload));

                if(typeof(T) == typeof(string))
                {
                    return (T)(object)decodecpayload;
                }

                else if(typeof(T) == typeof(int))
                {
                    _ = int.TryParse(decodecpayload, out int value);
                    return (T)(object)value;
                }

                else
                {
                    throw new DynamicException("WrongType", "Something beside int or string");
                }
            }

            catch
            {
                throw new InvalidDataException();
            }
        }

        private static string Base64UrlEncode(byte[] data)
        {
            return Convert.ToBase64String(data)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }

        private static byte[] Base64UrlDecode(string value)
        {
            value = value
                .Replace('-', '+')
                .Replace('_', '/');

            switch (value.Length % 4)
            {
                case 2:
                    value += "==";
                    break;

                case 3:
                    value += "=";
                    break;
            }

            return Convert.FromBase64String(value);
        }
    }
}
