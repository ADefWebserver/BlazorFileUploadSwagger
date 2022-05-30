using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorFileUploadSwagger.Controllers
{
    /// <summary>
    /// An example controller for testing <code>multipart/form-data</code> submission
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController()
        {

        }

        /// <summary>
        /// Submit a form which contains a key-value pair and a file.
        /// </summary>
        /// <param name="form">A form which contains the FormId and a file</param>
        /// <returns></returns>
        [HttpPost]
        public async void SubmitForm([FromForm] StudentForm form)
        {
            var id = form;
            await Task.Delay(1500);
        }
      
        /// <summary>
        /// View the form submission result
        /// </summary>
        public class StudentForm
        {
            /// <summary>
            /// FormId
            /// </summary>
            public int FormId { get; set; }
            /// <summary>
            /// Student File
            /// </summary>
            public IFormFile StudentFile { get; set; }
        }     
    }
}