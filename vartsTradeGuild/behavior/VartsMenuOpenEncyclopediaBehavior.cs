using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuOpenEncyclopediaBehavior : VartsMenuOptionBehaviorBase
    {
        public VartsMenuOpenEncyclopediaBehavior() : base(Main.ModId, "OpenEncyclopedia",
            "I have a question...", GameMenuOption.LeaveType.Trade, false)
        {
        }

        protected override void OnMenuOptionClicked()
        {
            Campaign.Current.EncyclopediaManager.GoToLink("ListPage", "VartsDto");

            //todo debugModeControl
//            if (true)
//            {
//                var workshopTypeDtoDebugData = WorkshopTypeDto.DumpDebugData();
//                var villageDtoDebugData = VillageDto.DumpDebugData();
//
//                InformationManager.DisplayMessage(new InformationMessage(Main.ModName + " debug mode"));
//            }
        }
    }
}