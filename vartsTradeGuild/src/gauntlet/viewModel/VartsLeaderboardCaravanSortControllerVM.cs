using System;
using System.Collections.Generic;
using TaleWorlds.Library;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardCaravanSortControllerVM : ViewModel
    {
//        private int _CaravanNameState;
//        private bool _isCaravanNameSelected;
//        private readonly CaravanNameComparer _CaravanNameComparer;
//        private int _CaravanTownNameState;
//        private bool _isCaravanTownNameSelected;
//        private readonly CaravanTownNameComparer _CaravanTownNameComparer;
//        private int _CaravanLevelState;
//        private bool _isCaravanLevelSelected;
//        private readonly CaravanLevelComparer _CaravanLevelComparer;
//        private int _CaravanCapitalState;
//        private bool _isCaravanCapitalSelected;
//        private readonly CaravanCapitalComparer _CaravanCapitalComparer;
//        private int _CaravanExpenseState;
//        private bool _isCaravanExpenseSelected;
//        private readonly CaravanExpenseComparer _CaravanExpenseComparer;
//        private int _CaravanIsRunningState;
//        private bool _isCaravanIsRunningSelected;
//        private readonly CaravanIsRunningComparer _CaravanIsRunningComparer;
//        private int _CaravanOwnerNameState;
//        private bool _isCaravanOwnerNameSelected;
//        private readonly CaravanOwnerNameComparer _CaravanOwnerNameComparer;
//        private int _CaravanOwnerGoldState;
//        private bool _isCaravanOwnerGoldSelected;
//        private readonly CaravanOwnerGoldComparer _CaravanOwnerGoldComparer;
//        private int _CaravanProfitMadeState;
//        private bool _isCaravanProfitMadeSelected;
//        private readonly CaravanProfitMadeComparer _CaravanProfitMadeComparer;
//        private int _CaravanRunnedDaysState;
//        private bool _isCaravanRunnedDaysSelected;
//        private readonly CaravanRunnedDaysComparer _CaravanRunnedDaysComparer;
//        private int _CaravanNotRunnedDaysState;
//        private bool _isCaravanNotRunnedDaysSelected;
//        private readonly CaravanNotRunnedDaysComparer _CaravanNotRunnedDaysComparer;

        private readonly MBBindingList<VartsLeaderboardCaravanEntryItemVM> _listToControl;

        public VartsLeaderboardCaravanSortControllerVM(
            ref MBBindingList<VartsLeaderboardCaravanEntryItemVM> listToControl)
        {
            _listToControl = listToControl;
//            _CaravanNameComparer = new CaravanNameComparer();
//            _CaravanTownNameComparer = new CaravanTownNameComparer();
//            _CaravanLevelComparer = new CaravanLevelComparer();
//            _CaravanCapitalComparer = new CaravanCapitalComparer();
//            _CaravanExpenseComparer = new CaravanExpenseComparer();
//            _CaravanIsRunningComparer = new CaravanIsRunningComparer();
//            _CaravanOwnerNameComparer = new CaravanOwnerNameComparer();
//            _CaravanOwnerGoldComparer = new CaravanOwnerGoldComparer();
//            _CaravanProfitMadeComparer = new CaravanProfitMadeComparer();
//            _CaravanRunnedDaysComparer = new CaravanRunnedDaysComparer();
//            _CaravanNotRunnedDaysComparer = new CaravanNotRunnedDaysComparer();
        }

        public enum SortState
        {
            Default,
            Ascending,
            Descending,
        }

        private void SetAllStates(SortState state)
        {
//            MovieActionCaravanNameSortState = (int) state;
//            MovieActionCaravanNameIsSelected = false;
//            MovieActionCaravanTownNameSortState = (int) state;
//            MovieActionCaravanTownNameIsSelected = false;
//            MovieActionCaravanLevelSortState = (int) state;
//            MovieActionCaravanLevelIsSelected = false;
//            MovieActionCaravanCapitalSortState = (int) state;
//            MovieActionCaravanCapitalIsSelected = false;
//            MovieActionCaravanExpenseSortState = (int) state;
//            MovieActionCaravanExpenseIsSelected = false;
//            MovieActionCaravanIsRunningSortState = (int) state;
//            MovieActionCaravanIsRunningIsSelected = false;
//            MovieActionCaravanOwnerNameSortState = (int) state;
//            MovieActionCaravanOwnerNameIsSelected = false;
//            MovieActionCaravanOwnerGoldSortState = (int) state;
//            MovieActionCaravanOwnerGoldIsSelected = false;
//            MovieActionCaravanProfitMadeSortState = (int) state;
//            MovieActionCaravanProfitMadeIsSelected = false;
//            MovieActionCaravanRunnedDaysSortState = (int) state;
//            MovieActionCaravanRunnedDaysIsSelected = false;
//            MovieActionCaravanNotRunnedDaysSortState = (int) state;
//            MovieActionCaravanNotRunnedDaysIsSelected = false;
        }

        private abstract class ItemComparerBase : IComparer<VartsLeaderboardCaravanEntryItemVM>
        {
            protected bool IsAscending;

            public void SetSortMode(bool isAscending)
            {
                IsAscending = isAscending;
            }

            public abstract int Compare(
                VartsLeaderboardCaravanEntryItemVM x,
                VartsLeaderboardCaravanEntryItemVM y);
        }

//        private void MovieActionCaravanNameSort()
//        {
//            var nameState = MovieActionCaravanNameSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanNameSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanNameSortState == 0)
//                ++MovieActionCaravanNameSortState;
//            _CaravanNameComparer.SetSortMode(MovieActionCaravanNameSortState == 1);
//            _listToControl.Sort(_CaravanNameComparer);
//            MovieActionCaravanNameIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanNameSortState
//        {
//            get => _CaravanNameState;
//            set
//            {
//                if (value == _CaravanNameState)
//                    return;
//                _CaravanNameState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanNameSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanNameIsSelected
//        {
//            get => _isCaravanNameSelected;
//            set
//            {
//                if (value == _isCaravanNameSelected)
//                    return;
//                _isCaravanNameSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanNameIsSelected));
//            }
//        }
//
//        private class CaravanNameComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return string.Compare(y.MovieTextCaravanName, x.MovieTextCaravanName, StringComparison.Ordinal) *
//                           -1;
//                return string.Compare(y.MovieTextCaravanName, x.MovieTextCaravanName, StringComparison.Ordinal);
//            }
//        }
//
//        private void MovieActionCaravanTownNameSort()
//        {
//            var nameState = MovieActionCaravanTownNameSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanTownNameSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanTownNameSortState == 0)
//                ++MovieActionCaravanTownNameSortState;
//            _CaravanTownNameComparer.SetSortMode(MovieActionCaravanTownNameSortState == 1);
//            _listToControl.Sort(_CaravanTownNameComparer);
//            MovieActionCaravanTownNameIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanTownNameSortState
//        {
//            get => _CaravanTownNameState;
//            set
//            {
//                if (value == _CaravanTownNameState)
//                    return;
//                _CaravanTownNameState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanTownNameSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanTownNameIsSelected
//        {
//            get => _isCaravanTownNameSelected;
//            set
//            {
//                if (value == _isCaravanTownNameSelected)
//                    return;
//                _isCaravanTownNameSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanTownNameIsSelected));
//            }
//        }
//
//        private class CaravanTownNameComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return string.Compare(y.MovieTextCaravanTownName, x.MovieTextCaravanTownName,
//                               StringComparison.Ordinal) * -1;
//                return string.Compare(y.MovieTextCaravanTownName, x.MovieTextCaravanTownName,
//                    StringComparison.Ordinal);
//            }
//        }
//
//        private void MovieActionCaravanLevelSort()
//        {
//            var nameState = MovieActionCaravanLevelSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanLevelSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanLevelSortState == 0)
//                ++MovieActionCaravanLevelSortState;
//            _CaravanLevelComparer.SetSortMode(MovieActionCaravanLevelSortState == 1);
//            _listToControl.Sort(_CaravanLevelComparer);
//            MovieActionCaravanLevelIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanLevelSortState
//        {
//            get => _CaravanLevelState;
//            set
//            {
//                if (value == _CaravanLevelState)
//                    return;
//                _CaravanLevelState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanLevelSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanLevelIsSelected
//        {
//            get => _isCaravanLevelSelected;
//            set
//            {
//                if (value == _isCaravanLevelSelected)
//                    return;
//                _isCaravanLevelSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanLevelIsSelected));
//            }
//        }
//
//        private class CaravanLevelComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanLevel).CompareTo(int.Parse(x.MovieTextCaravanLevel)) * -1;
//                return int.Parse(y.MovieTextCaravanLevel).CompareTo(int.Parse(x.MovieTextCaravanLevel));
//            }
//        }
//
//        private void MovieActionCaravanCapitalSort()
//        {
//            var nameState = MovieActionCaravanCapitalSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanCapitalSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanCapitalSortState == 0)
//                ++MovieActionCaravanCapitalSortState;
//            _CaravanCapitalComparer.SetSortMode(MovieActionCaravanCapitalSortState == 1);
//            _listToControl.Sort(_CaravanCapitalComparer);
//            MovieActionCaravanCapitalIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanCapitalSortState
//        {
//            get => _CaravanCapitalState;
//            set
//            {
//                if (value == _CaravanCapitalState)
//                    return;
//                _CaravanCapitalState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanCapitalSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanCapitalIsSelected
//        {
//            get => _isCaravanCapitalSelected;
//            set
//            {
//                if (value == _isCaravanCapitalSelected)
//                    return;
//                _isCaravanCapitalSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanCapitalIsSelected));
//            }
//        }
//
//        private class CaravanCapitalComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanCapital).CompareTo(int.Parse(x.MovieTextCaravanCapital)) * -1;
//                return int.Parse(y.MovieTextCaravanCapital).CompareTo(int.Parse(x.MovieTextCaravanCapital));
//            }
//        }
//
//        private void MovieActionCaravanExpenseSort()
//        {
//            var nameState = MovieActionCaravanExpenseSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanExpenseSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanExpenseSortState == 0)
//                ++MovieActionCaravanExpenseSortState;
//            _CaravanExpenseComparer.SetSortMode(MovieActionCaravanExpenseSortState == 1);
//            _listToControl.Sort(_CaravanExpenseComparer);
//            MovieActionCaravanExpenseIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanExpenseSortState
//        {
//            get => _CaravanExpenseState;
//            set
//            {
//                if (value == _CaravanExpenseState)
//                    return;
//                _CaravanExpenseState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanExpenseSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanExpenseIsSelected
//        {
//            get => _isCaravanExpenseSelected;
//            set
//            {
//                if (value == _isCaravanExpenseSelected)
//                    return;
//                _isCaravanExpenseSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanExpenseIsSelected));
//            }
//        }
//
//        private class CaravanExpenseComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanExpense).CompareTo(int.Parse(x.MovieTextCaravanExpense)) * -1;
//                return int.Parse(y.MovieTextCaravanExpense).CompareTo(int.Parse(x.MovieTextCaravanExpense));
//            }
//        }
//
//        private void MovieActionCaravanIsRunningSort()
//        {
//            var nameState = MovieActionCaravanIsRunningSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanIsRunningSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanIsRunningSortState == 0)
//                ++MovieActionCaravanIsRunningSortState;
//            _CaravanIsRunningComparer.SetSortMode(MovieActionCaravanIsRunningSortState == 1);
//            _listToControl.Sort(_CaravanIsRunningComparer);
//            MovieActionCaravanIsRunningIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanIsRunningSortState
//        {
//            get => _CaravanIsRunningState;
//            set
//            {
//                if (value == _CaravanIsRunningState)
//                    return;
//                _CaravanIsRunningState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanIsRunningSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanIsRunningIsSelected
//        {
//            get => _isCaravanIsRunningSelected;
//            set
//            {
//                if (value == _isCaravanIsRunningSelected)
//                    return;
//                _isCaravanIsRunningSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanIsRunningIsSelected));
//            }
//        }
//
//        private class CaravanIsRunningComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return string.Compare(y.MovieTextCaravanIsRunning, x.MovieTextCaravanIsRunning,
//                               StringComparison.Ordinal) * -1;
//                return string.Compare(y.MovieTextCaravanIsRunning, x.MovieTextCaravanIsRunning,
//                    StringComparison.Ordinal);
//            }
//        }
//
//        private void MovieActionCaravanOwnerNameSort()
//        {
//            var nameState = MovieActionCaravanOwnerNameSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanOwnerNameSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanOwnerNameSortState == 0)
//                ++MovieActionCaravanOwnerNameSortState;
//            _CaravanOwnerNameComparer.SetSortMode(MovieActionCaravanOwnerNameSortState == 1);
//            _listToControl.Sort(_CaravanOwnerNameComparer);
//            MovieActionCaravanOwnerNameIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanOwnerNameSortState
//        {
//            get => _CaravanOwnerNameState;
//            set
//            {
//                if (value == _CaravanOwnerNameState)
//                    return;
//                _CaravanOwnerNameState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanOwnerNameSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanOwnerNameIsSelected
//        {
//            get => _isCaravanOwnerNameSelected;
//            set
//            {
//                if (value == _isCaravanOwnerNameSelected)
//                    return;
//                _isCaravanOwnerNameSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanOwnerNameIsSelected));
//            }
//        }
//
//        private class CaravanOwnerNameComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return string.Compare(y.MovieTextCaravanOwnerName, x.MovieTextCaravanOwnerName,
//                               StringComparison.Ordinal) * -1;
//                return string.Compare(y.MovieTextCaravanOwnerName, x.MovieTextCaravanOwnerName,
//                    StringComparison.Ordinal);
//            }
//        }
//
//        private void MovieActionCaravanOwnerGoldSort()
//        {
//            var nameState = MovieActionCaravanOwnerGoldSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanOwnerGoldSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanOwnerGoldSortState == 0)
//                ++MovieActionCaravanOwnerGoldSortState;
//            _CaravanOwnerGoldComparer.SetSortMode(MovieActionCaravanOwnerGoldSortState == 1);
//            _listToControl.Sort(_CaravanOwnerGoldComparer);
//            MovieActionCaravanOwnerGoldIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanOwnerGoldSortState
//        {
//            get => _CaravanOwnerGoldState;
//            set
//            {
//                if (value == _CaravanOwnerGoldState)
//                    return;
//                _CaravanOwnerGoldState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanOwnerGoldSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanOwnerGoldIsSelected
//        {
//            get => _isCaravanOwnerGoldSelected;
//            set
//            {
//                if (value == _isCaravanOwnerGoldSelected)
//                    return;
//                _isCaravanOwnerGoldSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanOwnerGoldIsSelected));
//            }
//        }
//
//        private class CaravanOwnerGoldComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanOwnerGold).CompareTo(int.Parse(x.MovieTextCaravanOwnerGold)) * -1;
//                return int.Parse(y.MovieTextCaravanOwnerGold).CompareTo(int.Parse(x.MovieTextCaravanOwnerGold));
//            }
//        }
//
//        public void MovieActionCaravanProfitMadeSort()
//        {
//            var nameState = MovieActionCaravanProfitMadeSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanProfitMadeSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanProfitMadeSortState == 0)
//                ++MovieActionCaravanProfitMadeSortState;
//            _CaravanProfitMadeComparer.SetSortMode(MovieActionCaravanProfitMadeSortState == 1);
//            _listToControl.Sort(_CaravanProfitMadeComparer);
//            MovieActionCaravanProfitMadeIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanProfitMadeSortState
//        {
//            get => _CaravanProfitMadeState;
//            set
//            {
//                if (value == _CaravanProfitMadeState)
//                    return;
//                _CaravanProfitMadeState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanProfitMadeSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanProfitMadeIsSelected
//        {
//            get => _isCaravanProfitMadeSelected;
//            set
//            {
//                if (value == _isCaravanProfitMadeSelected)
//                    return;
//                _isCaravanProfitMadeSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanProfitMadeIsSelected));
//            }
//        }
//
//        private class CaravanProfitMadeComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanProfitMade).CompareTo(int.Parse(x.MovieTextCaravanProfitMade)) * -1;
//                return int.Parse(y.MovieTextCaravanProfitMade).CompareTo(int.Parse(x.MovieTextCaravanProfitMade));
//            }
//        }
//
//        private void MovieActionCaravanRunnedDaysSort()
//        {
//            var nameState = MovieActionCaravanRunnedDaysSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanRunnedDaysSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanRunnedDaysSortState == 0)
//                ++MovieActionCaravanRunnedDaysSortState;
//            _CaravanRunnedDaysComparer.SetSortMode(MovieActionCaravanRunnedDaysSortState == 1);
//            _listToControl.Sort(_CaravanRunnedDaysComparer);
//            MovieActionCaravanRunnedDaysIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanRunnedDaysSortState
//        {
//            get => _CaravanRunnedDaysState;
//            set
//            {
//                if (value == _CaravanRunnedDaysState)
//                    return;
//                _CaravanRunnedDaysState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanRunnedDaysSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanRunnedDaysIsSelected
//        {
//            get => _isCaravanRunnedDaysSelected;
//            set
//            {
//                if (value == _isCaravanRunnedDaysSelected)
//                    return;
//                _isCaravanRunnedDaysSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanRunnedDaysIsSelected));
//            }
//        }
//
//        private class CaravanRunnedDaysComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanRunnedDays).CompareTo(int.Parse(x.MovieTextCaravanRunnedDays)) * -1;
//                return int.Parse(y.MovieTextCaravanRunnedDays).CompareTo(int.Parse(x.MovieTextCaravanRunnedDays));
//            }
//        }
//
//        private void MovieActionCaravanNotRunnedDaysSort()
//        {
//            var nameState = MovieActionCaravanNotRunnedDaysSortState;
//            SetAllStates(SortState.Default);
//            MovieActionCaravanNotRunnedDaysSortState = (nameState + 1) % 3;
//            if (MovieActionCaravanNotRunnedDaysSortState == 0)
//                ++MovieActionCaravanNotRunnedDaysSortState;
//            _CaravanNotRunnedDaysComparer.SetSortMode(MovieActionCaravanNotRunnedDaysSortState == 1);
//            _listToControl.Sort(_CaravanNotRunnedDaysComparer);
//            MovieActionCaravanNotRunnedDaysIsSelected = true;
//        }
//
//        [DataSourceProperty]
//        public int MovieActionCaravanNotRunnedDaysSortState
//        {
//            get => _CaravanNotRunnedDaysState;
//            set
//            {
//                if (value == _CaravanNotRunnedDaysState)
//                    return;
//                _CaravanNotRunnedDaysState = value;
//                OnPropertyChanged(nameof(MovieActionCaravanNotRunnedDaysSortState));
//            }
//        }
//
//        [DataSourceProperty]
//        public bool MovieActionCaravanNotRunnedDaysIsSelected
//        {
//            get => _isCaravanNotRunnedDaysSelected;
//            set
//            {
//                if (value == _isCaravanNotRunnedDaysSelected)
//                    return;
//                _isCaravanNotRunnedDaysSelected = value;
//                OnPropertyChanged(nameof(MovieActionCaravanNotRunnedDaysIsSelected));
//            }
//        }
//
//        private class CaravanNotRunnedDaysComparer : ItemComparerBase
//        {
//            public override int Compare(
//                VartsLeaderboardCaravanEntryItemVM x,
//                VartsLeaderboardCaravanEntryItemVM y)
//            {
//                if (IsAscending)
//                    return int.Parse(y.MovieTextCaravanNotRunnedDays).CompareTo(int.Parse(x.MovieTextCaravanNotRunnedDays)) * -1;
//                return int.Parse(y.MovieTextCaravanNotRunnedDays).CompareTo(int.Parse(x.MovieTextCaravanNotRunnedDays));
//            }
//        }
    }
}