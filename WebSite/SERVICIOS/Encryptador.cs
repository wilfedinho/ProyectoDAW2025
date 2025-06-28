using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Encryptador
    {

        private readonly byte[] key = Encoding.UTF8.GetBytes("clave_encryptada_123456789012345");
        private readonly byte[] iv = Encoding.UTF8.GetBytes("clave_desc_12345");

        public string EncryptadorIrreversible(string stringAHashear)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringAHashear));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public string EncryptadorReversible(string stringAEncryptar)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptadorAes = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptadorAes, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(stringAEncryptar);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
        public string DesencryptadorReversible(string stringADesencryptar)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform desencryptadorAes = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(stringADesencryptar)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, desencryptadorAes, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
