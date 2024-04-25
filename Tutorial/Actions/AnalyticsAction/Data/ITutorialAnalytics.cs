namespace unigame.ecs.proto.Gameplay.Tutorial.Actions.AnalyticsAction.Data
{
    public interface ITutorialAnalytics
    {
        void Send(TutorialMessage message);
    }
}