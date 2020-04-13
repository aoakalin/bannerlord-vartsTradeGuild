using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace vartsTradeGuild.leaderboard.vm
{
    public class VartsHeroVM : ViewModel
    {
        private int _relation = -102;
        private bool _isDead = true;
        private VartsImageIdentifierVM _imageIdentifier;
        private VartsImageIdentifierVM _clanBanner;
        private VartsImageIdentifierVM _clanBanner_9;
        private string _nameText;
        private bool _isChild;

        public Hero Hero { get; }

        public VartsHeroVM(Hero hero)
        {
            if (hero != null)
            {
                this.ImageIdentifier =
                    new VartsImageIdentifierVM(CampaignUIHelper.GetCharacterCode(hero.CharacterObject, false));
                this.ClanBanner = new VartsImageIdentifierVM(hero.ClanBanner);
                this.ClanBanner_9 = new VartsImageIdentifierVM(BannerCode.CreateFrom(hero.ClanBanner), true);
                this.Relation = GetRelation(hero);
                this.IsDead = !hero.IsAlive;
                this.IsChild = hero.IsChild;
            }
            else
            {
                this.ImageIdentifier = new VartsImageIdentifierVM(ImageIdentifierType.Null);
                this.ClanBanner = new VartsImageIdentifierVM(ImageIdentifierType.Null);
                this.ClanBanner_9 = new VartsImageIdentifierVM(ImageIdentifierType.Null);
                this.Relation = 0;
            }

            this.Hero = hero;
            this.RefreshValues();
        }

        public override void RefreshValues()
        {
            base.RefreshValues();
            if (this.Hero != null)
                this.NameText = this.Hero.Name.ToString();
            else
                this.NameText = "";
        }

        public void ExecuteLink()
        {
            if (this.Hero == null)
                return;
            Campaign.Current.EncyclopediaManager.GoToLink(this.Hero.EncyclopediaLink);
        }

        protected virtual void ExecuteBeginHint()
        {
            if (this.Hero == null)
                return;
            InformationManager.AddTooltipInformation(typeof(Hero), (object) this.Hero);
        }

        protected virtual void ExecuteEndHint()
        {
            if (this.Hero == null)
                return;
            InformationManager.HideInformations();
        }

        [DataSourceProperty]
        public bool IsDead
        {
            get { return this._isDead; }
            set
            {
                if (value == this._isDead)
                    return;
                this._isDead = value;
                this.OnPropertyChanged(nameof(IsDead));
            }
        }

        [DataSourceProperty]
        public bool IsChild
        {
            get { return this._isChild; }
            set
            {
                if (value == this._isChild)
                    return;
                this._isChild = value;
                this.OnPropertyChanged(nameof(IsChild));
            }
        }

        [DataSourceProperty]
        public int Relation
        {
            get { return this._relation; }
            set
            {
                if (value == this._relation)
                    return;
                this._relation = value;
                this.OnPropertyChanged(nameof(Relation));
            }
        }

        [DataSourceProperty]
        public VartsImageIdentifierVM ImageIdentifier
        {
            get { return this._imageIdentifier; }
            set
            {
                if (value == this._imageIdentifier)
                    return;
                this._imageIdentifier = value;
                this.OnPropertyChanged(nameof(ImageIdentifier));
            }
        }

        [DataSourceProperty]
        public string NameText
        {
            get { return this._nameText; }
            set
            {
                if (!(value != this._nameText))
                    return;
                this._nameText = value;
                this.OnPropertyChanged(nameof(NameText));
            }
        }

        [DataSourceProperty]
        public VartsImageIdentifierVM ClanBanner
        {
            get { return this._clanBanner; }
            set
            {
                if (value == this._clanBanner)
                    return;
                this._clanBanner = value;
                this.OnPropertyChanged(nameof(ClanBanner));
            }
        }

        [DataSourceProperty]
        public VartsImageIdentifierVM ClanBanner_9
        {
            get { return this._clanBanner_9; }
            set
            {
                if (value == this._clanBanner_9)
                    return;
                this._clanBanner_9 = value;
                this.OnPropertyChanged(nameof(ClanBanner_9));
            }
        }

        public static int GetRelation(Hero hero)
        {
            if (hero == null)
                return -101;
            if (hero == Hero.MainHero)
                return 101;
            if (UIDebugMode)
                return MBRandom.RandomInt(-100, 100);
            return Hero.MainHero.GetRelation(hero);
        }
    }
}