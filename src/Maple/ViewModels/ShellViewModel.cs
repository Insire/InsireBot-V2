using System;
using Maple.Localization.Properties;
using MvvmScarletToolkit.Abstractions;
using MvvmScarletToolkit.Observables;

namespace Maple
{
    public class ShellViewModel : ObservableObject
    {
        private StatusbarViewModel _statusbarViewModel;
        public StatusbarViewModel StatusbarViewModel
        {
            get { return _statusbarViewModel; }
            private set { SetValue(ref _statusbarViewModel, value); }
        }

        private Scenes _scenes;
        public Scenes Scenes
        {
            get { return _scenes; }
            private set { SetValue(ref _scenes, value); }
        }

        private ILocalizationService _translationManager;
        public ILocalizationService TranslationManager
        {
            get { return _translationManager; }
            private set { SetValue(ref _translationManager, value); }
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

        public ShellViewModel(ILocalizationService translationManager,
                                Scenes scenes,
                                StatusbarViewModel statusBarViewModel,
                                DialogViewModel dialogViewModel,
                                Playlists playlists,
                                MediaPlayers mediaPlayers,
                                OptionsViewModel optionsViewModel)
        {
            TranslationManager = translationManager ?? throw new ArgumentNullException(nameof(translationManager), $"{nameof(translationManager)} {Resources.IsRequired}");
            Scenes = scenes ?? throw new ArgumentNullException(nameof(scenes), $"{nameof(scenes)} {Resources.IsRequired}");
            StatusbarViewModel = statusBarViewModel ?? throw new ArgumentNullException(nameof(statusBarViewModel), $"{nameof(statusBarViewModel)} {Resources.IsRequired}");
            DialogViewModel = dialogViewModel ?? throw new ArgumentNullException(nameof(dialogViewModel), $"{nameof(dialogViewModel)} {Resources.IsRequired}");
            Playlists = playlists ?? throw new ArgumentNullException(nameof(playlists), $"{nameof(playlists)} {Resources.IsRequired}");
            MediaPlayers = mediaPlayers ?? throw new ArgumentNullException(nameof(mediaPlayers), $"{nameof(mediaPlayers)} {Resources.IsRequired}");
            OptionsViewModel = optionsViewModel ?? throw new ArgumentNullException(nameof(optionsViewModel), $"{nameof(optionsViewModel)} {Resources.IsRequired}");
        }
    }
}
