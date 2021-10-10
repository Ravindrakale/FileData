using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Tasks tasks = new Tasks(new FileDetails());

            Console.WriteLine(tasks.Task1(args));
            Console.WriteLine(tasks.Task2(args));
        }
    }

    public class Tasks
    {
        private readonly FileDetails fileDetails;
        public Tasks(FileDetails fileDetails)
        {
            this.fileDetails = fileDetails;
        }
        public string Task1(string[] fileArgs)
        {
            var version = string.Empty;
            if (fileArgs.Length == 2 && fileArgs[0] == "-v")
            {
                var fileDetails = new FileDetails();
                version = fileDetails.Version(fileArgs[1]);
            }
            return version;
        }

        public string Task2(string[] fileArgs)
        {
            string[] validVerArgs = { "-v", "--v", "/v", "--version" };
            string[] validSizeArgs = { "-s", "--s", "/s", "--size" };

            var returnValue = string.Empty;
            if (fileArgs.Length ==2)
            {
                if(validVerArgs.Any(x=>x == fileArgs[0]))
                {
                    returnValue = fileDetails.Version(fileArgs[1]);
                }
                else if(validSizeArgs.Any(x => x == fileArgs[0]))
                {
                    returnValue = fileDetails.Size(fileArgs[1]).ToString();
                }
            }
            return returnValue;
        }
    }
}
