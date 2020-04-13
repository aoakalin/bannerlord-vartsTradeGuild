using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class TownOpenVartsMenuBehavior : VartsMenuOptionBehaviorBase
    {
        public TownOpenVartsMenuBehavior() : base("town", Main.ModId, LocalizationManager.TownMainMenuOption.ToString(),
            GameMenuOption.LeaveType.Trade, false)
        {
        }

        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            GameMenu.ActivateGameMenu(Main.ModId);
        }
    }
}