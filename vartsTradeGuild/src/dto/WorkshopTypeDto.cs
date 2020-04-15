using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace vartsTradeGuild.dto
{
    public class WorkshopTypeDto
    {
        public TextObject Name;
        public TextObject CustomName;
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
                        Name = workshopType.Name,
                        CustomName = new TextObject(workshopType.Name.ToString().Replace(" ", "")),
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

                list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
                return list;
            }
        }

        public static IEnumerable<WorkshopTypeDto> GetByInput(TextObject input)
        {
            switch (input.ToLower().ToString())
            {
                case "sheep":
                    input = new TextObject("wool");
                    break;
                case "cow":
                    input = new TextObject("hides");
                    break;
                case "hog":
                    input = new TextObject("hides");
                    break;
                case "grapes":
                    input = new TextObject("grape");
                    break;
                case "iron ore":
                    input = new TextObject("iron");
                    break;
                case "silver ore":
                    input = new TextObject("silver");
                    break;
            }

            var hashSet = new HashSet<WorkshopTypeDto>();
            foreach (var workshopTypeDto in AllWorkshopTypeDto)
            {
                foreach (var productionDto in workshopTypeDto.Productions)
                {
                    foreach (var productionDtoInput in productionDto.Inputs)
                    {
                        if (productionDtoInput.ToLower().ToString().Equals(input.ToLower().ToString()))
                        {
                            hashSet.Add(workshopTypeDto);
                        }
                    }
                }
            }

            var list = hashSet.ToList();
            list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
            return list;
        }

        public static string DumpDebugData()
        {
            var result = "";
            foreach (var workshopTypeDto in AllWorkshopTypeDto)
            {
                result += Environment.NewLine;
                result += workshopTypeDto.CustomName;
                foreach (var productionDto in workshopTypeDto.Productions)
                {
                    result += Environment.NewLine;
                    result += "\t" + "Production:";
                    result += Environment.NewLine;
                    result += "\t\t" + "Inputs: ";
                    foreach (var productionDtoInput in productionDto.Inputs)
                    {
                        result += Environment.NewLine;
                        result += "\t\t\t" + productionDtoInput;
                    }

                    result += Environment.NewLine;
                    result += "\t\t" + "Outputs: ";
                    foreach (var productionDtoOutput in productionDto.Outputs)
                    {
                        result += Environment.NewLine;
                        result += "\t\t\t" + productionDtoOutput;
                    }
                }
            }

            return result;
        }
    }
}