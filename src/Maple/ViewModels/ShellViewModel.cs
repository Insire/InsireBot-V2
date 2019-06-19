using System;
using MvvmScarletToolkit.Observables;

namespace Maple
{
    public sealed class ShellViewModel : ObservableObject
    {
        private MetaDataViewModel _metaDataViewModel;
        public MetaDataViewModel MetaDataViewModel
        {
            get { return _metaDataViewModel; }
            private set { SetValue(ref _metaDataViewModel, value); }
        }

        private NavigationViewModel _navigationViewModel;
        public NavigationViewModel NavigationViewModel
        {
            get { return _navigationViewModel; }
            private set { SetValue(ref _navigationViewModel, value); }
        }

        private LocalizationsViewModel _localizations;
        public LocalizationsViewModel Localizations
        {
            get { return _localizations; }
            private set { SetValue(ref _localizations, value); }
        }

        private DialogViewModel _dialogViewModel;
        public DialogViewModel DialogViewModel
        {
            get { return _dialogViewModel; }
            private set { SetValue(ref _dialogViewModel, value); }
        }

        private Playlists _playlists;
        public Playlists Playlists
        {
            get { return _playlists; }
            private set { SetValue(ref _playlists, value); }
        }

        private MediaPlayers _mediaPlayers;
        public MediaPlayers MediaPlayers
        {
            get { return _mediaPlayers; }
            private set { SetValue(ref _mediaPlayers, value); }
        }

        private OptionsViewModel _optionsViewModel;
        public OptionsViewModel OptionsViewModel
        {
            get { return _optionsViewModel; }
            private set { SetValue(ref _optionsViewModel, value); }
        }

        public ShellViewModel(LocalizationsViewModel localizationsViewModel,
                                NavigationViewModel navigationViewModel,
                                MetaDataViewModel metaDataViewModel,
                                DialogViewModel dialogViewModel,
                                Playlists playlists,
                                MediaPlayers mediaPlayers,
                                OptionsViewModel optionsViewModel)
        {
            Localizations = localizationsViewModel ?? throw new ArgumentNullException(nameof(localizationsViewModel));
            NavigationViewModel = navigationViewModel ?? throw new ArgumentNullException(nameof(navigationViewModel));
            MetaDataViewModel = metaDataViewModel ?? throw new ArgumentNullException(nameof(metaDataViewModel));
            DialogViewModel = dialogViewModel ?? throw new ArgumentNullException(nameof(dialogViewModel));
            Playlists = playlists ?? throw new ArgumentNullException(nameof(playlists));
            MediaPlayers = mediaPlayers ?? throw new ArgumentNullException(nameof(mediaPlayers));
            OptionsViewModel = optionsViewModel ?? throw new ArgumentNullException(nameof(optionsViewModel));
        }
    }
}
