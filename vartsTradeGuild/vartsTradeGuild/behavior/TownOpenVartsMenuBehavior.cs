using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;

namespace vartsTradeGuild.behavior
{
    public class TownOpenVartsMenuBehavior : VartsMenuOptionBehaviorBase
    {
        public TownOpenVartsMenuBehavior() : base("town", Main.ModId, "Visit VARTS Trade Guild",
            GameMenuOption.LeaveType.Trade, false)
        {
        }

        protected override void OnMenuOptionClicked()
        {
            GameMenu.ActivateGameMenu(Main.ModId);
        }
    }
}