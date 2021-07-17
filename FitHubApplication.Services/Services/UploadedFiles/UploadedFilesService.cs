using FitHubApplication.Models.Entities;
using FitHubApplication.Repositories;
using FitHubApplication.Services.Extensions;
using FitHubApplication.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public class UploadedFilesService : IUploadedFilesService
    {
        private readonly IUploadedFilesRepository uploadedFilesRepository;

        public UploadedFilesService(IUploadedFilesRepository uploadedFilesRepository)
        {
            this.uploadedFilesRepository = uploadedFilesRepository;
        }

        public async Task<UploadedFilesDto> Create(CreateUploadedFilesDto file)
        {
            UploadedFiles entity = await uploadedFilesRepository.Create(file.CreateDtoToEntity());
            return entity.EntityToDto();
        }

        public async Task<UploadedFilesDto> GetById(int id)
        {
            UploadedFiles file = await uploadedFilesRepository.GetFirstWhere(x => x.Id.Equals(id));

            return file.EntityToDto();
        }

        public async Task<List<UploadedFilesDto>> Search(UploadedFilesSearchInput input)
        {
            IQueryable<UploadedFiles> query = uploadedFilesRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.FileName), x => x.FileName.Contains(input.FileName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.OriginalFileName), x => x.OriginalFileName.Contains(input.OriginalFileName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.MimeType), x => x.MimeType.Contains(input.MimeType))
                .WhereIf(!string.IsNullOrWhiteSpace(input.FilePath), x => x.FilePath.Contains(input.FilePath))
                .WhereIf(!string.IsNullOrWhiteSpace(input.FileExtension), x => x.FileExtension.Contains(input.FileExtension));

            List<UploadedFilesDto> files = await query
                .Skip(input.SkipCount)
                .Take(input.TakeCount)
                .Select(x => x.EntityToDto())
                .ToListAsync();

            return files;
        }
    }
}
