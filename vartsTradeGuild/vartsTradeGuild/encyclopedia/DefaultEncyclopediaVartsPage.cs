using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Localization;
using vartsTradeGuild.encyclopedia.dto;

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
            return new TextObject(Main.ModName);
        }

        public override TextObject GetDescriptionText()
        {
            return new TextObject(Main.ModDescription);
        }

        public override string GetImageID()
        {
            return Main.ModImageID;
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
                        vartsDto.StringId, "VartsDto"));
            }

            _items = source.OrderBy(h => h.Name);
            
            var filtersVartsDtoType = new List<EncyclopediaFilterItem>();
            foreach (var textObject in VartsDto.DistinctType)
            {
                filtersVartsDtoType.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is VartsDto dto)
                    {
                        return dto.Type.ToLower().ToString().Equals(textObject.ToLower().ToString());
                    }

                    return false;
                }));   
            }
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVartsDtoType, new TextObject("Settlement Type")));

            
            var filtersTownSuggestedWorkshopTypes = new List<EncyclopediaFilterItem>();
            foreach (var textObject in TownDto.DistinctSuggestedWorkshops)
            {
                filtersTownSuggestedWorkshopTypes.Add(new EncyclopediaFilterItem(textObject, o =>
                {
                    if (o is TownDto dto)
                    {
                        foreach (var dtoSuggestedWorkshop in dto.SuggestedWorkshops)
                        {
                            if (dtoSuggestedWorkshop.WorkshopTypeName.ToLower().ToString()
                                .Equals(textObject.ToLower().ToString()))
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                }));
            }
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersTownSuggestedWorkshopTypes, new TextObject("Workshop Suggestion")));

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
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVillagePrimaryProduction, new TextObject("Village Production")));

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
            encyclopediaFilterGroupList.Add(new EncyclopediaFilterGroup(filtersVillageTradeBoundTownName, new TextObject("Village Bound Town")));

            _filters = encyclopediaFilterGroupList;
        }
    }
}