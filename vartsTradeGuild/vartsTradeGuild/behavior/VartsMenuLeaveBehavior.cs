using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuLeaveBehavior : VartsMenuOptionBehaviorBase
    {
        public VartsMenuLeaveBehavior() : base(Main.ModId, "Leave",
            "I will come back another time.", GameMenuOption.LeaveType.Leave, true)
        {
        }

        protected override void OnMenuOptionClicked()
        {
            PlayerEncounter.LeaveSettlement();
            PlayerEncounter.Finish();
        }
    }
}