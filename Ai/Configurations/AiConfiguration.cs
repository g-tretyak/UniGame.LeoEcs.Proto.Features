namespace unigame.ecs.proto.AI.Configurations
{
    using System;
    using Sirenix.OdinInspector;

    [Serializable]
    public class AiConfiguration
    {
        [Searchable(FilterOptions = SearchFilterOptions.ISearchFilterableInterface)]
        [ListDrawerSettings(ListElementLabelName = "@name")]
        public AiActionData[] aiActions = Array.Empty<AiActionData>();
    }
}