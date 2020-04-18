using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using vartsTradeGuild.dto;
using vartsTradeGuild.localization;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopVM : ViewModel
    {
        private bool _isEnabled;
        private MBBindingList<VartsLeaderboardWorkshopEntryItemVM> _entries;
        private VartsLeaderboardWorkshopSortControllerVM _sortController;

        public VartsLeaderboardWorkshopVM()
        {
            Entries = new MBBindingList<VartsLeaderboardWorkshopEntryItemVM>();
            foreach (var workshopDto in WorkshopDto.AllWorkshopDto)
            {
                Entries.Add(new VartsLeaderboardWorkshopEntryItemVM(workshopDto));                
            }
            SortController = new VartsLeaderboardWorkshopSortControllerVM(ref _entries);

            SortController.MovieActionWorkshopProfitMadeIsSelected = true;
            SortController.MovieActionWorkshopProfitMadeSortState = (int) VartsLeaderboardWorkshopSortControllerVM.SortState.Descending;
            SortController.MovieActionWorkshopProfitMadeSort();
            SortController.MovieActionWorkshopProfitMadeSort();
                
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
        public MBBindingList<VartsLeaderboardWorkshopEntryItemVM> Entries
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
        public VartsLeaderboardWorkshopSortControllerVM SortController
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
        
        public string MovieTextWorkshopName => LocalizationManager.Workshops.ToString();
        public string MovieTextWorkshopTownName => LocalizationManager.Town.ToString();
        public string MovieTextWorkshopLevel => LocalizationManager.Level.ToString();
        public string MovieTextWorkshopCapital => LocalizationManager.Capital.ToString();
        public string MovieTextWorkshopExpense => LocalizationManager.Expenses.ToString();
        public string MovieTextWorkshopIsRunning => LocalizationManager.Ok.ToString();
        public string MovieTextWorkshopOwnerName => LocalizationManager.Owner.ToString();
        public string MovieTextWorkshopOwnerGold => LocalizationManager.Owner + " " + LocalizationManager.Gold;
        public string MovieTextWorkshopProfitMade => LocalizationManager.DailyWorkshopProfits.ToString();
        public string MovieTextWorkshopRunnedDays => LocalizationManager.Yes.ToString();
        public string MovieTextWorkshopNotRunnedDays => LocalizationManager.No.ToString();
    }
}