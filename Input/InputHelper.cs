namespace unigame.ecs.proto.Input
{
     

    public static class InputHelper
    {
        public static void ProcessBeginUserInput<T>(ProtoWorld world, EcsFilter filter, ref bool state) where T : struct
        {
            if(state)
                return;

            state = true;
            
            var beginUserInputPool = world.GetPool<T>();

            foreach (var entity in filter)
            {
                beginUserInputPool.Add(entity);
            }
        }
        
        public static void ProcessEndUserInput<T>(ProtoWorld world, EcsFilter filter, ref bool state) where T : struct
        {
            if (!state)
                return;
            
            state = false;

            var endUserInputPool = world.GetPool<T>();

            foreach (var entity in filter)
            {
                endUserInputPool.Add(entity);
            }
        }
    }
}