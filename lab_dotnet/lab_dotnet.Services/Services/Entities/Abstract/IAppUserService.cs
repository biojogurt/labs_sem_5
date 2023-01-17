using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IAppUserService
{
    AppUserModel GetAppUser(Guid id);

    AppUserModel UpdateAppUser(Guid id, UpdateAppUserModel appUser);

    void DeleteAppUser(Guid id);

    PageModel<AppUserPreviewModel> GetAppUsers(int limit = 20, int offset = 0);

    PageModel<AppUserPreviewModel> GetAppUsersByJobTitleId(Guid jobTitleId, int limit = 20, int offset = 0);

    PageModel<AppUserPreviewModel> GetAppUsersByAccessLevel(int accessLevel, int limit = 20, int offset = 0);
}