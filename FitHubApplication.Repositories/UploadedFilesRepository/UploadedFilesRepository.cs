using FitHubApplication.Models;
using FitHubApplication.Models.Entities;

namespace FitHubApplication.Repositories
{
    public class UploadedFilesRepository : FitHubBaseRepository<UploadedFiles>, IUploadedFilesRepository
    {
        public UploadedFilesRepository(FitHubDbContext context) : base(context)
        {

        }

    }
}
