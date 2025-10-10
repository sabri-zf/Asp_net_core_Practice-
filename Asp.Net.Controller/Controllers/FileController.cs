using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Controllers.Controllers
{
    public class FileController:ControllerBase
    {

        // File Action deal with file on Envierment virtual file  or on physical File (Bring up from local machaine)
        // File content (bring up the data as binary)

        [Route("File/download1")]
        // use VirtualFile when you want bring the data from enviroment directory
        public VirtualFileResult DownloadData1()
        {
            return File("/Simple.pdf", "application/pdf");
        }


        [Route("File/Download2")]
        // grap the file from loacl machine or any server where file resedently
        public PhysicalFileResult DownloadData2()
        {

            return PhysicalFile("B:\\Culture_Books\\Atomic Habits - James Clear 2018_0.pdf"
                , "application/pdf");
        }


        [Route("File/Download3")]
        // Brin up
        public FileContentResult DownloadData3()
        {
            byte[] Data = System.IO.File.ReadAllBytes("B:\\Culture_Books\\Atomic Habits - James Clear 2018_0.pdf");
            return new FileContentResult(Data, "application/pdf");
        }



    }
}
