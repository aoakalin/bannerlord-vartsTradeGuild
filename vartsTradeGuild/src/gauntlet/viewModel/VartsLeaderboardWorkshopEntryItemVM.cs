using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace vartsTradeGuild.gauntlet.viewModel
{
    public class VartsLeaderboardWorkshopEntryItemVM : ViewModel
    {
        private readonly Hero _workshopDto;
        private int _placementOnLeaderboard;
        private int _victories;
        private bool _isChampion;
        private string _name;
        private string _rankText;
        private string _prizeStr;
        private HeroVM _hero;

        public int Rank { get; private set; }

        public float PrizeValue { get; private set; }

        public VartsLeaderboardWorkshopEntryItemVM(Hero workshopDto, int prize, int placement)
        {
            this._workshopDto = workshopDto;
            this.PrizeStr = prize.ToString();
            this.Rank = placement;
            this.PlacementOnLeaderboard = placement;
            this.IsChampion = placement == 1;
            this.Victories = 1;
            float result;
            if (float.TryParse(this.PrizeStr, out result))
                this.PrizeValue = result;
            this.IsMainHero = hero == TaleWorlds.CampaignSystem.Hero.MainHero;
            this.Hero = new HeroVM(hero);
            this.RefreshValues();
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            this.Name = this._workshopDto.Name.ToString();
            GameTexts.SetVariable("RANK", this.Rank);
            this.RankText = GameTexts.FindText("str_leaderboard_rank", (string) null).ToString();
            this.Hero?.RefreshValues();
        }

        [DataSourceProperty]
        public string Name
        {
            get { return this._name; }
            set
            {
                if (!(value != this._name))
                    return;
                this._name = value;
                this.OnPropertyChanged(nameof(Name));
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

        [DataSourceProperty]
        public int Victories
        {
            get { return this._victories; }
            set
            {
                if (value == this._victories)
                    return;
                this._victories = value;
                this.OnPropertyChanged(nameof(Victories));
            }
        }

        [DataSourceProperty]
        public bool IsChampion
        {
            get { return this._isChampion; }
            set
            {
                if (value == this._isChampion)
                    return;
                this._isChampion = value;
                this.OnPropertyChanged(nameof(IsChampion));
            }
        }

        [DataSourceProperty]
        public bool IsMainHero
        {
            get { return this._isMainHero; }
            set
            {
                if (value == this._isMainHero)
                    return;
                this._isMainHero = value;
                this.OnPropertyChanged(nameof(IsMainHero));
            }
        }

        [DataSourceProperty]
        public HeroVM Hero
        {
            get { return this._hero; }
            set
            {
                if (value == this._hero)
                    return;
                this._hero = value;
                this.OnPropertyChanged(nameof(Hero));
            }
        }

        [DataSourceProperty]
        public string PrizeStr
        {
            get { return this._prizeStr; }
            set
            {
                if (!(value != this._prizeStr))
                    return;
                this._prizeStr = value;
                this.OnPropertyChanged(nameof(PrizeStr));
            }
        }

        [DataSourceProperty]
        public int PlacementOnLeaderboard
        {
            get { return this._placementOnLeaderboard; }
            set
            {
                if (value == this._placementOnLeaderboard)
                    return;
                this._placementOnLeaderboard = value;
                this.OnPropertyChanged(nameof(PlacementOnLeaderboard));
            }
        }
    }
}