using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace vartsZombieMod
{
    public class Main : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            InformationManager.DisplayMessage(new InformationMessage("OnBeforeInitialModuleScreenSetAsRoot"));
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnGameStart"));

            if (!(game.GameType is Campaign))
                return;

            ((CampaignGameStarter) gameStarterObject).AddBehavior(new MainBehavior());
        }

        protected override void OnSubModuleLoad()
        {
            InformationManager.DisplayMessage(new InformationMessage("OnSubModuleLoad"));
        }

        protected override void OnSubModuleUnloaded()
        {
            InformationManager.DisplayMessage(new InformationMessage("OnSubModuleUnloaded"));
        }

        protected override void OnApplicationTick(float dt)
        {
            //InformationManager.DisplayMessage(new InformationMessage("OnApplicationTick"));
        }

        public override void BeginGameStart(Game game)
        {
            InformationManager.DisplayMessage(new InformationMessage("BeginGameStart"));
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnCampaignStart"));
        }

        public override void OnGameEnd(Game game)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnGameEnd"));
        }

        public override void OnGameInitializationFinished(Game game)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnGameInitializationFinished"));
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnGameLoaded"));
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnMissionBehaviourInitialize"));
        }

        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            InformationManager.DisplayMessage(new InformationMessage("OnNewGameCreated"));
        }
    }
}