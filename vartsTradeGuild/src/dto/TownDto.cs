using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using vartsTradeGuild.src.localization;

namespace vartsTradeGuild.src.dto
{
    public class TownDto : VartsDto
    {
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
                        Name = settlement.Name,
                        Faction = settlement.MapFaction?.Name,
                        Clan = settlement.OwnerClan?.Name,
                        Owner = settlement.ClaimedBy?.Name,
                        Villages = (MBReadOnlyList<VillageDto>) tradeBoundVillages,
                        CustomName = new TextObject("this will be changed below, this is a placeholder for debugging")
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

                    var workshopSuggestionList = suggestedWorkshops.ToList();
                    workshopSuggestionList = workshopSuggestionList.OrderBy(o => o.Name.ToLower().ToString()).ToList();
                    townDto.SuggestedWorkshops = new MBReadOnlyList<WorkshopTypeDto>(workshopSuggestionList);

                    var workshopSuggestionDictionary = new Dictionary<string, int>();
                    var townDtoSuggestedWorkshops = townDto.SuggestedWorkshops;
                    foreach (var townDtoSuggestedWorkshop in townDtoSuggestedWorkshops)
                    {
                        var key = townDtoSuggestedWorkshop.CustomName.ToString();
                        var keyExists = workshopSuggestionDictionary.TryGetValue(key, out var value);
                        if (!keyExists)
                        {
                            value = 0;
                            workshopSuggestionDictionary.Add(key, value);
                        }

                        value++;
                        workshopSuggestionDictionary[key] = value;
                    }

//                    var townCustomName = "T " + settlement.Name + " (";
                    var townCustomName = settlement.Name + " (";
                    var commaCounter = 1;
                    foreach (var keyValuePair in workshopSuggestionDictionary)
                    {
                        townCustomName += keyValuePair.Key;
                        if (keyValuePair.Value > 1)
                        {
                            townCustomName += "(";
                            for (var i = 1; i < keyValuePair.Value; i++)
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
                        townCustomName += "-";
                    }

                    townCustomName += ")";

                    townDto.CustomName = new TextObject(townCustomName);

                    list.Add(townDto);
                }

                list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
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
                        hashSet.Add(townDtoSuggestedWorkshop.Name);
                    }
                }

                var list = hashSet.ToList();
                list = list.OrderBy(o => o.ToLower().ToString()).ToList();
                return new MBReadOnlyList<TextObject>(list);
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

            var list = hashSet.ToList();
            list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
            return new MBReadOnlyList<TownDto>(list);
        }

        protected override TextObject VartsDtoType()
        {
            return LocalizationManager.Town;
        }
    }
}