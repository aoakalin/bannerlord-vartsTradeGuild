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
        public static TextObject Load => Translate("9NuttOBC", true);
        public static TextObject Cancel => Translate("3CpNUnVl", true);
        public static TextObject Done => Translate("WiNRdfsm", true);
        public static TextObject Leave => Translate("3sRdGQou", true);
        public static TextObject Delete => Translate("GAWxyVgq", true);
        public static TextObject Yes => Translate("aeouhelq", true);
        public static TextObject No => Translate("8OkPHu4f", true);
        public static TextObject Gold => Translate("V4iU0wRv", true);
        public static TextObject Ok => Translate("oHaWR73d", true);
        public static TextObject Owner => Translate("qRqnrtdX", true);
        public static TextObject DailyWorkshopProfits => Translate("BE1scex6", true);
        public static TextObject Leaderboard => Translate("vGF5S2hE", true);
        public static TextObject Statistics => Translate("GmU1to3Y", true);
        public static TextObject Stats => Translate("ffjTMejn", true);
        public static TextObject Wages => Translate("YkZKXsIn", true);
        public static TextObject Marketplace => Translate("zLdXCpne", true);
        public static TextObject Type => Translate("zMMqgxb1", true);
        public static TextObject Production => Translate("bGyrPe8c", true);
        public static TextObject Empty => Translate("XBIPqxA2", true);
        public static TextObject EmptyWorkshop => Translate("xWoXL2FG", true);
        public static TextObject Reset => Translate("mAxXKaXp", true);
        public static TextObject Faction => Translate("enhza8zr", true);
        public static TextObject Workshops => Translate("NbgeKwVr", true);
        public static TextObject Level => Translate("OKUTPdaa", true);
        public static TextObject Capital => Translate("Ra17aK4e", true);
        public static TextObject Expenses => Translate("MfnYoLdc", true);
        public static TextObject Name => Translate("PDdh1sBj", true);

        public static TextObject ModName => Translate("ModName");
        public static TextObject ModLoadedInformation => Translate("ModLoadedInformation");
        public static TextObject TownMainMenuOption => Translate("TownMainMenuOption");
        public static TextObject TownMainMenuText => Translate("TownMainMenuText");
        public static TextObject MainMenuLeaveOption => Translate("MainMenuLeaveOption");
        public static TextObject MainMenuOpenEncyclopediaOption => Translate("MainMenuOpenEncyclopediaOption");
        public static TextObject MainMenuOpenConfigOption => Translate("MainMenuOpenConfigOption");
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