using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileService : IFileService
    {
        private readonly FileDetails fileDetails = new FileDetails();
        public int Size(string filePath)
        {
            return fileDetails.Size(filePath);
        }

        public string Version(string filePath)
        {
            return fileDetails.Version(filePath);
        }
    }
}
