using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using vartsTradeGuild.behavior;
using vartsTradeGuild.encyclopedia.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild
{
    public class Main : MBSubModuleBase
    {
        public const string ModId = "vartsTradeGuild";

        private static readonly Harmony Harmony = new Harmony(nameof(vartsTradeGuild));

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            Harmony.PatchAll();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
            Harmony.UnpatchAll(nameof(vartsTradeGuild));
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (!(game.GameType is Campaign))
            {
                return;
            }

            Game.Current.ObjectManager.RegisterNonSerializedType<VartsDto>("VartsDto", "VartsDtoList");

            ((CampaignGameStarter) gameStarterObject).AddGameMenu(ModId, LocalizationManager.TownMainMenuText.ToString(), ModMenuInitDelegate);
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenEncyclopediaBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenLeaderboardHeroBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenLeaderboardWorkshopBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuLeaveBehavior());

            ((CampaignGameStarter) gameStarterObject).AddBehavior(new TownOpenVartsMenuBehavior());

            InformationManager.DisplayMessage(new InformationMessage(LocalizationManager.ModLoadedInformation.ToString()));
        }

        private static void ModMenuInitDelegate(MenuCallbackArgs args)
        {
            args.MenuTitle = LocalizationManager.ModName;
        }
    }
}