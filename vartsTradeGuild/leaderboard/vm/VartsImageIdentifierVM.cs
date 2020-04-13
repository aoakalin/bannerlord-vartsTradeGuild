using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.PlayerServices;

namespace vartsTradeGuild.leaderboard.vm
{
    public class VartsImageIdentifierVM : ViewModel
    {
        private ImageIdentifier _imageIdentifierCode;

        [DataSourceProperty]
        public string Id
        {
            get { return this._imageIdentifierCode.Id; }
            private set
            {
                if (!(this._imageIdentifierCode.Id != value))
                    return;
                this._imageIdentifierCode.Id = value;
                this.OnPropertyChanged(nameof(Id));
            }
        }

        [DataSourceProperty]
        public bool IsEmpty
        {
            get
            {
                if (this._imageIdentifierCode.ImageTypeCode != ImageIdentifierType.Null)
                    return string.IsNullOrEmpty(this._imageIdentifierCode.Id);
                return false;
            }
        }

        [DataSourceProperty]
        public bool IsValid
        {
            get { return !this.IsEmpty; }
        }

        [DataSourceProperty]
        public string AdditionalArgs
        {
            get { return this._imageIdentifierCode.AdditionalArgs; }
        }

        [DataSourceProperty]
        public int ImageTypeCode
        {
            get { return (int) this._imageIdentifierCode.ImageTypeCode; }
        }

        public VartsImageIdentifierVM(ImageIdentifierType imageType = ImageIdentifierType.Null)
        {
            this._imageIdentifierCode = new ImageIdentifier(imageType);
        }

        public VartsImageIdentifierVM(ItemObject itemObject)
        {
            this._imageIdentifierCode = new ImageIdentifier(itemObject);
        }

        public VartsImageIdentifierVM(ItemRosterElement itemObject)
        {
            this._imageIdentifierCode = new ImageIdentifier(itemObject);
        }

        public VartsImageIdentifierVM(CharacterCode characterCode)
        {
            this._imageIdentifierCode = new ImageIdentifier(characterCode);
        }

        public VartsImageIdentifierVM(CraftingPiece craftingPiece, string pieceUsageID)
        {
            this._imageIdentifierCode = new ImageIdentifier(craftingPiece, pieceUsageID);
        }

        public VartsImageIdentifierVM(BannerCode bannerCode, bool nineGrid = false)
        {
            this._imageIdentifierCode = new ImageIdentifier(bannerCode, nineGrid);
        }

        public VartsImageIdentifierVM(Banner banner)
        {
            this._imageIdentifierCode = new ImageIdentifier(banner);
        }

        public VartsImageIdentifierVM(ImageIdentifier code)
        {
            this._imageIdentifierCode = new ImageIdentifier(code);
        }

        public VartsImageIdentifierVM(PlayerId id)
        {
            this._imageIdentifierCode = new ImageIdentifier(id);
        }

        public VartsImageIdentifierVM(string id, ImageIdentifierType type)
        {
            this._imageIdentifierCode = new ImageIdentifier(id, type, "");
        }

        public VartsImageIdentifierVM Clone()
        {
            return new VartsImageIdentifierVM(this.Id, (ImageIdentifierType) this.ImageTypeCode);
        }

        public bool Equals(VartsImageIdentifierVM target)
        {
            if (this._imageIdentifierCode == null && target._imageIdentifierCode == null)
                return true;
            ImageIdentifier imageIdentifierCode = this._imageIdentifierCode;
            if (imageIdentifierCode == null)
                return false;
            return imageIdentifierCode.Equals(target._imageIdentifierCode);
        }
    }
}