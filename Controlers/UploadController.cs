using BlazorFileUploadSwagger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFileUploadSwagger.Controllers
{
    /// <summary>
    /// An Upload controller for <code>multipart/form-data</code> submission
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private string _SystemFiles;

        public UploadController(
            IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

            // Set _SystemFiles 
            _SystemFiles =
                System.IO.Path.Combine(
                    hostEnvironment.ContentRootPath,
                    "Files");

            // Create SystemFiles directory if needed
            if (!Directory.Exists(_SystemFiles))
            {
                DirectoryInfo di =
                    Directory.CreateDirectory(_SystemFiles);
            }
        }

        /// <summary>
        /// Upload
        /// </summary>
        /// <param name="form">A form</param>
        /// <returns></returns>
        //JwtBearerDefaults means this method will only work if a Jwt is being passed
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public void UploadAPI([FromForm] UploadForm form)
        {
            // Get File Directory
            string FileDirectory = form.FileDirectory;

            // Set _SystemFiles
            _SystemFiles = System.IO.Path.Combine(_SystemFiles, FileDirectory);

            // Create SystemFiles directory if needed
            if (!Directory.Exists(_SystemFiles))
            {
                DirectoryInfo di =
                    Directory.CreateDirectory(_SystemFiles);
            }

            // Process File Attachment
            if (form.FileAttachment != null)
            {
                using (var readStream = form.FileAttachment.OpenReadStream())
                {
                    var filename = form.FileAttachment.FileName.Replace("\"", "").ToString();

                    filename = _SystemFiles + $@"\{filename}";

                    //Save file to harddrive
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        form.FileAttachment.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }

            // Process all File Attachments
            if (form.FileAttachments != null)
            {
                foreach (var file in form.FileAttachments)
                {
                    // Process file
                    using (var readStream = file.OpenReadStream())
                    {
                        var filename = file.FileName.Replace("\"", "").ToString();

                        filename = _SystemFiles + $@"\{filename}";

                        //Save file to harddrive
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
        }    
    }
}