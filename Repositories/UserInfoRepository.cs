using Love.DbContext;
using Love.interfaces;
using Love.Models;

namespace Love.Repositories
{
    public class UserInfoRepository: IMainUserInfo
    {
        private readonly TrueLoveDbContext trueLoveDbContext;
        public UserInfoRepository(TrueLoveDbContext trueLoveDbContext)
        {
            this.trueLoveDbContext = trueLoveDbContext;
        }

        public IEnumerable<MainUserInfo> getMainUserInfo
        {
            get => trueLoveDbContext.MainUserInfo.ToList();
        }
    }
}