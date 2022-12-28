using Disco.Business.Interfaces;
using Disco.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class AudDServiceTest
    {
        //[TestMethod]
        //public async Task RecognizeAsync_ReturnsHasMusicResponse()
        //{
        //    //Arrange

        //    //Setup mock file using a memory stream
        //    var content = "Hello World from a Fake File";
        //    var fileName = "test.pdf";
        //    var stream = new MemoryStream();
        //    var writer = new StreamWriter(stream);
        //    writer.Write(content);
        //    writer.Flush();
        //    stream.Position = 0;

        //    //create FormFile with desired data
        //    IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

        //    var mockedHttpClient = new Mock<IHttpClientFactory>();
        //    mockedHttpClient.Setup(s => s.CreateClient().PostAsync(It.IsAny<string>(), It.))

        //    var audDService = new AudDService();

        //    Assert.IsInstanceOfType(result, typeof(IActionResult));
        //}
    }
}
