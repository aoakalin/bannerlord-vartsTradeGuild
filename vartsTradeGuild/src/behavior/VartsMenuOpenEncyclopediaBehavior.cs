using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.src.behavior.@base;
using vartsTradeGuild.src.localization;

namespace vartsTradeGuild.src.behavior
{
    public class VartsMenuOpenEncyclopediaBehavior : VartsMenuOptionBehaviorBase
    {
        public VartsMenuOpenEncyclopediaBehavior() : base(Main.ModId, "OpenEncyclopedia",
            LocalizationManager.MainMenuOpenEncyclopediaOption.ToString(), GameMenuOption.LeaveType.Trade, false)
        {
        }

        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            Campaign.Current.EncyclopediaManager.GoToLink("ListPage", "VartsDto");
        }
    }
}