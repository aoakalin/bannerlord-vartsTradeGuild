using TaleWorlds.Localization;

namespace vartsTradeGuild.localization
{
    public static class LocalizationManager
    {
        private const string CurrentLanguage = LocalizedTextManager.DefaultEnglishLanguageId;

        private static string Translated(string id)
        {
            return LocalizedTextManager.GetTranslatedText(CurrentLanguage, Main.ModId + "_" + id);
        }

        public static readonly string ModName = Translated("ModName");
        public static readonly string ModLoadedInformation = Translated("ModLoadedInformation");
        public static readonly string TownMainMenuOption = Translated("TownMainMenuOption");
        public static readonly string TownMainMenuText = Translated("TownMainMenuText");
        public static readonly string MainMenuLeaveOption = Translated("MainMenuLeaveOption");
        public static readonly string MainMenuOpenEncyclopediaOption = Translated("MainMenuOpenEncyclopediaOption");
        public static readonly string EncyclopediaDefaultVartsPageName = Translated("EncyclopediaDefaultVartsPageName");
        public static readonly string EncyclopediaDefaultVartsPageDescription = Translated("EncyclopediaDefaultVartsPageDescription");
        public static readonly string EncyclopediaVartsDtoFilterSettlementType = Translated("EncyclopediaVartsDtoFilterSettlementType");
        public static readonly string EncyclopediaVartsDtoFilterWorkshopSuggestion = Translated("EncyclopediaVartsDtoFilterWorkshopSuggestion");
        public static readonly string EncyclopediaVartsDtoFilterSuggestionStrength = Translated("EncyclopediaVartsDtoFilterSuggestionStrength");
        public static readonly string EncyclopediaVartsDtoFilterVillageProduction = Translated("EncyclopediaVartsDtoFilterVillageProduction");
        public static readonly string EncyclopediaVartsDtoFilterVillageBoundTown = Translated("EncyclopediaVartsDtoFilterVillageBoundTown");
    }
}