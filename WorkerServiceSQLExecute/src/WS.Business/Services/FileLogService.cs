using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WS.Business.Interfaces;

namespace WS.Business.Services
{
    public class FileLogService : LogService, IFileLogService
    {
        public string IdWithExtension { get; private set; }
        public string Path { get; private set; }


        public FileLogService(string pathDirectory) : base()
        {
            IdWithExtension = Id + ".txt";

            if (string.IsNullOrEmpty(pathDirectory) || pathDirectory.Equals("Default"))
                Path = PathDefault();
            else
                Path = pathDirectory;

            CreateDirectory();
        }

        private static string GetLogId()
        {
            return DateTime.Now.ToString()
                .Replace(" ", "")
                .Replace("/", "")
                .Replace(":", "");
        }

        public string PathDefault()
        {
            return AppDomain.CurrentDomain.BaseDirectory + $"logs\\";
        }

        public void CreateDirectory()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        public void Create()
        {
            var path = Path + "" + IdWithExtension;

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now);
                }
            }
        }
    }
}
