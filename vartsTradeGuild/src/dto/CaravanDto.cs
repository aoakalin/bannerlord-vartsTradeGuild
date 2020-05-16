using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace vartsTradeGuild.dto
{
    public class CaravanDto
    {
        public TextObject Name;
        public TextObject HomeSettlement;
        public TextObject CurrentSettlement;
        public TextObject LastVisitedSettlement;
        public TextObject ShortTermTargetSettlement;
        public TextObject TargetSettlement;
        public TextObject Faction;
        public ItemRoster ItemRoster;
        public TroopRoster MemberRoster;
        public int PartyTradeGold;
        public float TotalWeightCarried;
        public float LastCachedSpeed;
        public int DailyWage;
        public int CaravanTotalValue;

        public static IEnumerable<CaravanDto> AllCaravanDto
        {
            get
            {
                var list = new List<CaravanDto>();
                foreach (var caravan in MobileParty.AllCaravans)
                {
                    var caravanDto = new CaravanDto();
                    caravanDto.Name = caravan.Name;
                    caravanDto.HomeSettlement = caravan.HomeSettlement?.Name;
                    caravanDto.CurrentSettlement = caravan.CurrentSettlement?.Name;
                    caravanDto.LastVisitedSettlement = caravan.LastVisitedSettlement?.Name;
                    caravanDto.ShortTermTargetSettlement = caravan.ShortTermTargetSettlement?.Name;
                    caravanDto.TargetSettlement = caravan.TargetSettlement?.Name;
                    caravanDto.Faction = caravan.MapFaction?.Name;
                    caravanDto.ItemRoster = caravan.ItemRoster;
                    caravanDto.MemberRoster = caravan.MemberRoster;
                    caravanDto.PartyTradeGold = caravan.PartyTradeGold;
                    caravanDto.TotalWeightCarried = caravan.TotalWeightCarried;
                    caravanDto.LastCachedSpeed = caravan.LastCachedSpeed;
                    caravanDto.DailyWage = caravan.GetTotalWage();
                    caravanDto.CaravanTotalValue = 0;

//                    var caravanTotalValueMethod = typeof(CaravansCampaignBehavior).GetMethod("CaravanTotalValue",
//                        BindingFlags.NonPublic | BindingFlags.Instance);
//                    if (caravanTotalValueMethod != null)
//                    {
//                        try
//                        {
//                            caravanDto.CaravanTotalValue = (int) caravanTotalValueMethod.Invoke(
//                                Campaign.Current.GetCampaignBehavior<CaravansCampaignBehavior>(),
//                                new object[] {caravan});
//                        }
//                        catch (Exception)
//                        {
//                            //ignored on purpose
//                        }
//                    }

                    foreach (var item in caravanDto.ItemRoster)
                    {
                        caravanDto.CaravanTotalValue += item.Amount * item.EquipmentElement.ItemValue;
                    }

                    list.Add(caravanDto);
                }

                list = list.OrderBy(dto => dto.Name.ToString().ToLower().ToString()).ToList();
                return list;
            }
        }
    }
}