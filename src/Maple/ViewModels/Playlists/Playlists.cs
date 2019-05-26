using System;
using System.Linq;
using System.Threading.Tasks;

using Maple.Core;
using Maple.Domain;
using Maple.Localization.Properties;

namespace Maple
{
    public sealed class Playlists : MapleBusinessViewModelListBase<Playlist, PlaylistModel>, IPlaylistsViewModel
    {
        private readonly Func<IUnitOfWork> _repositoryFactory;

        public Playlists(Func<IUnitOfWork> repositoryFactory)
            : base(container)
        {
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));

            AddCommand = AsyncCommand.Create(Add, CanAdd);
        }

        private async Task SaveInternal()
        {
            _log.Info($"{LocalizationService.Translate(nameof(Resources.Saving))} {LocalizationService.Translate(nameof(Resources.Playlists))}");
            using (var context = _repositoryFactory())
            {
                foreach (var item in Items)
                    context.PlaylistRepository.Update(item.Model);

                await context.SaveChanges().ConfigureAwait(false);
            }
        }

        public Task Add()
        {
            Add(_playlistMapper.GetNewPlaylist());
            return Save();
        }

        public bool CanAdd()
        {
            return Items != null;
        }

        public override Task Save()
        {
            return SaveInternal();
        }

        public override async Task Load()
        {
            Log.Info($"{LocalizationService.Translate(nameof(Resources.Loading))} {LocalizationService.Translate(nameof(Resources.Playlists))}");
            Clear();

            using (var context = _repositoryFactory())
            {
                var result = await context.PlaylistRepository.ReadAsync(null, new[] { nameof(PlaylistModel.MediaItems) }, -1, -1).ConfigureAwait(true);

                if (result.Count > 0)
                {
                    AddRange(_playlistMapper.GetMany(result));
                }
                else
                {
                    await Add();
                }
            }

            SelectedItem = Items.FirstOrDefault();

            OnLoaded();
        }
    }
}