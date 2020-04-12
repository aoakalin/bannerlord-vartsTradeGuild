using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace vartsTradeGuild.encyclopedia.dto
{
    public abstract class VartsDto : MBObjectBase
    {
        public TextObject Name;
        public TextObject CustomName;

        public TextObject Type => VartsDtoType();

        protected abstract TextObject VartsDtoType();

        private static HashSet<VartsDto> _all = new HashSet<VartsDto>();
        public static MBReadOnlyList<VartsDto> All => new MBReadOnlyList<VartsDto>(_all.ToList());

        public static MBReadOnlyList<TextObject> DistinctType
        {
            get
            {
                var hashSet = new HashSet<string>();
                foreach (var vartsDto in All)
                {
                    hashSet.Add(vartsDto.Type.ToString());
                }

                return new MBReadOnlyList<TextObject>(hashSet.ToList().ConvertAll(s => new TextObject(s)));
            }
        }

        public static void Add(VartsDto vartsDto)
        {
            _all.Add(vartsDto);
        }

        public static void InitializeVartsDto()
        {
            foreach (var villageDto in VillageDto.AllVillageDto)
            {
                Add(villageDto);
            }

            foreach (var townDto in TownDto.AllTownDto)
            {
                Add(townDto);
            }
        }
    }
}