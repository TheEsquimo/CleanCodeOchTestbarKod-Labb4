using System.IO;

namespace MagicTheVotingAPI
{
    public interface IFile
    {
        public StreamWriter CreateText(string path);
        public string ReadAllText(string path);
    }
}
