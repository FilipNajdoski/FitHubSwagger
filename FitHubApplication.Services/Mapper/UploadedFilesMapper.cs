using FitHubApplication.Models.Entities;

namespace FitHubApplication.Services.Mapper
{
    public static class UploadedFilesMapper
    {
        /// <summary>
        /// Converts from <see cref="UploadedFiles"/> to <see cref="UploadedFilesDto"/>
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts from <see cref="CreateUploadedFilesDto"/> to <see cref="UploadedFiles"/>
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts from <see cref="UploadedFilesDto"/> to <see cref="UploadedFiles"/>
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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
