using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ThirdPartyTools;
using FileData;

namespace FileData.Test
{
    public class FileTaskTest
    {
        private readonly Mock<IFileService> mockFileService;
        private readonly FileTask fileTask;
        public FileTaskTest()
        {
            mockFileService = new Mock<IFileService>();
            fileTask = new FileTask(mockFileService.Object);

        }

        [Fact]
        public void Task1_ShouldRetrunValidVersion()
        {
            //Arrange
            string[] fileArgs = { "-v", "C:/test.txt" };
            var retunVersion = "10.1.2";
            mockFileService.Setup(x => x.Version(It.IsAny<string>())).Returns(retunVersion);

            //Act 
            var returnValue = fileTask.Task1(fileArgs);
            //Assert
            Assert.Equal(returnValue, retunVersion);
        }

        [Fact]
        public void Task1_ShouldThrowExeption()
        {
            //Arrange
            string[] fileArgs = { };
            var retunVersion = "10.1.2";
            mockFileService.Setup(x => x.Version(It.IsAny<string>())).Returns(retunVersion);

            //Act 
            //Assert
            Assert.Throws<Exception>(()=>fileTask.Task1(fileArgs));
        }

        [Theory]
        [InlineData("-v", "C:/test.txt")]
        [InlineData("--v", "C:/test.txt")]
        [InlineData("/v", "C:/test.txt")]
        [InlineData("--version", "C:/test.txt")]
        public void Task2_ShouldRetrunValidVersion(string verbage, string filePath)
        {
            //Arrange
            string[] fileArgs = { verbage, filePath };
            var retunVersion = "10.1.2";
            mockFileService.Setup(x => x.Version(It.IsAny<string>())).Returns(retunVersion);

            //Act 
            var returnValue = fileTask.Task2(fileArgs);
            //Assert
            Assert.Equal(returnValue, retunVersion);
        }

        [Theory]
        [InlineData("-vd", "C:/test.txt")]
        [InlineData("----v", "C:/test.txt")]
        [InlineData("", "C:/test.txt")]
        [InlineData("--tversion", "C:/test.txt")]
        public void Task2_Version_ShouldThrowException(string verbage, string filePath)
        {
            //Arrange
            string[] fileArgs = { verbage, filePath };
            var retunVersion = "10.1.2";
            mockFileService.Setup(x => x.Version(It.IsAny<string>())).Returns(retunVersion);

            //Act 
            //Assert
            Assert.Throws<Exception>(()=>fileTask.Task2(fileArgs));
        }

        [Theory]
        [InlineData("-s", "C:/test.txt")]
        [InlineData("--s", "C:/test.txt")]
        [InlineData("/s", "C:/test.txt")]
        [InlineData("--size", "C:/test.txt")]
        public void Task2_ShouldRetrunValidFileSize(string verbage, string filePath)
        {
            //Arrange
            //-s, --s, /s, --size
            string[] fileArgs = { verbage, filePath };
            var size = 23652;
            mockFileService.Setup(x => x.Size(It.IsAny<string>())).Returns(size);

            //Act 
            var returnValue = fileTask.Task2(fileArgs);
            //Assert
            Assert.Equal(returnValue, size.ToString());
        }


        [Theory]
        [InlineData("-sw", "C:/test.txt")]
        [InlineData("--S", "C:/test.txt")]
        [InlineData("/sM", "C:/test.txt")]
        [InlineData("--Size", "C:/test.txt")]
        public void Task2_ShouldThrowException(string verbage, string filePath)
        {
            //Arrange
            //-s, --s, /s, --size
            string[] fileArgs = { verbage, filePath };
            var size = 23652;
            mockFileService.Setup(x => x.Size(It.IsAny<string>())).Returns(size);

            //Act 
            //Assert
            Assert.Throws<Exception>(() => fileTask.Task2(fileArgs));
        }
    }
}
