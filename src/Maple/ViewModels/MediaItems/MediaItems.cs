using MvvmScarletToolkit;
using MvvmScarletToolkit.Observables;

namespace Maple
{
    public sealed class MediaItems : ViewModelListBase<MediaItem>
    {
        public MediaItems(IScarletCommandBuilder commandBuilder)
            : base(commandBuilder)
        {
        }
    }
}
