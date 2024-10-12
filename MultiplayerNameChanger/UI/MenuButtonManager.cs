using System;

using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.Settings;

using Zenject;


namespace MultiplayerNameChanger.UI {


    internal class MenuButtonManager : IInitializable, IDisposable {

        internal readonly MenuTransitionsHelper _helper;

        private readonly MenuButton _menuButton;
        private readonly SetNameFlowCoordinator _setNameFlowCoordinator;
        private readonly Settings _settings;

        public MenuButtonManager(SetNameFlowCoordinator setNameFlowCoordinator, Settings settings) {
            _setNameFlowCoordinator = setNameFlowCoordinator;
            _menuButton = new MenuButton("Name Changer", "Change your Multiplayer name here!", SummonFlowCoordinator);
            _settings = settings;
        }

        public void Initialize() {
            MenuButtons.Instance.RegisterButton(_menuButton);
            BSMLSettings.Instance.AddSettingsMenu("Name Changer", "MultiplayerNameChanger.Views.SettingsView.bsml", _settings);
        }

        public void Dispose() {
            MenuButtons.Instance.UnregisterButton(_menuButton);
        }

        private void SummonFlowCoordinator() {
            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(_setNameFlowCoordinator);
        }
    }
}
