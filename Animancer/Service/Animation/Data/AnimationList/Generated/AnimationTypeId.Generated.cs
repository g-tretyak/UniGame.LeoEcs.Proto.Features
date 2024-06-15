namespace Game.Code.Services.Animation.Data.AnimationList
{
    public partial struct AnimationTypeId
    {
        public static AnimationTypeId None => new AnimationTypeId { value = 0 };
        public static AnimationTypeId Idle => new AnimationTypeId { value = 1 };
        public static AnimationTypeId Run => new AnimationTypeId { value = 2 };
    }
}
