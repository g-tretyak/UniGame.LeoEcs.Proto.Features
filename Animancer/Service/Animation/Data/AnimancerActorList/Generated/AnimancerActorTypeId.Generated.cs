namespace Game.Code.Services.Animation.Data.AnimacerActorList
{
    public partial struct AnimancerActorTypeId
    {
        public static AnimancerActorTypeId None => new AnimancerActorTypeId { value = 0 };
        public static AnimancerActorTypeId Warrior => new AnimancerActorTypeId { value = 1 };
    }
}
