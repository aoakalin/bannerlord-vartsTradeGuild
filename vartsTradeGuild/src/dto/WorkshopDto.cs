using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace vartsTradeGuild.dto
{
    public class WorkshopDto
    {
        public TextObject Name;
        public TextObject Town;
        public TextObject OwnerName;
        public TextObject OwnerClan;
        public TextObject OwnerFaction;
        public int OwnerGold;
        public int Level;
        public int Capital;
        public int Expense;
        public int ProfitMade;
        public bool IsRunning;
        public int RunnedDays;
        public int NotRunnedDays;

        public static IEnumerable<WorkshopDto> AllWorkshopDto
        {
            get
            {
                var list = new List<WorkshopDto>();
                foreach (var settlement in Settlement.All)
                {
                    if (!settlement.IsTown)
                    {
                        continue;
                    }

                    var town = settlement.Town;

                    foreach (var workshop in town.Workshops)
                    {
                        if (workshop.WorkshopType.Name.ToLower().ToString().Equals("artisans"))
                        {
                            continue;
                        }

                        var workshopDto = new WorkshopDto
                        {
                            Name = workshop.Name,
                            Town = town.Name,
                            OwnerName = workshop.Owner.Name,
                            OwnerClan = workshop.Owner.Clan.Name,
                            OwnerGold = workshop.Owner.Gold,
                            OwnerFaction = workshop.Owner.MapFaction.Name,
                            Level = workshop.Level,
                            Capital = workshop.Capital,
                            Expense = workshop.Expense,
                            ProfitMade = workshop.ProfitMade,
                            IsRunning = workshop.IsRunning,
                            RunnedDays = workshop.RunnedDays,
                            NotRunnedDays = workshop.NotRunnedDays
                        };
                        list.Add(workshopDto);
                    }
                }

                list = list.OrderBy(o => o.Name.ToLower().ToString()).ToList();
                return new MBReadOnlyList<WorkshopDto>(list);
            }
        }
    }
}