using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace BlockChainCSharp.Core
{
    class ObjectSerializerBlockChain
    {
        public static void WriteBlockChainToBlob(BlockChain _BlockChainToBlob)
        {
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _BlockChainToBlob);
            byte[] BlobData = memorystream.ToArray();

            WriteBin(BlobData);
        }

        public static BlockChain ReadBlobToBlockChain()
        {
            //Read from bin

            byte[] BlobData = ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\BlockChain\\BlockChain.bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            BlockChain deserializedBlockChain = bfd.Deserialize(memorystreamd) as BlockChain;

            memorystreamd.Close();

            return deserializedBlockChain;
        }

        public static void WriteBin(byte[] _storage)
        {
            //Write to wallet file
            String FileFolder = AppDomain.CurrentDomain.BaseDirectory + @"bin\\BlockChain\\";
            String FilePath = FileFolder + "BlockChain.bin";

            if (!Directory.Exists(FileFolder))
            {
                //Create directory if it does not exist
                Directory.CreateDirectory(FileFolder);
            }

            BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create));

            writer.Write(_storage);  //Write binaries
            writer.Close();
        }
        public static byte[] ReadBin(String _filePath)
        {
            StreamReader sr = new StreamReader(_filePath);
            var bytes = default(byte[]);
            using (var memstream = new MemoryStream())
            {
                sr.BaseStream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            return bytes;
        }
    }
}
