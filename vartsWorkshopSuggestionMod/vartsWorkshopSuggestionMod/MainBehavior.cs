using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace vartsWorkshopSuggestionMod
{
    public class MainBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private static void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
        {
            InitializeMod(campaignGameStarter);
        }

        private static void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            InitializeMod(campaignGameStarter);
        }

        private static void InitializeMod(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter?.AddGameMenuOption("village", "vartsWorkshopSuggestionModVillageCondition",
                "VARTS Workshop Suggestion (All Towns)",
                VillageCondition, VillageConsequence);

            campaignGameStarter?.AddGameMenuOption("town", "vartsWorkshopSuggestionModTownCondition",
                "VARTS Workshop Suggestion (Current Town)",
                TownCondition, TownConsequence);
        }

        private static bool VillageCondition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Trade;
            return true;
        }

        private static bool TownCondition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Trade;
            return true;
        }

        private static void VillageConsequence(MenuCallbackArgs args)
        {
            SuggestWorkshops(false);
        }

        private static void TownConsequence(MenuCallbackArgs args)
        {
            SuggestWorkshops(true);
        }

        private static void SuggestWorkshops(bool isCurrentTownOnly)
        {
            var workshopTypes = new Dictionary<TextObject, WorkshopTypeDto>();
            foreach (var workshopType in WorkshopType.All)
            {
                var workshopTypeDto = new WorkshopTypeDto
                    {WorkshopTypeName = workshopType.Name, Productions = new List<ProductionDto>()};

                foreach (var workshopTypeProduction in workshopType.Productions)
                {
                    var productionDto = new ProductionDto
                        {Inputs = new List<TextObject>(), Outputs = new List<TextObject>()};

                    foreach (var input in workshopTypeProduction.Inputs)
                    {
                        productionDto.Inputs.Add(new TextObject(input.Item1.StringId));
                    }

                    foreach (var output in workshopTypeProduction.Outputs)
                    {
                        productionDto.Outputs.Add(new TextObject(output.Item1.StringId));
                    }

                    workshopTypeDto.Productions.Add(productionDto);
                }

                workshopTypes.Add(workshopTypeDto.WorkshopTypeName, workshopTypeDto);
            }

            var towns = Town.All.Select(town => new TownDto
                {
                    TownName = town.Name, Villages = new List<VillageDto>(),
                    PossibleWorkshops = new HashSet<WorkshopTypeDto>()
                })
                .ToDictionary(townDto => townDto.TownName);

            foreach (var village in Village.All)
            {
                var villageDto = new VillageDto
                {
                    VillageName = village.Name,
                    TradeBoundTownName = village.TradeBound.GetName(),
                    PrimaryProduction = village.VillageType.PrimaryProduction.Name
                };

                var townDto = towns[villageDto.TradeBoundTownName];
                townDto.Villages.Add(villageDto);

                foreach (var workshopTypeDto in workshopTypes.Values)
                {
                    if (workshopTypeDto.WorkshopTypeName.ToLower().Contains("artisan"))
                    {
                        continue;
                    }

                    foreach (var productionDto in workshopTypeDto.Productions)
                    {
                        foreach (var input in productionDto.Inputs)
                        {
                            if (input.ToLower().ToString().Equals(villageDto.PrimaryProduction.ToLower().ToString()))
                            {
                                townDto.PossibleWorkshops.Add(workshopTypeDto);
                            }
                        }
                    }
                }
            }

            var count = 0;
            var json = "{" + Environment.NewLine;
            foreach (var townDto in towns.Values)
            {
                if (isCurrentTownOnly)
                {
                    if (!Settlement.CurrentSettlement.Name.ToLower().ToString().Equals(townDto.TownName.ToLower().ToString()))
                    {
                        continue;
                    }
                }

                if (count != 0)
                {
                    json += "," + Environment.NewLine;
                }

                json += "   \"" + townDto.TownName + "\"" + ": [";
                var count2 = 0;
                foreach (var possibleWorkshop in townDto.PossibleWorkshops)
                {
                    if (count2 != 0)
                    {
                        json += ", ";
                    }

                    json += "\"" + possibleWorkshop.WorkshopTypeName + "\"";
                    count2++;
                }

                json += "]";
                count++;
            }

            json += Environment.NewLine + "}";

            InformationManager.DisplayMessage(new InformationMessage(json));
        }
    }

    public class VillageDto
    {
        public TextObject VillageName;
        public TextObject TradeBoundTownName;
        public TextObject PrimaryProduction;
    }

    public class TownDto
    {
        public TextObject TownName;
        public List<VillageDto> Villages;
        public HashSet<WorkshopTypeDto> PossibleWorkshops;
    }

    public class WorkshopTypeDto
    {
        public TextObject WorkshopTypeName;
        public List<ProductionDto> Productions;
    }

    public class ProductionDto
    {
        public List<TextObject> Inputs;
        public List<TextObject> Outputs;
    }
}