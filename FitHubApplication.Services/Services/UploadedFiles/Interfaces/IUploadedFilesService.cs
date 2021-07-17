using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitHubApplication.Services
{
    public interface IUploadedFilesService
    {
        Task<UploadedFilesDto> Create(CreateUploadedFilesDto file);

        Task<List<UploadedFilesDto>> Search(UploadedFilesSearchInput input);

        Task<UploadedFilesDto> GetById(int id);
    }
}
