namespace BlazorFileUploadSwagger.Models
{
    /// <summary>
    /// Upload Form
    /// </summary>
    public class UploadForm
    {
        /// <summary>
        /// File Directory
        /// </summary>
        public string FileDirectory { get; set; }

        /// <summary>
        /// File Attachment
        /// </summary>
        public IFormFile FileAttachment { get; set; }

        /// <summary>
        /// File Attachments
        /// </summary>
        public List<IFormFile> FileAttachments { get; set; }
    }
}
