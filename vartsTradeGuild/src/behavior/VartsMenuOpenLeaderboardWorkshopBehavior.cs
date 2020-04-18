using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuOpenLeaderboardWorkshopBehavior : VartsMenuOptionBehaviorBase
    {
        public static bool IsTryingToOpenLeaderboard;

        public VartsMenuOpenLeaderboardWorkshopBehavior() : base(Main.ModId, "OpenLeaderboardWorkshop",
            LocalizationManager.MainMenuOpenLeaderboardWorkshopOption.ToString(), GameMenuOption.LeaveType.Craft, false)
        {
        }

        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            IsTryingToOpenLeaderboard = true;

            args.MenuContext.OpenTournamentLeaderboards();

            IsTryingToOpenLeaderboard = false;
        }
    }
}