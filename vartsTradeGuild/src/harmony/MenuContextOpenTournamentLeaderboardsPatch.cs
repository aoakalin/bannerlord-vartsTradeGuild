using System.Reflection;
using HarmonyLib;
using SandBox.GauntletUI.Menu;
using SandBox.View.Menu;
using TaleWorlds.CampaignSystem;
using vartsTradeGuild.behavior;
using vartsTradeGuild.gauntlet.menuView;

namespace vartsTradeGuild.harmony
{
    [HarmonyPatch(typeof(MenuContext), "OpenTournamentLeaderboards")]
    public class MenuContextOpenTournamentLeaderboardsPatch
    {
        private static bool Prefix(MenuContext __instance)
        {
            var handlerField = typeof(MenuContext).GetField("_handler",
                BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            if (handlerField == null)
            {
                return false;
            }

            var handler = (MenuViewContext) handlerField.GetValue(__instance);
            var menuTournamentLeaderboardField = typeof(MenuViewContext).GetField("_menuTournamentLeaderboard",
                BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
            if (menuTournamentLeaderboardField == null)
            {
                return false;
            }

            MenuView menuTournamentLeaderboard;
            if (VartsMenuOpenLeaderboardWorkshopBehavior.IsTryingToOpenLeaderboard)
            {
                menuTournamentLeaderboard = handler.AddMenuView<VartsLeaderboardWorkshopMenuView>();
            }
            else if (VartsMenuOpenLeaderboardHeroBehavior.IsTryingToOpenLeaderboard)
            {
                menuTournamentLeaderboard = handler.AddMenuView<VartsLeaderboardHeroMenuView>();
            }
            else
            {
                menuTournamentLeaderboard = handler.AddMenuView<GauntletMenuTournamentLeaderboard>();
            }

            menuTournamentLeaderboardField.SetValue(handler, menuTournamentLeaderboard);
            handlerField.SetValue(__instance, handler);
            return false;
        }
    }
}