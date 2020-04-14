using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.GauntletUI.Data;
using vartsTradeGuild.src.gauntlet.viewModel;

namespace vartsTradeGuild.src.gauntlet.screenBase
{
    public class VartsMainMenuGauntletScreenBase : ScreenBase
    {
        private VartsMainMenuGauntletViewModel _dataSource;
        private GauntletLayer _gauntletLayer;
        private GauntletMovie _gauntletMovie;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _dataSource = new VartsMainMenuGauntletViewModel();
            _gauntletLayer = new GauntletLayer(100)
            {
                IsFocusLayer = true
            };
            AddLayer(_gauntletLayer);
            _gauntletLayer.InputRestrictions.SetInputRestrictions();
            _gauntletMovie= _gauntletLayer.LoadMovie("VartsMainMenuGauntletScreenBaseMovie", _dataSource);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ScreenManager.TrySetFocus(_gauntletLayer);
        }

        protected override void OnDeactivate()
        {
            base.OnDeactivate();
            _gauntletLayer.IsFocusLayer = false;
            ScreenManager.TryLoseFocus(_gauntletLayer);
        }

        protected override void OnFinalize()
        {
            base.OnFinalize();
            RemoveLayer(_gauntletLayer);
            _dataSource = null;
            _gauntletLayer = null;
        }
    }
}