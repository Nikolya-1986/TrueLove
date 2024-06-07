using Love.Models;

namespace Love.interfaces
{
    public interface IMainUserInfo
    {
        IEnumerable<MainUserInfo> AllUserInfo { get; }
        MainUserInfo getMainUserInfo(string UserEmail);
    }
}
