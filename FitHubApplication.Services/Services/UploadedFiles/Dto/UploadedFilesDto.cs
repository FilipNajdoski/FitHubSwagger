namespace FitHubApplication.Services
{
    public class UploadedFilesDto
    {
        public int Id { get; set; }

        public string FileExtension { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string OriginalFileName { get; set; }

        public string MimeType { get; set; }
    }
}
