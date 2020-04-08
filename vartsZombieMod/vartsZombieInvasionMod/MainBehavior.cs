using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;

namespace vartsZombieMod
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
            //throw new System.NotImplementedException();
        }

        private void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
        {
            InformationManager.DisplayMessage(new InformationMessage("MainBehavior.OnNewGameCreated"));
            InitializeMod(campaignGameStarter);
        }

        private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            InformationManager.DisplayMessage(new InformationMessage("MainBehavior.OnGameLoaded"));
            InitializeMod(campaignGameStarter);
        }

        private void InitializeMod(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter?.AddGameMenuOption("village", "vartsZombieModVillageZombieInvasion", "Zombie Invasion!",
                VillageZombieInvasionCondition, VillageZombieInvasionConsequence);
        }

        private bool VillageZombieInvasionCondition(MenuCallbackArgs args)
        {
            args.optionLeaveType = GameMenuOption.LeaveType.Raid;
            return true;
        }

        private void VillageZombieInvasionConsequence(MenuCallbackArgs args)
        {
            InformationManager.DisplayMessage(new InformationMessage("MainBehavior.VillageZombieInvasionConsequence START"));

            var workshopTypes = new Dictionary<TextObject, WorkshopTypeDTO>();
            foreach (var workshopType in WorkshopType.All)
            {
                var workshopTypeDto = new WorkshopTypeDTO
                    {WorkshopTypeName = workshopType.Name, Productions = new List<ProductionDTO>()};
                foreach (var workshopTypeProduction in workshopType.Productions)
                {
                    var productionDto = new ProductionDTO {Inputs = new List<TextObject>(), Outputs = new List<TextObject>()};
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

            var towns = Town.All.Select(town => new TownDTO {TownName = town.Name, Villages = new List<VillageDTO>(), PossibleWorkshops = new HashSet<WorkshopTypeDTO>()})
                .ToDictionary(townDto => townDto.TownName);

            foreach (var village in Village.All)
            {
                var villageDto = new VillageDTO
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
                        //json += "," + Environment.NewLine;
                        json += ", ";
                    }
                    //json += "      \"" + possibleWorkshop.WorkshopTypeName + "\"";
                    json += "\"" + possibleWorkshop.WorkshopTypeName + "\"";
                    count2++;
                }
                //json += Environment.NewLine + "   ]";
                json += "]";
                count++;
            }
            json += Environment.NewLine + "}";
            
            InformationManager.DisplayMessage(new InformationMessage(json));
            
            InformationManager.DisplayMessage(new InformationMessage("MainBehavior.VillageZombieInvasionConsequence END"));
        }
    }

    public class VillageDTO
    {
        public TextObject VillageName;
        public TextObject TradeBoundTownName;
        public TextObject PrimaryProduction;
    }

    public class TownDTO
    {
        public TextObject TownName;
        public List<VillageDTO> Villages;
        public HashSet<WorkshopTypeDTO> PossibleWorkshops;
    }

    public class WorkshopTypeDTO
    {
        public TextObject WorkshopTypeName;
        public List<ProductionDTO> Productions;
    }

    public class ProductionDTO
    {
        public List<TextObject> Inputs;
        public List<TextObject> Outputs;
    }
}