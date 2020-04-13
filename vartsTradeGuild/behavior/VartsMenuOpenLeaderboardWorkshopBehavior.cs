using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using vartsTradeGuild.behavior.@base;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.behavior
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