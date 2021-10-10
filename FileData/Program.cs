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
            try
            {

                FileTask tasks = new FileTask(new FileService());
                Console.WriteLine(tasks.Task1(args));
                Console.WriteLine(tasks.Task2(args));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex.Message);
            }
        }
    }
}
