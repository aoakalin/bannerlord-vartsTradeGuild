using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopVM : ViewModel
    {
        private bool _isEnabled;
        private string _doneText;
        private string _heroText;
        private string _victoriesText;
        private string _prizeText;
        private string _rankText;
        private string _titleText;
        private MBBindingList<VartsLeaderboardWorkshopEntryItemVM> _entries;
        private VartsLeaderboardWorkshopSortControllerVM _sortController;

        public VartsLeaderboardWorkshopVM()
        {
            this.Entries = new MBBindingList<VartsLeaderboardWorkshopEntryItemVM>();
            List<KeyValuePair<Hero, int>> leaderboard = Campaign.Current.TournamentManager.GetLeaderboard();
            for (int index = 0; index < leaderboard.Count; ++index)
            {
                MBBindingList<VartsLeaderboardWorkshopEntryItemVM> entries = this.Entries;
                KeyValuePair<Hero, int> keyValuePair = leaderboard[index];
                Hero key = keyValuePair.Key;
                keyValuePair = leaderboard[index];
                int prize = keyValuePair.Value;
                int placement = index + 1;
                VartsLeaderboardWorkshopEntryItemVM vartsLeaderboardEntryItemVm =
                    new VartsLeaderboardWorkshopEntryItemVM(key, prize, placement);
                entries.Add(vartsLeaderboardEntryItemVm);
            }

            this.SortController = new VartsLeaderboardWorkshopSortControllerVM(ref this._entries);
            this.RefreshValues();
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            this.DoneText = GameTexts.FindText("str_done", (string) null).ToString();
            this.Entries.ApplyActionOnAllItems((Action<VartsLeaderboardWorkshopEntryItemVM>) (x => x.RefreshValues()));
            this.HeroText = GameTexts.FindText("str_hero", (string) null).ToString();
            this.VictoriesText = GameTexts.FindText("str_leaderboard_victories", (string) null).ToString();
            this.RankText = GameTexts.FindText("str_leaderboard_rank_sort", (string) null).ToString();
            this.PrizeText = GameTexts.FindText("str_leaderboard_prize", (string) null).ToString();
            this.TitleText = GameTexts.FindText("str_leaderboard_title", (string) null).ToString();
        }

        private void ExecuteDone()
        {
            this.IsEnabled = false;
        }

        [DataSourceProperty]
        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set
            {
                if (value == this._isEnabled)
                    return;
                this._isEnabled = value;
                this.OnPropertyChanged(nameof(IsEnabled));
            }
        }

        [DataSourceProperty]
        public VartsLeaderboardWorkshopSortControllerVM SortController
        {
            get { return this._sortController; }
            set
            {
                if (value == this._sortController)
                    return;
                this._sortController = value;
                this.OnPropertyChanged(nameof(SortController));
            }
        }

        [DataSourceProperty]
        public MBBindingList<VartsLeaderboardWorkshopEntryItemVM> Entries
        {
            get { return this._entries; }
            set
            {
                if (value == this._entries)
                    return;
                this._entries = value;
                this.OnPropertyChanged(nameof(Entries));
            }
        }

        [DataSourceProperty]
        public string DoneText
        {
            get { return this._doneText; }
            set
            {
                if (!(value != this._doneText))
                    return;
                this._doneText = value;
                this.OnPropertyChanged(nameof(DoneText));
            }
        }

        [DataSourceProperty]
        public string TitleText
        {
            get { return this._titleText; }
            set
            {
                if (!(value != this._titleText))
                    return;
                this._titleText = value;
                this.OnPropertyChanged(nameof(TitleText));
            }
        }

        [DataSourceProperty]
        public string HeroText
        {
            get { return this._heroText; }
            set
            {
                if (!(value != this._heroText))
                    return;
                this._heroText = value;
                this.OnPropertyChanged(nameof(HeroText));
            }
        }

        [DataSourceProperty]
        public string VictoriesText
        {
            get { return this._victoriesText; }
            set
            {
                if (!(value != this._victoriesText))
                    return;
                this._victoriesText = value;
                this.OnPropertyChanged(nameof(VictoriesText));
            }
        }

        [DataSourceProperty]
        public string PrizeText
        {
            get { return this._prizeText; }
            set
            {
                if (!(value != this._prizeText))
                    return;
                this._prizeText = value;
                this.OnPropertyChanged(nameof(PrizeText));
            }
        }

        [DataSourceProperty]
        public string RankText
        {
            get { return this._rankText; }
            set
            {
                if (!(value != this._rankText))
                    return;
                this._rankText = value;
                this.OnPropertyChanged(nameof(RankText));
            }
        }
    }
}