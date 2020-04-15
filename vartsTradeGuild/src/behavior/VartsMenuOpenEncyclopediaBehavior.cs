using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
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