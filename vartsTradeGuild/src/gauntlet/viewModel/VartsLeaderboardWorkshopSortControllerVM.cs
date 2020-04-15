using System.Collections.Generic;
using TaleWorlds.Library;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopSortControllerVM : ViewModel
    {
        private readonly MBBindingList<VartsLeaderboardWorkshopEntryItemVM> _listToControl;
        private readonly ItemNameComparer _nameComparer;
        private readonly ItemPrizeComparer _prizeComparer;
        private readonly ItemPlacementComparer _placementComparer;
        private readonly ItemVictoriesComparer _victoriesComparer;
        private int _nameState;
        private int _prizeState;
        private int _placementState;
        private int _victoriesState;
        private bool _isNameSelected;
        private bool _isPrizeSelected;
        private bool _isPlacementSelected;
        private bool _isVictoriesSelected;

        public VartsLeaderboardWorkshopSortControllerVM(
            ref MBBindingList<VartsLeaderboardWorkshopEntryItemVM> listToControl)
        {
            this._listToControl = listToControl;
            this._prizeComparer = new ItemPrizeComparer();
            this._nameComparer = new ItemNameComparer();
            this._placementComparer = new ItemPlacementComparer();
            this._victoriesComparer = new ItemVictoriesComparer();
        }

        private void ExecuteSortByName()
        {
            int nameState = this.NameState;
            this.SetAllStates(SortState.Default);
            this.NameState = (nameState + 1) % 3;
            if (this.NameState == 0)
                ++this.NameState;
            this._nameComparer.SetSortMode(this.NameState == 1);
            this._listToControl.Sort((IComparer<VartsLeaderboardWorkshopEntryItemVM>) this._nameComparer);
            this.IsNameSelected = true;
        }

        private void ExecuteSortByPrize()
        {
            int prizeState = this.PrizeState;
            this.SetAllStates(SortState.Default);
            this.PrizeState = (prizeState + 1) % 3;
            if (this.PrizeState == 0)
                ++this.PrizeState;
            this._prizeComparer.SetSortMode(this.PrizeState == 1);
            this._listToControl.Sort((IComparer<VartsLeaderboardWorkshopEntryItemVM>) this._prizeComparer);
            this.IsPrizeSelected = true;
        }

        private void ExecuteSortByPlacement()
        {
            int placementState = this.PlacementState;
            this.SetAllStates(SortState.Default);
            this.PlacementState = (placementState + 1) % 3;
            if (this.PlacementState == 0)
                ++this.PlacementState;
            this._placementComparer.SetSortMode(this.PlacementState == 1);
            this._listToControl.Sort((IComparer<VartsLeaderboardWorkshopEntryItemVM>) this._placementComparer);
            this.IsPlacementSelected = true;
        }

        private void ExecuteSortByVictories()
        {
            int victoriesState = this.VictoriesState;
            this.SetAllStates(SortState.Default);
            this.VictoriesState = (victoriesState + 1) % 3;
            if (this.VictoriesState == 0)
                ++this.VictoriesState;
            this._victoriesComparer.SetSortMode(this.VictoriesState == 1);
            this._listToControl.Sort((IComparer<VartsLeaderboardWorkshopEntryItemVM>) this._victoriesComparer);
            this.IsVictoriesSelected = true;
        }

        private void SetAllStates(
            SortState state)
        {
            this.NameState = (int) state;
            this.PrizeState = (int) state;
            this.PlacementState = (int) state;
            this.VictoriesState = (int) state;
            this.IsNameSelected = false;
            this.IsVictoriesSelected = false;
            this.IsPrizeSelected = false;
            this.IsPlacementSelected = false;
        }

        [DataSourceProperty]
        public int NameState
        {
            get { return this._nameState; }
            set
            {
                if (value == this._nameState)
                    return;
                this._nameState = value;
                this.OnPropertyChanged(nameof(NameState));
            }
        }

        [DataSourceProperty]
        public int VictoriesState
        {
            get { return this._victoriesState; }
            set
            {
                if (value == this._victoriesState)
                    return;
                this._victoriesState = value;
                this.OnPropertyChanged(nameof(VictoriesState));
            }
        }

        [DataSourceProperty]
        public int PrizeState
        {
            get { return this._prizeState; }
            set
            {
                if (value == this._prizeState)
                    return;
                this._prizeState = value;
                this.OnPropertyChanged(nameof(PrizeState));
            }
        }

        [DataSourceProperty]
        public int PlacementState
        {
            get { return this._placementState; }
            set
            {
                if (value == this._placementState)
                    return;
                this._placementState = value;
                this.OnPropertyChanged(nameof(PlacementState));
            }
        }

        [DataSourceProperty]
        public bool IsNameSelected
        {
            get { return this._isNameSelected; }
            set
            {
                if (value == this._isNameSelected)
                    return;
                this._isNameSelected = value;
                this.OnPropertyChanged(nameof(IsNameSelected));
            }
        }

        [DataSourceProperty]
        public bool IsPrizeSelected
        {
            get { return this._isPrizeSelected; }
            set
            {
                if (value == this._isPrizeSelected)
                    return;
                this._isPrizeSelected = value;
                this.OnPropertyChanged(nameof(IsPrizeSelected));
            }
        }

        [DataSourceProperty]
        public bool IsPlacementSelected
        {
            get { return this._isPlacementSelected; }
            set
            {
                if (value == this._isPlacementSelected)
                    return;
                this._isPlacementSelected = value;
                this.OnPropertyChanged(nameof(IsPlacementSelected));
            }
        }

        [DataSourceProperty]
        public bool IsVictoriesSelected
        {
            get { return this._isVictoriesSelected; }
            set
            {
                if (value == this._isVictoriesSelected)
                    return;
                this._isVictoriesSelected = value;
                this.OnPropertyChanged(nameof(IsVictoriesSelected));
            }
        }

        private enum SortState
        {
            Default,
            Ascending,
            Descending,
        }

        private abstract class ItemComparerBase : IComparer<VartsLeaderboardWorkshopEntryItemVM>
        {
            protected bool _isAcending;

            public void SetSortMode(bool isAcending)
            {
                this._isAcending = isAcending;
            }

            public abstract int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y);
        }

        private class ItemNameComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (this._isAcending)
                    return y.Name.CompareTo(x.Name) * -1;
                return y.Name.CompareTo(x.Name);
            }
        }

        private class ItemPrizeComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (this._isAcending)
                    return y.PrizeValue.CompareTo(x.PrizeValue) * -1;
                return y.PrizeValue.CompareTo(x.PrizeValue);
            }
        }

        private class ItemPlacementComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (this._isAcending)
                    return y.PlacementOnLeaderboard.CompareTo(x.PlacementOnLeaderboard) * -1;
                return y.PlacementOnLeaderboard.CompareTo(x.PlacementOnLeaderboard);
            }
        }

        private class ItemVictoriesComparer : ItemComparerBase
        {
            public override int Compare(
                VartsLeaderboardWorkshopEntryItemVM x,
                VartsLeaderboardWorkshopEntryItemVM y)
            {
                if (this._isAcending)
                    return y.Victories.CompareTo(x.Victories) * -1;
                return y.Victories.CompareTo(x.Victories);
            }
        }
    }
}