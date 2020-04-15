using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace vartsTradeGuild.dto
{
    public abstract class VartsDto : MBObjectBase
    {
        public TextObject Name;
        public TextObject CustomName;
        public TextObject Faction;
        public TextObject Clan;
        public TextObject Owner;

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

                var list = hashSet.ToList();
                list = list.OrderBy(o => o.ToLower()).ToList();
                return new MBReadOnlyList<TextObject>(list.ConvertAll(s => new TextObject(s)));
            }
        }

        public static IEnumerable<TextObject> DistinctFaction
        {
            get
            {
                var hashSet = new HashSet<string>();
                foreach (var vartsDto in All)
                {
                    var factionName = LocalizedTextManager.GetTranslatedText(BannerlordConfig.Language, vartsDto.Faction.GetID());
                    if (factionName == null) factionName = vartsDto.Faction.ToString(); //if no localization exists (e.g. for player's faction name) default to untranslated string
                    hashSet.Add(factionName);
                }

                var list = hashSet.ToList();
                list = list.OrderBy(o => o.ToLower()).ToList();
                return new MBReadOnlyList<TextObject>(list.ConvertAll(s => new TextObject(s)));
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

            var list = _all.ToList();
            list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
            All = new MBReadOnlyList<VartsDto>(list);
        }
    }
}