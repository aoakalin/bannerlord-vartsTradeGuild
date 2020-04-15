using SandBox.View.Menu;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Missions;
using vartsTradeGuild.gauntlet.viewModel;

namespace vartsTradeGuild.gauntlet.menuView
{
    [OverrideView(typeof(MenuTournamentLeaderboard))]
    public class VartsLeaderboardHeroMenuView : MenuView
    {
        private GauntletLayer _gauntletLayer;
        private VartsLeaderboardWorkshopVM _dataSource;
        private GauntletMovie _movie;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            this._dataSource = new VartsLeaderboardWorkshopVM()
            {
                IsEnabled = true
            };
            GauntletLayer gauntletLayer = new GauntletLayer(205, "GauntletLayer");
            gauntletLayer.Name = "VartsLeaderboardHeroMenuView";
            this._gauntletLayer = gauntletLayer;
            this._gauntletLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.All);
            this._gauntletLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
            this._movie =
                this._gauntletLayer.LoadMovie("GauntletMenuLeaderboardWorkshopMovie", (ViewModel) this._dataSource);
            this._gauntletLayer.IsFocusLayer = true;
            ScreenManager.TrySetFocus((ScreenLayer) this._gauntletLayer);
            this.MenuViewContext.AddLayer((ScreenLayer) this._gauntletLayer);
        }

        protected override void OnFinalize()
        {
            this._gauntletLayer.IsFocusLayer = false;
            ScreenManager.TryLoseFocus((ScreenLayer) this._gauntletLayer);
            this._dataSource.OnFinalize();
            this._dataSource = (VartsLeaderboardWorkshopVM) null;
            this._gauntletLayer.ReleaseMovie(this._movie);
            this.MenuViewContext.RemoveLayer((ScreenLayer) this._gauntletLayer);
            this._movie = (GauntletMovie) null;
            this._gauntletLayer = (GauntletLayer) null;
            base.OnFinalize();
        }

        protected override void OnFrameTick(float dt)
        {
            base.OnFrameTick(dt);
            this._gauntletLayer.Input.IsHotKeyReleased("Exit");
            if (this._gauntletLayer.Input.IsHotKeyReleased("Exit"))
                this._dataSource.IsEnabled = false;
            if (this._dataSource.IsEnabled)
                return;
            this.MenuViewContext.CloseTournamentLeaderboard();
        }
    }
}