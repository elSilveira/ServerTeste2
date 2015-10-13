using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServerTeste2.Security
{
    /// <summary> Kriptho Version 1.2.94,
    /// <para>Enthusiast: Bruno Casali, at 2013/11/19 </para>
    /// <!--
    /// Comentários Removidos :?
    /// Author: Nikhil Singhal.
    /// I Don't have permissions to tell you about this! But please access the following website then you have the answers, and comments!!... anyway!...
    /// <see cref="http://www.programminginterviews.info/2012/05/how-to-store-user-passwords-using.html"/>
    /// -->
    /// </summary>
    public sealed class Krypto
    {
        private static int GetTrueRandomNumber()
        {
            try
            {
                byte[] randomBytes = new byte[4];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(randomBytes);
                int seed = (randomBytes[0] & 0x7f) << 24 | randomBytes[1] << 16 | randomBytes[2] << 8 | randomBytes[3];
                Random random = new Random(seed);
                return random.Next(8, 24);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static byte[] GetSaltBytes(string input, int saltSize)
        {
            try
            {
                byte[] saltBytes = null;
                using (Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(input, saltSize, 1000)) { saltBytes = rdb.Salt; }
                return saltBytes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string Encrypt(string input, byte[] saltBytes)
        {
            try
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] saltAndInput = new byte[saltBytes.Length + inputBytes.Length];

                Buffer.BlockCopy(saltBytes, 0, saltAndInput, 0, saltBytes.Length);
                Buffer.BlockCopy(inputBytes, 0, saltAndInput, saltBytes.Length, inputBytes.Length);

                byte[] data = GetHashInternal(saltAndInput);
                byte ss = Convert.ToByte(saltBytes.Length);
                byte[] finalBytes = new byte[1 + saltBytes.Length + data.Length];

                finalBytes[0] = ss;
                Buffer.BlockCopy(saltBytes, 0, finalBytes, 1, saltBytes.Length);
                Buffer.BlockCopy(data, 0, finalBytes, saltBytes.Length + 1, data.Length);

                return ByteArrayToString(finalBytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static byte[] GetHashInternal(byte[] input)
        {
            try
            {
                using (HashAlgorithm ha = new SHA512CryptoServiceProvider())
                {
                    byte[] data = new byte[input.Length];
                    Array.Copy(input, data, input.Length);

                    for (int i = 0; i < 1000; i++)
                        data = ha.ComputeHash(data);

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string ByteArrayToString(byte[] data)
        {
            try
            {
                return Convert.ToBase64String(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static byte[] StringToByteArray(string data)
        {
            try
            {
                return Convert.FromBase64String(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma senha criptografada para armazenamento no banco, de acordo com a senha digitada.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetPassword(string input)
        {
            try
            {
                int saltSize = GetTrueRandomNumber();
                byte[] saltBytes = GetSaltBytes(input, saltSize);
                return Encrypt(input, saltBytes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Verifica se a senha digitada bate com a senha criptografada no banco
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encPassword"></param>
        /// <returns></returns>
        public bool VerifyPassword(string input, string encPassword)
        {
            try
            {
                byte[] finalBytes = StringToByteArray(encPassword);
                int saltSize = Convert.ToInt32(finalBytes[0]);

                byte[] saltBytes = new byte[saltSize];
                Array.Copy(finalBytes, 1, saltBytes, 0, saltSize);
                string hash = Encrypt(input, saltBytes);
                return (String.Compare(encPassword, hash, false) == 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
