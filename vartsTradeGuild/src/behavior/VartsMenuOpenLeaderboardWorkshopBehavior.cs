using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.src.behavior.@base;
using vartsTradeGuild.src.localization;

namespace vartsTradeGuild.src.behavior
{
    public class VartsMenuOpenLeaderboardWorkshopBehavior : VartsMenuOptionBehaviorBase
    {
        public static bool IsTryingToOpenLeaderboard = false;

        public VartsMenuOpenLeaderboardWorkshopBehavior() : base(Main.ModId, "OpenLeaderboardWorkshop",
            LocalizationManager.MainMenuOpenLeaderboardWorkshopOption.ToString(), GameMenuOption.LeaveType.Trade, false)
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