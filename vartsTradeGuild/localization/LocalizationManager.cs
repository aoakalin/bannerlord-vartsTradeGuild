using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace vartsTradeGuild.localization
{
    public static class LocalizationManager
    {
        private static TextObject Translate(string id, bool isFullId = false)
        {
            TextObject translatedText; 
            if (!isFullId)
            {
                var fullId = Main.ModId + "_" + id;
                translatedText = new TextObject(LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, fullId));
                translatedText.AddIDToValue(fullId);
            }
            else
            {
                translatedText = new TextObject(LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, id));
                translatedText.AddIDToValue(id);
            }

            return translatedText;
        }
        public static TextObject Town => Translate("bOTQ7Pta", true);
        public static TextObject Village => Translate("Ua6CNLBZ", true);

        public static TextObject ModName => Translate("ModName");
        public static TextObject ModLoadedInformation => Translate("ModLoadedInformation");
        public static TextObject TownMainMenuOption => Translate("TownMainMenuOption");
        public static TextObject TownMainMenuText => Translate("TownMainMenuText");
        public static TextObject MainMenuLeaveOption => Translate("MainMenuLeaveOption");
        public static TextObject MainMenuOpenEncyclopediaOption => Translate("MainMenuOpenEncyclopediaOption");
        public static TextObject MainMenuOpenLeaderboardHeroOption => Translate("MainMenuOpenLeaderboardHeroOption");
        public static TextObject MainMenuOpenLeaderboardWorkshopOption => Translate("MainMenuOpenLeaderboardWorkshopOption");
        public static TextObject EncyclopediaDefaultVartsPageName => Translate("EncyclopediaDefaultVartsPageName");
        public static TextObject EncyclopediaDefaultVartsPageDescription => Translate("EncyclopediaDefaultVartsPageDescription");
        public static TextObject EncyclopediaVartsDtoFilterSettlementType => Translate("EncyclopediaVartsDtoFilterSettlementType");
        public static TextObject EncyclopediaVartsDtoFilterFaction => Translate("EncyclopediaVartsDtoFilterFaction");
        public static TextObject EncyclopediaVartsDtoFilterWorkshopSuggestion => Translate("EncyclopediaVartsDtoFilterWorkshopSuggestion");
        public static TextObject EncyclopediaVartsDtoFilterSuggestionStrength => Translate("EncyclopediaVartsDtoFilterSuggestionStrength");
        public static TextObject EncyclopediaVartsDtoFilterVillageProduction => Translate("EncyclopediaVartsDtoFilterVillageProduction");
        public static TextObject EncyclopediaVartsDtoFilterVillageBoundTown => Translate("EncyclopediaVartsDtoFilterVillageBoundTown");
    }
}