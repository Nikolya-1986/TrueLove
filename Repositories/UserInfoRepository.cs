using Love.DbContext;
using Love.Models;
using Microsoft.EntityFrameworkCore;

namespace Love.Repositories
{
    public class UserInfoRepository
    {
        private readonly TrueLoveDbContext trueLoveDbContext;
        public UserInfoRepository(TrueLoveDbContext trueLoveDbContext)
        {
            this.trueLoveDbContext = trueLoveDbContext;
        }

        // public IEnumerable<MainUserInfo> getMainUserInfo
        // {
        //     get => trueLoveDbContext.MainUserInfo.ToList();
        // }
    }
}