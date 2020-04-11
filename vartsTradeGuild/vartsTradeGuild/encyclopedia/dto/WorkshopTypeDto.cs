using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace vartsTradeGuild.encyclopedia.dto
{
    public class WorkshopTypeDto
    {
        public TextObject WorkshopTypeName;
        public List<ProductionDto> Productions;

        public static IEnumerable<WorkshopTypeDto> AllWorkshopTypeDto
        {
            get
            {
                var list = new List<WorkshopTypeDto>();

                foreach (var workshopType in WorkshopType.All)
                {
                    if (workshopType.Name.ToLower().Contains("artisan"))
                    {
                        continue;
                    }

                    var workshopTypeDto = new WorkshopTypeDto
                    {
                        WorkshopTypeName = workshopType.Name,
                        Productions = new List<ProductionDto>()
                    };

                    foreach (var workshopTypeProduction in workshopType.Productions)
                    {
                        var productionDto = new ProductionDto
                        {
                            Inputs = new List<TextObject>(),
                            Outputs = new List<TextObject>()
                        };

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

                    list.Add(workshopTypeDto);
                }

                return list;
            }
        }

        public static IEnumerable<WorkshopTypeDto> GetByInput(TextObject input)
        {
            var list = new HashSet<WorkshopTypeDto>();
            foreach (var workshopTypeDto in AllWorkshopTypeDto)
            {
                foreach (var productionDto in workshopTypeDto.Productions)
                {
                    foreach (var productionDtoInput in productionDto.Inputs)
                    {
                        if (productionDtoInput.ToLower().ToString().Equals(input.ToLower().ToString()))
                        {
                            list.Add(workshopTypeDto);
                        }
                    }
                }
            }

            return list;
        }
    }
}