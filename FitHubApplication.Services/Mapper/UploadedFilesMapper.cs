using FitHubApplication.Models.Entities;

namespace FitHubApplication.Services.Mapper
{
    public static class UploadedFilesMapper
    {
        public static UploadedFilesDto EntityToDto(this UploadedFiles file) 
        {
            return new UploadedFilesDto
            {
                Id = file.Id,
                FileExtension = file.FileExtension,
                FileName = file.FileName,
                FilePath = file.FilePath,
                OriginalFileName = file.OriginalFileName,
                MimeType = file.MimeType,
            };
        }

        public static UploadedFiles CreateDtoToEntity(this CreateUploadedFilesDto file)
        {
            return new UploadedFiles
            {
                FileExtension = file.FileExtension,
                FileName = file.FileName,
                FilePath = file.FilePath,
                OriginalFileName = file.OriginalFileName,
                MimeType = file.MimeType,
            };
        }

        public static UploadedFiles DtoToEntity(this UploadedFilesDto file)
        {
            return new UploadedFiles
            {
                Id = file.Id,
                FileExtension = file.FileExtension,
                FileName = file.FileName,
                FilePath = file.FilePath,
                OriginalFileName = file.OriginalFileName,
                MimeType = file.MimeType,
            };
        }
    }
}
