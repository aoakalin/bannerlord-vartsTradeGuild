using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.src.behavior.@base;
using vartsTradeGuild.src.localization;

namespace vartsTradeGuild.src.behavior
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