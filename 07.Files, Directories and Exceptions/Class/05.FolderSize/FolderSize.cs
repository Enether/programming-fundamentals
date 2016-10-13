/*
 You are given a folder named “TestFolder”. Get the size of all files in the folder,
 which are NOT directories. The result should be written to another text file in Megabytes.
 */
using System.IO;

namespace _05.FolderSize
{
    class FolderSize
    {
        static void Main()
        {
            string[] files = Directory.GetFiles("../../TestFolder");
            double sum = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024; // convert to megabytes

            File.WriteAllText("../../megabytes.txt", sum.ToString());
        }
    }
}
