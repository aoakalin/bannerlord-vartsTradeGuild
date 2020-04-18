using TaleWorlds.Library;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardCaravanVM : ViewModel
    {
        private bool _isEnabled;
        private MBBindingList<VartsLeaderboardCaravanEntryItemVM> _entries;
        private VartsLeaderboardCaravanSortControllerVM _sortController;

        public VartsLeaderboardCaravanVM()
        {
            Entries = new MBBindingList<VartsLeaderboardCaravanEntryItemVM>();
            foreach (var caravanDto in CaravanDto.AllCaravanDto)
            {
                Entries.Add(new VartsLeaderboardCaravanEntryItemVM(caravanDto));                
            }
            SortController = new VartsLeaderboardCaravanSortControllerVM(ref _entries);

//            SortController.MovieActionCaravanProfitMadeIsSelected = true;
//            SortController.MovieActionCaravanProfitMadeSortState = (int) VartsLeaderboardCaravanSortControllerVM.SortState.Descending;
//            SortController.MovieActionCaravanProfitMadeSort();
//            SortController.MovieActionCaravanProfitMadeSort();
                
            RefreshValues();
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            Entries.ApplyActionOnAllItems(x => x.RefreshValues());
        }

        private void MovieActionLeave()
        {
            IsEnabled = false;
        }
        

        [DataSourceProperty]
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (value == _isEnabled)
                    return;
                _isEnabled = value;
                OnPropertyChanged(nameof (IsEnabled));
            }
        }

        [DataSourceProperty] public string MovieTextHeader => LocalizationManager.ModName.ToString();
        [DataSourceProperty] public string MovieTextLeave => LocalizationManager.Leave.ToString();

        [DataSourceProperty]
        public MBBindingList<VartsLeaderboardCaravanEntryItemVM> Entries
        {
            get => _entries;
            set
            {
                if (value == _entries)
                    return;
                _entries = value;
                OnPropertyChanged(nameof(Entries));
            }
        }

        [DataSourceProperty]
        public VartsLeaderboardCaravanSortControllerVM SortController
        {
            get => _sortController;
            set
            {
                if (value == _sortController)
                    return;
                _sortController = value;
                OnPropertyChanged(nameof (SortController));
            }
        }
        
//        public string MovieTextCaravanName => LocalizationManager.Caravans.ToString();
//        public string MovieTextCaravanTownName => LocalizationManager.Town.ToString();
//        public string MovieTextCaravanLevel => LocalizationManager.Level.ToString();
//        public string MovieTextCaravanCapital => LocalizationManager.Capital.ToString();
//        public string MovieTextCaravanExpense => LocalizationManager.Expenses.ToString();
//        public string MovieTextCaravanIsRunning => LocalizationManager.Ok.ToString();
//        public string MovieTextCaravanOwnerName => LocalizationManager.Owner.ToString();
//        public string MovieTextCaravanOwnerGold => LocalizationManager.Owner + " " + LocalizationManager.Gold;
//        public string MovieTextCaravanProfitMade => LocalizationManager.DailyCaravanProfits.ToString();
//        public string MovieTextCaravanRunnedDays => LocalizationManager.Yes.ToString();
//        public string MovieTextCaravanNotRunnedDays => LocalizationManager.No.ToString();
    }
}