using MvvmScarletToolkit;
using MvvmScarletToolkit.FileSystemBrowser;

namespace Maple.Core
{
    public class FileSystemInfoChangedMessage : GenericScarletMessage<IFileSystemInfo>
    {
        public FileSystemInfoChangedMessage(object sender, IFileSystemInfo info)
            : base(sender, info)
        {
        }
    }
}
