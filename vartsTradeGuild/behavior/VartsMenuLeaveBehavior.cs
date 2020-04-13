using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuLeaveBehavior : VartsMenuOptionBehaviorBase
    {
        public VartsMenuLeaveBehavior() : base(Main.ModId, "Leave",
            LocalizationManager.MainMenuLeaveOption.ToString(), GameMenuOption.LeaveType.Leave, true)
        {
        }

        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            PlayerEncounter.LeaveSettlement();
            PlayerEncounter.Finish();
        }
    }
}