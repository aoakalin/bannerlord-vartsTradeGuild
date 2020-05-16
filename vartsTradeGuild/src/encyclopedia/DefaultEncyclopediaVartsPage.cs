using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Localization;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.encyclopedia
{
    [EncyclopediaModel(new[] {typeof(VartsDto)})]
    public class DefaultEncyclopediaVartsPage : EncyclopediaPage
    {
        public override string GetViewFullyQualifiedName()
        {
            return "EncyclopediaVartsDtoPage";
        }

        public override TextObject GetName()
        {
            return LocalizationManager.EncyclopediaDefaultVartsPageName;
        }

        public override TextObject GetDescriptionText()
        {
            return LocalizationManager.EncyclopediaDefaultVartsPageDescription;
        }

        public override string GetImageID()
        {
            return "EncyclopediaSettlement";
        }

        public sealed override bool IsValidEncyclopediaItem(object o)
        {
            return o != null;
        }

        public DefaultEncyclopediaVartsPage()
        {
            var encyclopediaFilterGroupList = new List<EncyclopediaFilterGroup>();
            var source = new List<EncyclopediaListItem>();
            HomePageOrderIndex = 6;

            VartsDto.InitializeVartsDto();

            foreach (var vartsDto in VartsDto.All)
            {
                if (IsValidEncyclopediaItem(vartsDto))
                    source.Add(new EncyclopediaListItem(vartsDto, vartsDto.CustomName.ToString(), "",
                        vartsDto.StringId, "Settlement"));
            }

            _items = source.OrderBy(h => h.Name.ToLower().ToString());

            var filtersVartsDtoType = new List<EncyclopediaFilterItem>();
            foreach (var textObject in VartsDto.DistinctType)
            {
                filtersVartsDtoType.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is VartsDto dto)
                    {
                        return dto.Type.ToString().ToLower().ToString().Equals(textObject.ToString().ToLower().ToString());
                    }

                    return false;
                }));
            }

            filtersVartsDtoType = filtersVartsDtoType.OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            filtersVartsDtoType.Reverse();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVartsDtoType,
                LocalizationManager.EncyclopediaVartsDtoFilterSettlementType));

            var filtersFaction = new List<EncyclopediaFilterItem>();
            foreach (var textObject in VartsDto.DistinctFaction)
            {
                filtersFaction.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is VartsDto dto)
                    {
                        return dto.Faction.ToString().ToLower().ToString().Equals(textObject.ToString().ToLower().ToString());
                    }

                    return false;
                }));
            }

            filtersFaction =
                filtersFaction.OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            filtersFaction.Reverse();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersFaction,
                LocalizationManager.Faction));

            var filtersTownSuggestedWorkshopTypes = new List<EncyclopediaFilterItem>();
            foreach (var textObject in TownDto.DistinctSuggestedWorkshops)
            {
                filtersTownSuggestedWorkshopTypes.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is TownDto dto)
                    {
                        foreach (var dtoSuggestedWorkshop in dto.SuggestedWorkshops)
                        {
                            if (dtoSuggestedWorkshop.Name.ToString().ToLower().ToString()
                                .Equals(textObject.ToString().ToLower().ToString()))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                }));
            }

            filtersTownSuggestedWorkshopTypes =
                filtersTownSuggestedWorkshopTypes.OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            filtersTownSuggestedWorkshopTypes.Reverse();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersTownSuggestedWorkshopTypes,
                LocalizationManager.EncyclopediaVartsDtoFilterWorkshopSuggestion));

            var filtersTownSuggestedWorkshopStrength = new List<EncyclopediaFilterItem>
            {
                new EncyclopediaFilterItem(new TextObject("(+)"), o =>
                {
                    if (o is TownDto dto)
                    {
                        return dto.CustomName.Contains("(+)");
                    }

                    return false;
                }),
                new EncyclopediaFilterItem(new TextObject("(++)"), o =>
                {
                    if (o is TownDto dto)
                    {
                        return dto.CustomName.Contains("(++)");
                    }

                    return false;
                })
            };
            filtersTownSuggestedWorkshopStrength = filtersTownSuggestedWorkshopStrength
                .OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersTownSuggestedWorkshopStrength,
                LocalizationManager.EncyclopediaVartsDtoFilterSuggestionStrength));

            var filtersVillagePrimaryProduction = new List<EncyclopediaFilterItem>();
            foreach (var textObject in VillageDto.DistinctPrimaryProduction)
            {
                filtersVillagePrimaryProduction.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is VillageDto dto)
                    {
                        return dto.PrimaryProduction == textObject;
                    }

                    return false;
                }));
            }

            filtersVillagePrimaryProduction =
                filtersVillagePrimaryProduction.OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            filtersVillagePrimaryProduction.Reverse();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVillagePrimaryProduction,
                LocalizationManager.EncyclopediaVartsDtoFilterVillageProduction));

            var filtersVillageTradeBoundTownName = new List<EncyclopediaFilterItem>();
            foreach (var textObject in VillageDto.DistinctTradeBoundTownName)
            {
                filtersVillageTradeBoundTownName.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is VillageDto dto)
                    {
                        return dto.TradeBoundTownName == textObject;
                    }

                    return false;
                }));
            }

            filtersVillageTradeBoundTownName =
                filtersVillageTradeBoundTownName.OrderBy(o => o.Name.ToString().ToLower().ToString()).ToList();
            filtersVillageTradeBoundTownName.Reverse();
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVillageTradeBoundTownName,
                LocalizationManager.EncyclopediaVartsDtoFilterVillageBoundTown));

            _filters = encyclopediaFilterGroupList;
        }
    }
}