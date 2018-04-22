using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace BlockChainCSharp.Core
{
    class ObjectSerializerBlock
    {
        public static void WriteBlockToBlob(Block _BlockToBlob, Int64 _BlockHeight)
        {
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _BlockToBlob);
            byte[] BlobData = memorystream.ToArray();

            WriteBin(BlobData, _BlockHeight);
        }

        public static Block ReadBlobToBlock(Int64 _BlockHeight)
        {
            //Read from bin

            byte[] BlobData = ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\Block\\" + _BlockHeight + ".bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            Block deserializedBlock = bfd.Deserialize(memorystreamd) as Block;

            memorystreamd.Close();

            return deserializedBlock;
        }

        public static void WriteBin(byte[] _storage, Int64 _BlockHeight)
        {
            //Write to wallet file
            String FileFolder = AppDomain.CurrentDomain.BaseDirectory + @"bin\\Block\\";
            String FilePath = FileFolder + _BlockHeight + ".bin";

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
