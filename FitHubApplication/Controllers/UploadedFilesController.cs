using FitHubApplication.Helpers;
using FitHubApplication.Models.Constants;
using FitHubApplication.Services;
using FitHubApplication.Services.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FitHubApplication.Controllers
{
    [Route(ApplicationConsts.ControllerConsts.DefaultControllerRoute)]
    [EnableCors(ApplicationConsts.CorsConsts.CorsPolicy)]
    [ApiController]
    [Authorize]
    public class UploadedFilesController : ControllerBase
    {
        private readonly IUploadedFilesService uploadedFilesService;
        private readonly IConfiguration configuration;

        public UploadedFilesController(IUploadedFilesService uploadedFilesService, IConfiguration configuration)
        {
            this.uploadedFilesService = uploadedFilesService;
            this.configuration = configuration;
        }

        /// <summary>
        /// Uploads a file
        /// </summary>
        /// <returns></returns>
        [HttpPost, Consumes(ApplicationConsts.ControllerConsts.MultipartFormData)]
        public async Task<ActionResult<int>> UploadFile()
        {
            string fileSystemPath = Path.Combine(Directory.GetCurrentDirectory(), configuration[ApplicationConsts.UploadFileConsts.FitHubFileSystemPath]);

            fileSystemPath.CreateDirectory();

            IFormFile file = Request.Form.Files.GetFile(ApplicationConsts.UploadFileConsts.FileRequesForm);

            string fileName = Path.GetFileName(file.FileName);

            FileInfo fileInfo = new FileInfo(fileName);

            string newFileName = fileInfo.Name.Replace(fileInfo.Extension, ApplicationConsts.UploadFileConsts.Underscore) + DateTime.Now.ToFileTimeUtc() + fileInfo.Extension;

            using (FileStream stream = new FileStream(Path.Combine(fileSystemPath, newFileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            CreateUploadedFilesDto createUploadedFilesDto = CreateUploadedFileDto(fileSystemPath, fileName, fileInfo, newFileName);

            UploadedFilesDto uploadedFilesDto = await uploadedFilesService.Create(createUploadedFilesDto);

            return Ok(uploadedFilesDto.Id);
        }

        private static CreateUploadedFilesDto CreateUploadedFileDto(string fileSystemPath, string fileName, FileInfo fileInfo, string newFileName)
        {
            return new CreateUploadedFilesDto()
            {
                FileName = newFileName,
                OriginalFileName = fileName,
                FileExtension = fileInfo.Extension,
                MimeType = MimeTypes.GetMimeType(fileName),
                FilePath = fileSystemPath + ApplicationConsts.UploadFileConsts.Slash + newFileName,
            };
        }
    }
}
