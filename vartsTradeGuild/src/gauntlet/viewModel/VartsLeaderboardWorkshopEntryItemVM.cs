using TaleWorlds.Library;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopEntryItemVM : ViewModel
    {
        private WorkshopDto _workshopDto;

        public VartsLeaderboardWorkshopEntryItemVM(WorkshopDto workshopDto)
        {
            _workshopDto = workshopDto;
            this.RefreshValues();
        }

        public string MovieTextWorkshopName => _workshopDto.Name.ToString();
        public string MovieTextWorkshopTownName => _workshopDto.Town.ToString();
        public string MovieTextWorkshopLevel => _workshopDto.Level.ToString();
        public string MovieTextWorkshopCapital => _workshopDto.Capital.ToString();
        public string MovieTextWorkshopExpense => _workshopDto.Expense.ToString();
        public string MovieTextWorkshopIsRunning => _workshopDto.IsRunning ? LocalizationManager.Yes.ToString() : LocalizationManager.No.ToString();
        public string MovieTextWorkshopOwnerName => _workshopDto.OwnerName.ToString();
        public string MovieTextWorkshopOwnerGold => _workshopDto.OwnerGold.ToString();
        public string MovieTextWorkshopProfitMade => _workshopDto.ProfitMade.ToString();
        public string MovieTextWorkshopRunnedDays => _workshopDto.RunnedDays.ToString();
        public string MovieTextWorkshopNotRunnedDays => _workshopDto.NotRunnedDays.ToString();
    }
}