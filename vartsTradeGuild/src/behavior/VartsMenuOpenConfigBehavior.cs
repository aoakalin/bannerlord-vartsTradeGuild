using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Engine.Screens;
using TaleWorlds.MountAndBlade.View.Missions;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.gauntlet.screenBase;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuOpenConfigBehavior : VartsMenuOptionBehaviorBase
    {
        public VartsMenuOpenConfigBehavior() : base(Main.ModId, "OpenConfig",
            LocalizationManager.MainMenuOpenConfigOption.ToString(), GameMenuOption.LeaveType.Surrender, false)
        {
        }

        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            ScreenManager.PushScreen(ViewCreatorManager.CreateScreenView<VartsConfigMenuScreenBase>());
        }
    }
}