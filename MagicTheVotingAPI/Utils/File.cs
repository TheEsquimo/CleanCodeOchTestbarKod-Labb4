using System.IO;

namespace MagicTheVotingAPI
{
    public class File : IFile
    {
        public StreamWriter CreateText(string path)
        {
            return System.IO.File.CreateText(path);
        }

        public string ReadAllText(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}
