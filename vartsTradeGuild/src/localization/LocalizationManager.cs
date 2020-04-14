using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace vartsTradeGuild.src.localization
{
    public static class LocalizationManager
    {
        private static TextObject Translate(string id, bool isFullId = false)
        {
            TextObject translatedText;
            if (!isFullId)
            {
                var fullId = Main.ModId + "_" + id;
                var text = LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, fullId);
                if (!"VARTS".Equals(Main.GetGuildName()) && text.Contains("VARTS"))
                {
                    text = text.Replace("VARTS", Main.GetGuildName());
                }
                translatedText = new TextObject(text);
                translatedText.AddIDToValue(fullId);
            }
            else
            {
                var text = LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, id);
                if (!"VARTS".Equals(Main.GetGuildName()) && text.Contains("VARTS"))
                {
                    text = text.Replace("VARTS", Main.GetGuildName());
                }
                translatedText = new TextObject(text);
                translatedText.AddIDToValue(id);
            }
            
            return translatedText;
        }

        public static TextObject Town => Translate("bOTQ7Pta", true);
        public static TextObject Village => Translate("Ua6CNLBZ", true);
        public static TextObject Save => Translate("bV75iwKa", true);
        public static TextObject Cancel => Translate("3CpNUnVl", true);
        public static TextObject Reset => Translate("mAxXKaXp", true);
        public static TextObject Faction => Translate("enhza8zr", true);
        public static TextObject Name => Translate("PDdh1sBj", true);

        public static TextObject ModName => Translate("ModName");
        public static TextObject ModLoadedInformation => Translate("ModLoadedInformation");
        public static TextObject TownMainMenuOption => Translate("TownMainMenuOption");
        public static TextObject TownMainMenuText => Translate("TownMainMenuText");
        public static TextObject MainMenuLeaveOption => Translate("MainMenuLeaveOption");
        public static TextObject MainMenuOpenEncyclopediaOption => Translate("MainMenuOpenEncyclopediaOption");
        public static TextObject MainMenuChangeGuildNameOption => Translate("MainMenuChangeGuildNameOption");
        public static TextObject MainMenuOpenLeaderboardHeroOption => Translate("MainMenuOpenLeaderboardHeroOption");

        public static TextObject MainMenuOpenLeaderboardWorkshopOption =>
            Translate("MainMenuOpenLeaderboardWorkshopOption");

        public static TextObject EncyclopediaDefaultVartsPageName => Translate("EncyclopediaDefaultVartsPageName");

        public static TextObject EncyclopediaDefaultVartsPageDescription =>
            Translate("EncyclopediaDefaultVartsPageDescription");

        public static TextObject EncyclopediaVartsDtoFilterSettlementType =>
            Translate("EncyclopediaVartsDtoFilterSettlementType");

        public static TextObject EncyclopediaVartsDtoFilterWorkshopSuggestion =>
            Translate("EncyclopediaVartsDtoFilterWorkshopSuggestion");

        public static TextObject EncyclopediaVartsDtoFilterSuggestionStrength =>
            Translate("EncyclopediaVartsDtoFilterSuggestionStrength");

        public static TextObject EncyclopediaVartsDtoFilterVillageProduction =>
            Translate("EncyclopediaVartsDtoFilterVillageProduction");

        public static TextObject EncyclopediaVartsDtoFilterVillageBoundTown =>
            Translate("EncyclopediaVartsDtoFilterVillageBoundTown");
    }
}