using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace vartsTradeGuild.encyclopedia.dto
{
    public class TownDto : VartsDto
    {
        public TextObject TownName;
        public MBReadOnlyList<VillageDto> Villages;
        public MBReadOnlyList<WorkshopTypeDto> SuggestedWorkshops;

        public static IEnumerable<TownDto> AllTownDto
        {
            get
            {
                var list = new List<TownDto>();

                foreach (var settlement in Settlement.All)
                {
                    if (!settlement.IsTown)
                    {
                        continue;
                    }

                    var tradeBoundVillages = VillageDto.GetByTradeBoundTownName(settlement.Name);
                    var townDto = new TownDto
                    {
                        StringId = settlement.StringId,
                        TownName = settlement.Name,
                        Villages = (MBReadOnlyList<VillageDto>) tradeBoundVillages
                    };
                    var suggestedWorkshops = new HashSet<WorkshopTypeDto>();
                    foreach (var villageDto in townDto.Villages)
                    {
                        var workshopTypeDtoList = WorkshopTypeDto.GetByInput(villageDto.PrimaryProduction);
                        foreach (var workshopTypeDto in workshopTypeDtoList)
                        {
                            suggestedWorkshops.Add(workshopTypeDto);
                        }
                    }

                    townDto.SuggestedWorkshops = new MBReadOnlyList<WorkshopTypeDto>(suggestedWorkshops.ToList());

                    var workshopSuggestionDictionary = new Dictionary<string, int>();
                    var townDtoSuggestedWorkshops = townDto.SuggestedWorkshops;
                    foreach (var townDtoSuggestedWorkshop in townDtoSuggestedWorkshops)
                    {
                        var key = townDtoSuggestedWorkshop.WorkshopTypeName.ToString();
                        var keyExists = workshopSuggestionDictionary.TryGetValue(key, out var value);
                        if (!keyExists)
                        {
                            value = 0;
                            workshopSuggestionDictionary.Add(key, value);
                        }

                        value++;
                        workshopSuggestionDictionary[key] = value;
                    }

                    var townCustomName = "Town " + settlement.Name + " (Workshop Suggestion: ";
                    var commaCounter = 1;
                    foreach (KeyValuePair<string, int> keyValuePair in workshopSuggestionDictionary)
                    {
                        townCustomName += keyValuePair.Key;
                        if (keyValuePair.Value > 1)
                        {
                            townCustomName += "(";
                            for (int i = 1; i < keyValuePair.Value; i++)
                            {
                                townCustomName += "+";
                            }

                            townCustomName += ")";
                        }

                        if (commaCounter >= workshopSuggestionDictionary.Count)
                        {
                            continue;
                        }

                        townCustomName += ", ";
                        commaCounter++;
                    }

                    if (workshopSuggestionDictionary.Count == 0)
                    {
                        townCustomName += "NONE";
                    }

                    townCustomName += ")";

                    townDto.CustomName = new TextObject(townCustomName);

                    list.Add(townDto);
                }

                return list;
            }
        }

        public static IEnumerable<TextObject> DistinctSuggestedWorkshops
        {
            get
            {
                var hashSet = new HashSet<TextObject>();

                foreach (var townDto in AllTownDto)
                {
                    foreach (var townDtoSuggestedWorkshop in townDto.SuggestedWorkshops)
                    {
                        hashSet.Add(townDtoSuggestedWorkshop.WorkshopTypeName);
                    }
                }

                return new MBReadOnlyList<TextObject>(hashSet.ToList());
            }
        }

        public static IEnumerable<TownDto> GetBySuggestedWorkshopTypeName(TextObject name)
        {
            var hashSet = new HashSet<TownDto>();
            foreach (var townDto in AllTownDto)
            {
                foreach (var townDtoSuggestedWorkshop in townDto.SuggestedWorkshops)
                {
                    if (townDto.Name.ToLower().ToString().Equals(name.ToLower().ToString()))
                    {
                        hashSet.Add(townDto);
                    }
                }
            }

            return new MBReadOnlyList<TownDto>(hashSet.ToList());
        }

        protected override TextObject VartsDtoType()
        {
            return new TextObject("Town");
        }
    }
}