using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;

namespace vartsTradeGuild.behavior.@base
{
    public abstract class VartsMenuOptionBehaviorBase : CampaignBehaviorBase
    {
        private readonly string _menuId;
        private readonly string _menuOptionId;
        private readonly string _menuOptionText;
        private readonly GameMenuOption.LeaveType _menuLeaveType;
        private readonly bool _isLeave;
        private readonly int _index;

        protected VartsMenuOptionBehaviorBase()
        {
        }

        protected VartsMenuOptionBehaviorBase(string menuId, string menuOptionId,
            string menuOptionText, GameMenuOption.LeaveType menuLeaveType, bool isLeave, int index = -1)
        {
            _menuId = menuId;
            _menuOptionId = menuOptionId;
            _menuOptionText = menuOptionText;
            _menuLeaveType = menuLeaveType;
            _isLeave = isLeave;
            _index = index;
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
        {
            InitializeBehavior(campaignGameStarter);
        }

        private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            InitializeBehavior(campaignGameStarter);
        }

        private void InitializeBehavior(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter?.AddGameMenuOption(_menuId, _menuOptionId, _menuOptionText, MenuCondition,
                MenuConsequence, _isLeave, _index);
        }

        private bool MenuCondition(MenuCallbackArgs args)
        {
            args.optionLeaveType = _menuLeaveType;
            return true;
        }

        private void MenuConsequence(MenuCallbackArgs args)
        {
            OnMenuOptionClicked(args);
        }

        protected abstract void OnMenuOptionClicked(MenuCallbackArgs args);
    }
}