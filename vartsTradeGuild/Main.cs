using System.IO;
using System.Text;
using System.Xml;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using vartsTradeGuild.behavior;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild
{
    public class Main : MBSubModuleBase
    {
        public const string ModId = "vartsTradeGuild";
        private static readonly string ModConfigPath = Utilities.GetConfigsPath() + ModId + ".xml";

        private static string _guildName;

        private static readonly Harmony Harmony = new Harmony(nameof(vartsTradeGuild));

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            Harmony.PatchAll();
            Initialize();
//            Module.CurrentModule.AddInitialStateOption(new InitialStateOption(ModId, LocalizationManager.ModName, 9999,
//                () => ScreenManager.PushScreen(ViewCreatorManager.CreateScreenView<VartsMainMenuGauntletScreenBase>()),
//                false));
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

            ((CampaignGameStarter) gameStarterObject).AddGameMenu(ModId,
                LocalizationManager.TownMainMenuText.ToString(), ModMenuInitDelegate);
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenEncyclopediaBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenConfigBehavior());
//            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenLeaderboardCaravanBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuOpenLeaderboardWorkshopBehavior());
            ((CampaignGameStarter) gameStarterObject).AddBehavior(new VartsMenuLeaveBehavior());

            ((CampaignGameStarter) gameStarterObject).AddBehavior(new TownOpenVartsMenuBehavior());

            InformationManager.DisplayMessage(
                new InformationMessage(LocalizationManager.ModLoadedInformation.ToString()));
        }

        private static void ModMenuInitDelegate(MenuCallbackArgs args)
        {
            args.MenuTitle = LocalizationManager.ModName;
        }


        private static void Initialize()
        {
            if (!File.Exists(ModConfigPath))
            {
                SaveConfig();
            }
            else
            {
                var xmlTextReader = new XmlTextReader(ModConfigPath);
                while (xmlTextReader.Read())
                {
                    if (!xmlTextReader.IsStartElement())
                    {
                        continue;
                    }

                    if (xmlTextReader.Name == "GuildName")
                    {
                        _guildName = xmlTextReader.ReadString();
                    }
                }
            }
        }

        public static void ResetConfig()
        {
            _guildName = "VARTS";
            SaveConfig();
        }

        private static void SaveConfig()
        {
            var xmlTextWriter = new XmlTextWriter(ModConfigPath, Encoding.UTF8)
            {
                Formatting = Formatting.Indented
            };
            xmlTextWriter.WriteStartElement("VARTS");
            xmlTextWriter.WriteElementString("GuildName", _guildName);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();
        }

        public static void SetGuildName(string newGuildName)
        {
            _guildName = newGuildName;
            SaveConfig();
        }

        public static string GetGuildName()
        {
            return _guildName;
        }
    }
}