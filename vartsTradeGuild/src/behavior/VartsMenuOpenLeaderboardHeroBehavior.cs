using TaleWorlds.CampaignSystem.GameMenus;
using vartsTradeGuild.src.behavior.@base;
using vartsTradeGuild.src.localization;

namespace vartsTradeGuild.src.behavior
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