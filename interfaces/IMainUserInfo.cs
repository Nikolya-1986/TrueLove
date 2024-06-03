using Love.Models;

namespace Love.interfaces
{
    public interface IMainUserInfo
    {
        IEnumerable<MainUserInfo> getMainUserInfo { get; }
    }
}
