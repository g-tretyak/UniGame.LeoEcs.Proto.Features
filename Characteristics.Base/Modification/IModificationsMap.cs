namespace UniGame.Ecs.Proto.Characteristics
{
    using System;
    using System.Collections.Generic;

    public interface IModificationsMap
    {
        IEnumerable<string> Modifications { get; }
        
        ModificationInfo GetModificationInfo(Type type);
        
        ModificationHandler Create(string type,float value);

        ModificationHandler Create(Type type, float value);
    }
}