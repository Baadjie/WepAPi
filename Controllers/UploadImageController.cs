using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApiApplication.Controllers
{
    public class UploadImageController : ApiController
    {
        [HttpPost]
        public async Task<String> Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {

                        var postedFile = httpRequest.Files[file];
                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        var filePath = "C:\\Training_Document\\" + fileName;
                        postedFile.SaveAs(filePath);

                  


                        return fileName + "  " + "Uploaded Succesfull";

                    }
                }


            }


            catch (Exception exception)
            {

                return exception.Message;

            }

            return "No files";
        }


    }
}