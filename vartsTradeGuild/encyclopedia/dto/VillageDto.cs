using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.encyclopedia.dto
{
    public class VillageDto : VartsDto
    {
        public TextObject TradeBoundTownName;
        public TextObject PrimaryProduction;

        public static IEnumerable<VillageDto> AllVillageDto
        {
            get
            {
                var list = new List<VillageDto>();

                foreach (var settlement in Settlement.All)
                {
                    if (!settlement.IsVillage)
                    {
                        continue;
                    }

                    var villageDto = new VillageDto
                    {
                        StringId = settlement.StringId,
                        Name = settlement.Name,
                        TradeBoundTownName = settlement.Village.TradeBound.GetName(),
                        PrimaryProduction = settlement.Village.VillageType.PrimaryProduction.Name,
                        CustomName = new TextObject("V " + settlement.Name + " (P: " +
                                                    settlement.Village.VillageType.PrimaryProduction.Name +
                                                    " | T: " + settlement.Village.TradeBound.GetName() +
                                                    ")")
                    };
                    list.Add(villageDto);
                }

                return new MBReadOnlyList<VillageDto>(list);
            }
        }

        public static IEnumerable<TextObject> DistinctPrimaryProduction
        {
            get
            {
                var hashSet = new HashSet<TextObject>();

                foreach (var villageDto in AllVillageDto)
                {
                    hashSet.Add(villageDto.PrimaryProduction);
                }

                return new MBReadOnlyList<TextObject>(hashSet.ToList());
            }
        }

        public static IEnumerable<TextObject> DistinctTradeBoundTownName
        {
            get
            {
                var hashSet = new HashSet<TextObject>();

                foreach (var villageDto in AllVillageDto)
                {
                    hashSet.Add(villageDto.TradeBoundTownName);
                }

                return new MBReadOnlyList<TextObject>(hashSet.ToList());
            }
        }

        public static VillageDto GetByName(TextObject name)
        {
            foreach (var villageDto in AllVillageDto)
            {
                if (villageDto.Name.ToLower().ToString().Equals(name.ToLower().ToString()))
                {
                    return villageDto;
                }
            }

            return null;
        }

        public static IEnumerable<VillageDto> GetByTradeBoundTownName(TextObject name)
        {
            var hashSet = new HashSet<VillageDto>();
            foreach (var villageDto in AllVillageDto)
            {
                if (villageDto.TradeBoundTownName.ToLower().ToString().Equals(name.ToLower().ToString()))
                {
                    hashSet.Add(villageDto);
                }
            }

            return new MBReadOnlyList<VillageDto>(hashSet.ToList());
        }

        protected override TextObject VartsDtoType()
        {
            return LocalizationManager.Village;
        }

        public static string DumpDebugData()
        {
            var result = "";
            foreach (var villageDto in AllVillageDto)
            {
                result += Environment.NewLine;
                result += villageDto.Name + ": " + villageDto.PrimaryProduction;
            }

            return result;
        }
    }
}