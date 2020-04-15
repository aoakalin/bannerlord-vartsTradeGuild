using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
{
    public class VartsMenuOpenLeaderboardHeroBehavior : VartsMenuOptionBehaviorBase
    {
        public static bool IsTryingToOpenLeaderboard = false;

        public VartsMenuOpenLeaderboardHeroBehavior() : base(Main.ModId, "OpenLeaderboardHero",
            LocalizationManager.MainMenuOpenLeaderboardHeroOption.ToString(), GameMenuOption.LeaveType.Trade, false)
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