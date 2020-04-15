using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.gauntlet.viewModel
{
    internal class VartsMainMenuGauntletViewModel : ViewModel
    {
        [DataSourceProperty]
        public string GuildName
        {
            get => Main.GetGuildName();
            set
            {
                if (value == Main.GetGuildName())
                    return;
                Main.SetGuildName(value);
                OnPropertyChanged(nameof(GuildName));
            }
        }

        public string MovieTextHeader => LocalizationManager.ModName.ToString();
        public string MovieTextDone => LocalizationManager.Save.ToString();
        public string MovieTextReset => LocalizationManager.Reset.ToString();
        public string MovieTextName => LocalizationManager.Name.ToString();

        public void MovieActionDone()
        {
            ScreenManager.PopScreen();
        }
    }
}