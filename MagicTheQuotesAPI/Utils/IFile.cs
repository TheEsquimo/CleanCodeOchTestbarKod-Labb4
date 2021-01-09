using System.IO;

namespace MagicTheQuotesAPI
{
    public interface IFile
    {
        public string ReadAllText(string path);
    }
}
