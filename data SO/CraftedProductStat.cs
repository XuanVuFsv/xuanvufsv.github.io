using UnityEngine;
using VitsehLand.Game.Crafting;
using VitsehLand.Game.Farming.General;
using VitsehLand.Core.Stat;

namespace VitsehLand.Game.Stats
{
    [System.Serializable]
    public class CraftedProductStat : CollectableObjectStatComponent
    {
        public RecipeData recipe;
        public float totalProducingTime = 10;
        public int cost;
    }
}