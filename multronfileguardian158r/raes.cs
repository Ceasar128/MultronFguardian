using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace multronfileguardian
{
    class raes
    {
        public static byte[] rsadecrypt(byte[] veri, string xmlkey, int keysize)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(keysize);
            rsa.FromXmlString(xmlkey);
            return rsa.Decrypt(veri, true);
        }
        public static byte[] rsaencrypt(byte[] veri, string xmlkey, int keysize)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(keysize);
            rsa.FromXmlString(xmlkey);
            return rsa.Encrypt(veri, true);
        }
        public static string rsageneratekey(int keysize)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(keysize);
            return rsa.ToXmlString(false) + "#" + rsa.ToXmlString(true);
        }
        public static string getrandomstring(int size)
        {
            string ascchr = "qwertyuiopasdfghjklzxcvbnm";
            string rndmstr = "";
            Random pseudo = new Random();
            for(int i = 0; i <= size;)
            {
                rndmstr = rndmstr + ascchr[pseudo.Next(-0, ascchr.Length)];
                ++i;
            }
            return rndmstr;
        }
        public static byte[] generaterandomkey(int keysize)
        {
            byte[] rndkey = new byte[keysize];
            RandomNumberGenerator.Create().GetBytes(rndkey);
            return rndkey;
        }

        public static byte[] argonkdf(byte[] key, byte[] salt, short iteraterate, int memory, int parallel, int keysize)
        {
            Argon2BytesGenerator argkdf = new Argon2BytesGenerator();
            Argon2Parameters.Builder argprm = new Argon2Parameters.Builder(Argon2Parameters.Argon2id);
            argprm.WithVersion(Argon2Parameters.Version13);
            argprm.WithParallelism(parallel);
            argprm.WithIterations(iteraterate);
            argprm.WithSalt(salt);
            argprm.WithMemoryAsKB(memory);
            argkdf.Init(argprm.Build());
            byte[] derivedkey = new byte[keysize];
            argkdf.GenerateBytes(key, derivedkey);
            argprm.Clear();
            return derivedkey;
        }
    }
}
