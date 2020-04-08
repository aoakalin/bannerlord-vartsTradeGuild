using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace vartsWorkshopSuggestionMod
{
    public class Main : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (!(game.GameType is Campaign))
                return;

            ((CampaignGameStarter) gameStarterObject).AddBehavior(new MainBehavior());

            InformationManager.DisplayMessage(
                new InformationMessage("VARTS Workshop Suggestion Mod is successfully loaded"));
        }
    }
}