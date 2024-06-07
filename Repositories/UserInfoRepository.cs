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

        public IEnumerable<MainUserInfo> AllUserInfo
        {
            get => trueLoveDbContext.MainUserInfo.ToList();
        }

        public MainUserInfo getMainUserInfo(string UserEmail)
        {
            return trueLoveDbContext.MainUserInfo.FirstOrDefault(item => item.userEmail == UserEmail);
        }
    }
}