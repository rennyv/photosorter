using System;
using System.IO;
using System.Linq;

namespace PhotoSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = @"d:\temp\2016";
            var pictureDirectoryFormat = "yyyy-MM-dd";
            var pictureExtensions = new string[] { ".png", "jpg" };
            var movieDirectoryFormat = "yy-MM-dd";
            var movieExtensions = new string[] { ".mov", "mp4" };

            foreach (var item in Directory.GetFiles(rootDirectory))
            {
                var fileInfo = new FileInfo(item);
                var date = "unknown";
                if (pictureExtensions.Contains(fileInfo.Extension.ToLower()))
                {
                    date = fileInfo.LastWriteTime.ToString(pictureDirectoryFormat);
                } else if (movieExtensions.Contains(fileInfo.Extension.ToLower())) { 
                    date = fileInfo.LastWriteTime.ToString(movieDirectoryFormat);
                }

                Console.WriteLine("Processing " + fileInfo.Name);

                var newdir = rootDirectory + "\\" + date;

                if (!Directory.Exists(newdir))
                {
                    Directory.CreateDirectory(newdir);
                }

                File.Move(rootDirectory + "\\" + fileInfo.Name, newdir + "\\" + fileInfo.Name);

            }
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
