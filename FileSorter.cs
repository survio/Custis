using System.IO;
using System.Linq;
using System.Text;

namespace Custis
{
    public class FileSorter
    {
        private string fileName;
        private FileStream fs;
        private StreamWriter writer;
        private StreamReader reader;

        public FileSorter(string fileName)
        {
            this.fileName = fileName;
            this.fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.writer = new StreamWriter(fs);
            this.reader = new StreamReader(fs);
        }

        public void Sort()
        {
            using (fs)
            using (reader)
            using (writer)
            {
             
                char[] charArray = new char[reader.ReadLine()?.Length+2??0];
                if(charArray.Length==0) return;
                reader.BaseStream.Position = 0;
                int currentPosition = 0;
                while (!reader.EndOfStream)
                {
                    reader.Read(charArray);
                    int length = charArray.Length;
                    currentPosition += length;
                    charArray = (string.Join("", new string(charArray).Substring(0, length - 2).OrderBy(x => x))+"\r\n").ToCharArray();
                    writer.BaseStream.Seek(currentPosition - length,SeekOrigin.Begin) ;
                    writer.Write(charArray);
                }
            }
        }
    }
}