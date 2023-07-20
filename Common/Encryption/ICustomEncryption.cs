using Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Encryption
{
    public interface ICustomEncryption
    {
        string HashSHA256(string input);
        string GenerateToken(Guid userGuid);
        string GenerateRefreshToken();
        Guid GetUserGuidFromToken(string token);
        string EncodePassword(string pass, int passwordFormat, string salt);
        string GenerateSalt();
    }

    public class CustomEncryption : ICustomEncryption
    {
        Configs configs;
        public CustomEncryption(IOptions<Configs> options)
        {
            this.configs = options.Value;
        }

        static readonly char[] padding = { '=' };

        public string HashSHA256(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public string GenerateToken(Guid userGuid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configs.TokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("userGuid", userGuid.ToString()),
                        new Claim("TimeOut-Minute", configs.TokenTimeout.ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(configs.TokenTimeout),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        public Guid GetUserGuidFromToken(string token)
        {
            string secret = configs.TokenKey;
            var key = Encoding.UTF8.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token.Replace("bearer ", "").Replace("Bearer ", ""), validations, out var tokenSecure);
            return Guid.Parse(claims.FindFirst("userGuid").Value);
        }

        public string GenerateSalt()
        {
            byte[] numArray = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(numArray);
            string base64String = Convert.ToBase64String(numArray);
            return base64String;
        }

        public string EncodePassword(string pass, int passwordFormat, string salt)
        {
            byte[] numArray;
            byte[] numArray1;
            string base64String;
            bool length = passwordFormat != 0;
            if (length)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(pass);
                byte[] numArray2 = Convert.FromBase64String(salt);
                byte[] numArray3 = null;

                HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA1");

                if (hashAlgorithm as KeyedHashAlgorithm == null)
                {
                    numArray1 = new byte[(int)numArray2.Length + (int)bytes.Length];
                    Buffer.BlockCopy(numArray2, 0, numArray1, 0, (int)numArray2.Length);
                    Buffer.BlockCopy(bytes, 0, numArray1, (int)numArray2.Length, (int)bytes.Length);
                    numArray3 = hashAlgorithm.ComputeHash(numArray1);
                }
                else
                {
                    KeyedHashAlgorithm keyedHashAlgorithm = (KeyedHashAlgorithm)hashAlgorithm;
                    if (keyedHashAlgorithm.Key.Length != numArray2.Length)
                    {

                        if (keyedHashAlgorithm.Key.Length >= (int)numArray2.Length)
                        {
                            numArray = new byte[(int)keyedHashAlgorithm.Key.Length];
                            int num = 0;
                            while (true)
                            {
                                length = num < (int)numArray.Length;
                                if (!length)
                                {
                                    break;
                                }
                                int num1 = Math.Min((int)numArray2.Length, (int)numArray.Length - num);
                                Buffer.BlockCopy(numArray2, 0, numArray, num, num1);
                                num = num + num1;
                            }
                            keyedHashAlgorithm.Key = numArray;
                        }
                        else
                        {
                            numArray = new byte[(int)keyedHashAlgorithm.Key.Length];
                            Buffer.BlockCopy(numArray2, 0, numArray, 0, (int)numArray.Length);
                            keyedHashAlgorithm.Key = numArray;
                        }
                    }
                    else
                    {
                        keyedHashAlgorithm.Key = numArray2;
                    }
                    numArray3 = keyedHashAlgorithm.ComputeHash(bytes);
                }

                base64String = Convert.ToBase64String(numArray3);
            }
            else
            {
                base64String = pass;
            }
            return base64String;
        }
    }
}