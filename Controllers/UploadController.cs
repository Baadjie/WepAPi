using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebApiApplication.Controllers
{
    public class UploadController : ApiController
    {
        // [System.Web.Http.Route("api/Files/Upload")]
        [HttpPost]
        public async Task<String> Post()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if(httpRequest.Files.Count > 0)
                {
                    foreach(string file in httpRequest.Files)
                    {

                        var postedFile = httpRequest.Files[file];
                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        var filePath = "C:\\Training_Document\\" + fileName;
                        postedFile.SaveAs(filePath);

                        ClaimDbHelper claimDbHelper = new ClaimDbHelper();
                        File files = new File();

                        files.FileName = fileName;
                       files.filePath = filePath;
                        claimDbHelper.UploadFile(files);



                        return fileName +"  "+ "Uploaded Succesfull";

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