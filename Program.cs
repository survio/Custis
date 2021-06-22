using System;

namespace Custis
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.MakeFile("Test.txt", 50000,30);
           FileSorter sorter = new FileSorter("Test.txt");
                sorter.Sort();
        }
    }
}
