namespace BlazorFileUploadSwagger.Models
{
    /// <summary>
    /// View the form submission result
    /// </summary>
    public class TestForm
    {
        /// <summary>
        /// FormId
        /// </summary>
        public int FormId { get; set; }

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
