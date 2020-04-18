using System;
using System.Collections.Generic;
using TaleWorlds.Library;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopSortControllerVM : ViewModel
    {
        private int _workshopNameState;
        private bool _isWorkshopNameSelected;
        private readonly WorkshopNameComparer _workshopNameComparer;
        private int _workshopTownNameState;
        private bool _isWorkshopTownNameSelected;
        private readonly WorkshopTownNameComparer _workshopTownNameComparer;
        private int _workshopLevelState;
        private bool _isWorkshopLevelSelected;
        private readonly WorkshopLevelComparer _workshopLevelComparer;
        private int _workshopCapitalState;
        private bool _isWorkshopCapitalSelected;
        private readonly WorkshopCapitalComparer _workshopCapitalComparer;
        private int _workshopExpenseState;
        private bool _isWorkshopExpenseSelected;
        private readonly WorkshopExpenseComparer _workshopExpenseComparer;
        private int _workshopIsRunningState;
        private bool _isWorkshopIsRunningSelected;
        private readonly WorkshopIsRunningComparer _workshopIsRunningComparer;
        private int _workshopOwnerNameState;
        private bool _isWorkshopOwnerNameSelected;
        private readonly WorkshopOwnerNameComparer _workshopOwnerNameComparer;
        private int _workshopOwnerGoldState;
        private bool _isWorkshopOwnerGoldSelected;
        private readonly WorkshopOwnerGoldComparer _workshopOwnerGoldComparer;
        private int _workshopProfitMadeState;
        private bool _isWorkshopProfitMadeSelected;
        private readonly WorkshopProfitMadeComparer _workshopProfitMadeComparer;
        private int _workshopRunnedDaysState;
        private bool _isWorkshopRunnedDaysSelected;
        private readonly WorkshopRunnedDaysComparer _workshopRunnedDaysComparer;
        private int _workshopNotRunnedDaysState;
        private bool _isWorkshopNotRunnedDaysSelected;
        private readonly WorkshopNotRunnedDaysComparer _workshopNotRunnedDaysComparer;

        private readonly MBBindingList<VartsLeaderboardWorkshopEntryItemVM> _listToControl;

        public VartsLeaderboardWorkshopSortControllerVM(
            ref MBBindingList<VartsLeaderboardWorkshopEntryItemVM> listToControl)
        {
            _listToControl = listToControl;
            _workshopNameComparer = new WorkshopNameComparer();
            _workshopTownNameComparer = new WorkshopTownNameComparer();
            _workshopLevelComparer = new WorkshopLevelComparer();
            _workshopCapitalComparer = new WorkshopCapitalComparer();
            _workshopExpenseComparer = new WorkshopExpenseComparer();
            _workshopIsRunningComparer = new WorkshopIsRunningComparer();
            _workshopOwnerNameComparer = new WorkshopOwnerNameComparer();
            _workshopOwnerGoldComparer = new WorkshopOwnerGoldComparer();
            _workshopProfitMadeComparer = new WorkshopProfitMadeComparer();
            _workshopRunnedDaysComparer = new WorkshopRunnedDaysComparer();
            _workshopNotRunnedDaysComparer = new WorkshopNotRunnedDaysComparer();
        }

        public enum SortState
        {
            Default,
            Ascending,
            Descending,
        }

        private void SetAllStates(SortState state)
        {
            MovieActionWorkshopNameSortState = (int) state;
            MovieActionWorkshopNameIsSelected = false;
            MovieActionWorkshopTownNameSortState = (int) state;
            MovieActionWorkshopTownNameIsSelected = false;
            MovieActionWorkshopLevelSortState = (int) state;
            MovieActionWorkshopLevelIsSelected = false;
            MovieActionWorkshopCapitalSortState = (int) state;
            MovieActionWorkshopCapitalIsSelected = false;
            MovieActionWorkshopExpenseSortState = (int) state;
            MovieActionWorkshopExpenseIsSelected = false;
            MovieActionWorkshopIsRunningSortState = (int) state;
            MovieActionWorkshopIsRunningIsSelected = false;
            MovieActionWorkshopOwnerNameSortState = (int) state;
            MovieActionWorkshopOwnerNameIsSelected = false;
            MovieActionWorkshopOwnerGoldSortState = (int) state;
            MovieActionWorkshopOwnerGoldIsSelected = false;
            MovieActionWorkshopProfitMadeSortState = (int) state;
            MovieActionWorkshopProfitMadeIsSelected = false;
            MovieActionWorkshopRunnedDaysSortState = (int) state;
            MovieActionWorkshopRunnedDaysIsSelected = false;
            MovieActionWorkshopNotRunnedDaysSortState = (int) state;
            MovieActionWorkshopNotRunnedDaysIsSelected = false;
        }

        private abstract class ItemComparerBase : IComparer<VartsLeaderboardWorkshopEntryItemVM>
        {
            protected bool IsAscending;

            public void SetSortMode(bool isAscending)
            {
                IsAscending = isAscending;
            }

            public abstract int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y);
        }

        private void MovieActionWorkshopNameSort()
        {
            var nameState = MovieActionWorkshopNameSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopNameSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopNameSortState == 0)
                ++MovieActionWorkshopNameSortState;
            _workshopNameComparer.SetSortMode(MovieActionWorkshopNameSortState == 1);
            _listToControl.Sort(_workshopNameComparer);
            MovieActionWorkshopNameIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopNameSortState
        {
            get => _workshopNameState;
            set
            {
                if (value == _workshopNameState)
                    return;
                _workshopNameState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopNameSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopNameIsSelected
        {
            get => _isWorkshopNameSelected;
            set
            {
                if (value == _isWorkshopNameSelected)
                    return;
                _isWorkshopNameSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopNameIsSelected));
            }
        }

        private class WorkshopNameComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return string.Compare(y.MovieTextWorkshopName, x.MovieTextWorkshopName, StringComparison.Ordinal) *
                           -1;
                return string.Compare(y.MovieTextWorkshopName, x.MovieTextWorkshopName, StringComparison.Ordinal);
            }
        }

        private void MovieActionWorkshopTownNameSort()
        {
            var nameState = MovieActionWorkshopTownNameSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopTownNameSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopTownNameSortState == 0)
                ++MovieActionWorkshopTownNameSortState;
            _workshopTownNameComparer.SetSortMode(MovieActionWorkshopTownNameSortState == 1);
            _listToControl.Sort(_workshopTownNameComparer);
            MovieActionWorkshopTownNameIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopTownNameSortState
        {
            get => _workshopTownNameState;
            set
            {
                if (value == _workshopTownNameState)
                    return;
                _workshopTownNameState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopTownNameSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopTownNameIsSelected
        {
            get => _isWorkshopTownNameSelected;
            set
            {
                if (value == _isWorkshopTownNameSelected)
                    return;
                _isWorkshopTownNameSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopTownNameIsSelected));
            }
        }

        private class WorkshopTownNameComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return string.Compare(y.MovieTextWorkshopTownName, x.MovieTextWorkshopTownName,
                               StringComparison.Ordinal) * -1;
                return string.Compare(y.MovieTextWorkshopTownName, x.MovieTextWorkshopTownName,
                    StringComparison.Ordinal);
            }
        }

        private void MovieActionWorkshopLevelSort()
        {
            var nameState = MovieActionWorkshopLevelSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopLevelSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopLevelSortState == 0)
                ++MovieActionWorkshopLevelSortState;
            _workshopLevelComparer.SetSortMode(MovieActionWorkshopLevelSortState == 1);
            _listToControl.Sort(_workshopLevelComparer);
            MovieActionWorkshopLevelIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopLevelSortState
        {
            get => _workshopLevelState;
            set
            {
                if (value == _workshopLevelState)
                    return;
                _workshopLevelState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopLevelSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopLevelIsSelected
        {
            get => _isWorkshopLevelSelected;
            set
            {
                if (value == _isWorkshopLevelSelected)
                    return;
                _isWorkshopLevelSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopLevelIsSelected));
            }
        }

        private class WorkshopLevelComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopLevel).CompareTo(int.Parse(x.MovieTextWorkshopLevel)) * -1;
                return int.Parse(y.MovieTextWorkshopLevel).CompareTo(int.Parse(x.MovieTextWorkshopLevel));
            }
        }

        private void MovieActionWorkshopCapitalSort()
        {
            var nameState = MovieActionWorkshopCapitalSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopCapitalSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopCapitalSortState == 0)
                ++MovieActionWorkshopCapitalSortState;
            _workshopCapitalComparer.SetSortMode(MovieActionWorkshopCapitalSortState == 1);
            _listToControl.Sort(_workshopCapitalComparer);
            MovieActionWorkshopCapitalIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopCapitalSortState
        {
            get => _workshopCapitalState;
            set
            {
                if (value == _workshopCapitalState)
                    return;
                _workshopCapitalState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopCapitalSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopCapitalIsSelected
        {
            get => _isWorkshopCapitalSelected;
            set
            {
                if (value == _isWorkshopCapitalSelected)
                    return;
                _isWorkshopCapitalSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopCapitalIsSelected));
            }
        }

        private class WorkshopCapitalComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopCapital).CompareTo(int.Parse(x.MovieTextWorkshopCapital)) * -1;
                return int.Parse(y.MovieTextWorkshopCapital).CompareTo(int.Parse(x.MovieTextWorkshopCapital));
            }
        }

        private void MovieActionWorkshopExpenseSort()
        {
            var nameState = MovieActionWorkshopExpenseSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopExpenseSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopExpenseSortState == 0)
                ++MovieActionWorkshopExpenseSortState;
            _workshopExpenseComparer.SetSortMode(MovieActionWorkshopExpenseSortState == 1);
            _listToControl.Sort(_workshopExpenseComparer);
            MovieActionWorkshopExpenseIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopExpenseSortState
        {
            get => _workshopExpenseState;
            set
            {
                if (value == _workshopExpenseState)
                    return;
                _workshopExpenseState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopExpenseSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopExpenseIsSelected
        {
            get => _isWorkshopExpenseSelected;
            set
            {
                if (value == _isWorkshopExpenseSelected)
                    return;
                _isWorkshopExpenseSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopExpenseIsSelected));
            }
        }

        private class WorkshopExpenseComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopExpense).CompareTo(int.Parse(x.MovieTextWorkshopExpense)) * -1;
                return int.Parse(y.MovieTextWorkshopExpense).CompareTo(int.Parse(x.MovieTextWorkshopExpense));
            }
        }

        private void MovieActionWorkshopIsRunningSort()
        {
            var nameState = MovieActionWorkshopIsRunningSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopIsRunningSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopIsRunningSortState == 0)
                ++MovieActionWorkshopIsRunningSortState;
            _workshopIsRunningComparer.SetSortMode(MovieActionWorkshopIsRunningSortState == 1);
            _listToControl.Sort(_workshopIsRunningComparer);
            MovieActionWorkshopIsRunningIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopIsRunningSortState
        {
            get => _workshopIsRunningState;
            set
            {
                if (value == _workshopIsRunningState)
                    return;
                _workshopIsRunningState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopIsRunningSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopIsRunningIsSelected
        {
            get => _isWorkshopIsRunningSelected;
            set
            {
                if (value == _isWorkshopIsRunningSelected)
                    return;
                _isWorkshopIsRunningSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopIsRunningIsSelected));
            }
        }

        private class WorkshopIsRunningComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return string.Compare(y.MovieTextWorkshopIsRunning, x.MovieTextWorkshopIsRunning,
                               StringComparison.Ordinal) * -1;
                return string.Compare(y.MovieTextWorkshopIsRunning, x.MovieTextWorkshopIsRunning,
                    StringComparison.Ordinal);
            }
        }

        private void MovieActionWorkshopOwnerNameSort()
        {
            var nameState = MovieActionWorkshopOwnerNameSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopOwnerNameSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopOwnerNameSortState == 0)
                ++MovieActionWorkshopOwnerNameSortState;
            _workshopOwnerNameComparer.SetSortMode(MovieActionWorkshopOwnerNameSortState == 1);
            _listToControl.Sort(_workshopOwnerNameComparer);
            MovieActionWorkshopOwnerNameIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopOwnerNameSortState
        {
            get => _workshopOwnerNameState;
            set
            {
                if (value == _workshopOwnerNameState)
                    return;
                _workshopOwnerNameState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopOwnerNameSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopOwnerNameIsSelected
        {
            get => _isWorkshopOwnerNameSelected;
            set
            {
                if (value == _isWorkshopOwnerNameSelected)
                    return;
                _isWorkshopOwnerNameSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopOwnerNameIsSelected));
            }
        }

        private class WorkshopOwnerNameComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return string.Compare(y.MovieTextWorkshopOwnerName, x.MovieTextWorkshopOwnerName,
                               StringComparison.Ordinal) * -1;
                return string.Compare(y.MovieTextWorkshopOwnerName, x.MovieTextWorkshopOwnerName,
                    StringComparison.Ordinal);
            }
        }

        private void MovieActionWorkshopOwnerGoldSort()
        {
            var nameState = MovieActionWorkshopOwnerGoldSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopOwnerGoldSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopOwnerGoldSortState == 0)
                ++MovieActionWorkshopOwnerGoldSortState;
            _workshopOwnerGoldComparer.SetSortMode(MovieActionWorkshopOwnerGoldSortState == 1);
            _listToControl.Sort(_workshopOwnerGoldComparer);
            MovieActionWorkshopOwnerGoldIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopOwnerGoldSortState
        {
            get => _workshopOwnerGoldState;
            set
            {
                if (value == _workshopOwnerGoldState)
                    return;
                _workshopOwnerGoldState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopOwnerGoldSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopOwnerGoldIsSelected
        {
            get => _isWorkshopOwnerGoldSelected;
            set
            {
                if (value == _isWorkshopOwnerGoldSelected)
                    return;
                _isWorkshopOwnerGoldSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopOwnerGoldIsSelected));
            }
        }

        private class WorkshopOwnerGoldComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopOwnerGold).CompareTo(int.Parse(x.MovieTextWorkshopOwnerGold)) * -1;
                return int.Parse(y.MovieTextWorkshopOwnerGold).CompareTo(int.Parse(x.MovieTextWorkshopOwnerGold));
            }
        }

        public void MovieActionWorkshopProfitMadeSort()
        {
            var nameState = MovieActionWorkshopProfitMadeSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopProfitMadeSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopProfitMadeSortState == 0)
                ++MovieActionWorkshopProfitMadeSortState;
            _workshopProfitMadeComparer.SetSortMode(MovieActionWorkshopProfitMadeSortState == 1);
            _listToControl.Sort(_workshopProfitMadeComparer);
            MovieActionWorkshopProfitMadeIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopProfitMadeSortState
        {
            get => _workshopProfitMadeState;
            set
            {
                if (value == _workshopProfitMadeState)
                    return;
                _workshopProfitMadeState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopProfitMadeSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopProfitMadeIsSelected
        {
            get => _isWorkshopProfitMadeSelected;
            set
            {
                if (value == _isWorkshopProfitMadeSelected)
                    return;
                _isWorkshopProfitMadeSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopProfitMadeIsSelected));
            }
        }

        private class WorkshopProfitMadeComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopProfitMade).CompareTo(int.Parse(x.MovieTextWorkshopProfitMade)) * -1;
                return int.Parse(y.MovieTextWorkshopProfitMade).CompareTo(int.Parse(x.MovieTextWorkshopProfitMade));
            }
        }

        private void MovieActionWorkshopRunnedDaysSort()
        {
            var nameState = MovieActionWorkshopRunnedDaysSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopRunnedDaysSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopRunnedDaysSortState == 0)
                ++MovieActionWorkshopRunnedDaysSortState;
            _workshopRunnedDaysComparer.SetSortMode(MovieActionWorkshopRunnedDaysSortState == 1);
            _listToControl.Sort(_workshopRunnedDaysComparer);
            MovieActionWorkshopRunnedDaysIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopRunnedDaysSortState
        {
            get => _workshopRunnedDaysState;
            set
            {
                if (value == _workshopRunnedDaysState)
                    return;
                _workshopRunnedDaysState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopRunnedDaysSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopRunnedDaysIsSelected
        {
            get => _isWorkshopRunnedDaysSelected;
            set
            {
                if (value == _isWorkshopRunnedDaysSelected)
                    return;
                _isWorkshopRunnedDaysSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopRunnedDaysIsSelected));
            }
        }

        private class WorkshopRunnedDaysComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopRunnedDays).CompareTo(int.Parse(x.MovieTextWorkshopRunnedDays)) * -1;
                return int.Parse(y.MovieTextWorkshopRunnedDays).CompareTo(int.Parse(x.MovieTextWorkshopRunnedDays));
            }
        }

        private void MovieActionWorkshopNotRunnedDaysSort()
        {
            var nameState = MovieActionWorkshopNotRunnedDaysSortState;
            SetAllStates(SortState.Default);
            MovieActionWorkshopNotRunnedDaysSortState = (nameState + 1) % 3;
            if (MovieActionWorkshopNotRunnedDaysSortState == 0)
                ++MovieActionWorkshopNotRunnedDaysSortState;
            _workshopNotRunnedDaysComparer.SetSortMode(MovieActionWorkshopNotRunnedDaysSortState == 1);
            _listToControl.Sort(_workshopNotRunnedDaysComparer);
            MovieActionWorkshopNotRunnedDaysIsSelected = true;
        }

        [DataSourceProperty]
        public int MovieActionWorkshopNotRunnedDaysSortState
        {
            get => _workshopNotRunnedDaysState;
            set
            {
                if (value == _workshopNotRunnedDaysState)
                    return;
                _workshopNotRunnedDaysState = value;
                OnPropertyChanged(nameof(MovieActionWorkshopNotRunnedDaysSortState));
            }
        }

        [DataSourceProperty]
        public bool MovieActionWorkshopNotRunnedDaysIsSelected
        {
            get => _isWorkshopNotRunnedDaysSelected;
            set
            {
                if (value == _isWorkshopNotRunnedDaysSelected)
                    return;
                _isWorkshopNotRunnedDaysSelected = value;
                OnPropertyChanged(nameof(MovieActionWorkshopNotRunnedDaysIsSelected));
            }
        }

        private class WorkshopNotRunnedDaysComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (IsAscending)
                    return int.Parse(y.MovieTextWorkshopNotRunnedDays).CompareTo(int.Parse(x.MovieTextWorkshopNotRunnedDays)) * -1;
                return int.Parse(y.MovieTextWorkshopNotRunnedDays).CompareTo(int.Parse(x.MovieTextWorkshopNotRunnedDays));
            }
        }
    }
}