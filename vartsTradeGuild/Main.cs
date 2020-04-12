using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using vartsTradeGuild.behavior;
using vartsTradeGuild.encyclopedia.dto;

namespace vartsTradeGuild
{
    public class Main : MBSubModuleBase
    {
        private static readonly Harmony harmony = new Harmony(nameof(vartsTradeGuild));

        public const string ModId = "vartsTradeGuild";
        public const string ModName = "VARTS Trade Guild";

        public const string ModMenuText =
            "VARTS Trade Guild Agent: Welcome, my friend. I can answer all your trade related questions.";

        public const string ModDescription =
            "VARTS Trade Guild can answer all your trade related questions.";

        public const string ModImageID = "EncyclopediaSettlement";

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            harmony.PatchAll();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
            harmony.UnpatchAll(nameof(vartsTradeGuild));
        }
        
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (!(game.GameType is Campaign))
            {
                return;
            }

            Game.Current.ObjectManager.RegisterNonSerializedType<VartsDto>("VartsDto", "VartsDtoList");

            ((CampaignGameStarter) gameStarterObject).AddGameMenu(ModId, ModMenuText, ModMenuInitDelegate);
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenEncyclopediaBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuLeaveBehavior());

            ((CampaignGameStarter) gameStarterObject).AddBehavior(new TownOpenVartsMenuBehavior());

            InformationManager.DisplayMessage(new InformationMessage(ModName + " loaded"));
        }

        private static void ModMenuInitDelegate(MenuCallbackArgs args)
        {
            args.MenuTitle = new TextObject(ModName);
        }
    }
}