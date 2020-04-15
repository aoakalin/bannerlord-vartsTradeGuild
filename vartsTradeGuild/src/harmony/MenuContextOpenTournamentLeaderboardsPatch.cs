using System.Reflection;
using HarmonyLib;
using SandBox.View.Menu;
using TaleWorlds.CampaignSystem;
using vartsTradeGuild.behavior;

namespace vartsTradeGuild.harmony
{
    [HarmonyPatch(typeof(MenuContext), "OpenTournamentLeaderboards")]
    public class MenuContextOpenTournamentLeaderboardsPatch
    {
        private static bool Prefix(MenuContext __instance)
        {
            if (VartsMenuOpenLeaderboardWorkshopBehavior.IsTryingToOpenLeaderboard == false &&
                VartsMenuOpenLeaderboardHeroBehavior.IsTryingToOpenLeaderboard == false)
            {
                return true;
            }

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

            var menuTournamentLeaderboard = VartsMenuOpenLeaderboardWorkshopBehavior.IsTryingToOpenLeaderboard
                ? handler.AddMenuView<GauntletMenuLeaderboardWorkshop>()
                : handler.AddMenuView<GauntletMenuLeaderboardHero>();
            menuTournamentLeaderboardField.SetValue(handler, menuTournamentLeaderboard);
            handlerField.SetValue(__instance, handler);
            return false;
        }
    }
}