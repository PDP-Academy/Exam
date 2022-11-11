
namespace Imtihon3.Core.Brokers.File
{
    public class File : IFile
    {
        private string path = @"C:\Users\Evoo\Desktop\Test.txt";

        public string ReadToFile()
        {
            using StreamReader stream = new StreamReader(path);

            return stream.ReadToEnd();

        }

        public void WriteToFIle(string data)
        {
            using StreamWriter stream = new StreamWriter(path);

            stream.Write(data);
        }
    }
}
