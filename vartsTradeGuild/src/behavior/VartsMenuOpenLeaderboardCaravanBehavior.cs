using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuOpenLeaderboardCaravanBehavior : VartsMenuOptionBehaviorBase
    {
        public static bool IsTryingToOpenLeaderboard;

        public VartsMenuOpenLeaderboardCaravanBehavior() : base(Main.ModId, "OpenLeaderboardCaravan",
            LocalizationManager.MainMenuOpenLeaderboardCaravanOption.ToString(), GameMenuOption.LeaveType.BribeAndEscape, false)
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