using System.Security.Cryptography;
using System.Text;
using System;
using Org.BouncyCastle.Crypto.Digests;

namespace BlockChainCSharp.Core
{
    class KeyManager
    {
        public static Boolean ValidateInput(byte[] _inputprivateKey, byte[] _inputPubKey, string _inputAddress)
        {
            Boolean ret = true;
            byte[] resultPubKey     = KeyManager.GeneratePublicKeyFromPrivateKey(_inputprivateKey);
            byte[] resultMeltKey    = KeyManager.KeyMeltResult(_inputprivateKey, resultPubKey);
            string resultPubAddress = KeyManager.ConvertToPubAddressChunked(resultMeltKey);

            if (resultPubAddress != _inputAddress)
            {
                //Faulty keys where given!
                ret = false;
            }

            return ret;
        }

        public static byte[] GeneratePublicKeyFromPrivateKey(byte[] privateSpendKey)
        {
            RNGCryptoServiceProvider.Create().GetBytes(privateSpendKey);
            byte[] publicKey = Cryptographic.Ed25519.PublicKey(privateSpendKey);

            return publicKey;
        }

        public static byte[] KeyMeltResult(byte[] _inputPrivateKey, byte[] _inputPublicKey)
        {
            byte[] Input = new byte[64];    //32 bytes private and 32 bytes public key
            //Design decision, vary difficulty by using PBKDF2 or maintain SHA3 256...later to be decided

            //Melt private and public key into one big key
            System.Buffer.BlockCopy(_inputPrivateKey, 0, Input, 0, _inputPrivateKey.Length);
            System.Buffer.BlockCopy(_inputPublicKey, 0, Input, _inputPrivateKey.Length, _inputPublicKey.Length);

            //Do some more cryptography so pub address is nowhere to be retraced (we hope)
            Sha3Digest digest = new Sha3Digest(256);
            digest.BlockUpdate(Input, 0, Input.Length);
            byte[] result = new byte[64];
            digest.DoFinal(result, 0);

            return result;
        }

        //Base 58 conversion below
        public static string ConvertToPubAddressChunked(byte[] array)
        {
            int arrayLength = array.Length;
            string ret = "";
            int numOfCopyInt;
            byte[] subArray = new byte[8];  //Max 8 bytes

            for (int I = 0; I < arrayLength; I += 8)
            {
                numOfCopyInt = arrayLength - I > 7 ? 8 : arrayLength - I;
                subArray = new byte[numOfCopyInt];
                Array.Copy(array, I, subArray, 0, numOfCopyInt);
                ret += KeyManager.ConvertToPubAddress(subArray);
            }

            return ret;
        }

        public static string ConvertToPubAddress(byte[] array)
        {
            const string ALPHABET = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            string retString = string.Empty;
            System.Numerics.BigInteger encodeSize = ALPHABET.Length;
            System.Numerics.BigInteger arrayToInt = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                arrayToInt = arrayToInt * 256 + array[i];
            }
            while (arrayToInt > 0)
            {
                int rem = (int)(arrayToInt % encodeSize);
                arrayToInt /= encodeSize;
                retString = ALPHABET[rem] + retString;
            }
            for (int i = 0; i < array.Length && array[i] == 0; ++i)
                retString = ALPHABET[0] + retString;

            return retString;
        }
    }
}
