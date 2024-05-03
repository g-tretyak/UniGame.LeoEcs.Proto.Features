namespace UniGame.Ecs.Proto.Characteristics
{
    using System;

    public interface IModificationFactory
    {
        Type TargetType { get; }
        
        ModificationHandler Create(float value);
    }
}