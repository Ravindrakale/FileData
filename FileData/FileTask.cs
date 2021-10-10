using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public class FileTask
    {
        private readonly IFileService fileDetails;
        public FileTask(IFileService fileDetails)
        {
            this.fileDetails = fileDetails;
        }
        public string Task1(string[] fileArgs)
        {
            var version = string.Empty;
            if (fileArgs.Length == 2 && fileArgs[0] == "-v")
            {
                return fileDetails.Version(fileArgs[1]);
            }
            throw new Exception("Invalid Arguments");
        }

        public string Task2(string[] fileArgs)
        {
            string[] validVerArgs = { "-v", "--v", "/v", "--version" };
            string[] validSizeArgs = { "-s", "--s", "/s", "--size" };

            var returnValue = string.Empty;
            if (fileArgs.Length == 2)
            {
                if (validVerArgs.Any(x => x == fileArgs[0]))
                {
                    return fileDetails.Version(fileArgs[1]);
                }
                else if (validSizeArgs.Any(x => x == fileArgs[0]))
                {
                    return fileDetails.Size(fileArgs[1]).ToString();
                }
            }
            throw new Exception("Invalid Arguments");
        }
    }
}
