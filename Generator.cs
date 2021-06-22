using System;
using System.IO;
using System.Text;

namespace Custis
{

    public static class Generator
    {
        public static void MakeFile(string fileName, int lineCount, int lengthString)
        {
            Random random = new Random();
            using (FileStream fs = File.Create(fileName))
            using (StreamWriter sw = new StreamWriter(fs))

            {
                for (int i = 0; i < lineCount; i++)
                {
                    string stringLine = null;
                    for (int j = 0; j < lengthString; j++)
                    {
                        stringLine += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)))
                            .ToString();
                    }
                    sw.WriteLine(stringLine);
                }
            }
        }
    }
}