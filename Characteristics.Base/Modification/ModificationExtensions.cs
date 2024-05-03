namespace UniGame.Ecs.Proto.Characteristics
{
    using System.Collections.Generic;
    using UnityEngine;
    
    public static class ModificationExtensions
    {
        private const float HundredPercent = 100.0f;
        
        public static float Apply(this IEnumerable<Modification> modifications, float baseValue)
        {
            var currentValue = baseValue;
            foreach (var modification in modifications)
            {
                if (modification.isPercent) continue;
                currentValue += modification.baseValue * modification.counter;
            }

            var percentModification = HundredPercent;
            foreach (var modification in modifications)
            {
                if (!modification.isPercent) continue;
                percentModification += modification.baseValue * modification.counter;
            }

            currentValue *= percentModification / HundredPercent;

            return Mathf.Max(currentValue, 0.0f);
        }

        public static void AddModification(this IList<Modification> modifications, Modification modification)
        {
            var isModificationContains = modifications.Contains(modification);
            
            if(!modification.allowedSummation && isModificationContains) return;

            modification.counter++;
            
            if (isModificationContains) return;
            
            modifications.Add(modification);
        }

        public static void RemoveModification(this IList<Modification> modifications, Modification modification)
        {
            modification.counter--;
            
            if(!modifications.Contains(modification) || modification.counter > 0) return;

            modifications.Remove(modification);
        }
    }
}