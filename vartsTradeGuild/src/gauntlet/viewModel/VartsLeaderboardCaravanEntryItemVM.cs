using TaleWorlds.Library;
using vartsTradeGuild.dto;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardCaravanEntryItemVM : ViewModel
    {
        private CaravanDto _caravanDto;

        public VartsLeaderboardCaravanEntryItemVM(CaravanDto caravanDto)
        {
            _caravanDto = caravanDto;
            this.RefreshValues();
        }

//        public string MovieTextCaravanName => _CaravanDto.Name.ToString();
//        public string MovieTextCaravanTownName => _CaravanDto.Town.ToString();
//        public string MovieTextCaravanLevel => _CaravanDto.Level.ToString();
//        public string MovieTextCaravanCapital => _CaravanDto.Capital.ToString();
//        public string MovieTextCaravanExpense => _CaravanDto.Expense.ToString();
//        public string MovieTextCaravanIsRunning => _CaravanDto.IsRunning ? LocalizationManager.Yes.ToString() : LocalizationManager.No.ToString();
//        public string MovieTextCaravanOwnerName => _CaravanDto.OwnerName.ToString();
//        public string MovieTextCaravanOwnerGold => _CaravanDto.OwnerGold.ToString();
//        public string MovieTextCaravanProfitMade => _CaravanDto.ProfitMade.ToString();
//        public string MovieTextCaravanRunnedDays => _CaravanDto.RunnedDays.ToString();
//        public string MovieTextCaravanNotRunnedDays => _CaravanDto.NotRunnedDays.ToString();
    }
}