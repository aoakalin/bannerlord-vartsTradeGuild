using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace vartsTradeGuild.encyclopedia.dto
{
    public abstract class VartsDto : MBObjectBase
    {
        public TextObject Name;
        public TextObject CustomName;

        public TextObject Type => VartsDtoType();

        protected abstract TextObject VartsDtoType();

        private static HashSet<VartsDto> _all;
        public static MBReadOnlyList<VartsDto> All;

        public static IEnumerable<TextObject> DistinctType
        {
            get
            {
                var hashSet = new HashSet<string>();
                foreach (var vartsDto in All)
                {
                    hashSet.Add(
                        LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, vartsDto.Type.GetID())
                    );
                }

                return new MBReadOnlyList<TextObject>(hashSet.ToList().ConvertAll(s => new TextObject(s)));
            }
        }

        public static void InitializeVartsDto()
        {
            _all = new HashSet<VartsDto>();
            foreach (var villageDto in VillageDto.AllVillageDto)
            {
                _all.Add(villageDto);
            }

            foreach (var townDto in TownDto.AllTownDto)
            {
                _all.Add(townDto);
            }

            All = new MBReadOnlyList<VartsDto>(_all.ToList());
        }
    }
}