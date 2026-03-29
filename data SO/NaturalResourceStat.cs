using Sirenix.OdinInspector;
using UnityEngine;
using VitsehLand.Game.Farming.General;
using VitsehLand.Core.Stat;

namespace VitsehLand.Game.Stats
{
    [System.Serializable]
    public class NaturalResourceStat : CollectableObjectStatComponent
    {
        //public Suckable naturalResourcePrefab;

        //public int requiredLevel;
        [DetailedInfoBox("Durability modifier that scales the breaking difficulty. Values greater than 1.0 increase resistance to breaking, while values less than or equal to 1.0 decrease it. This directly affects how quickly resources can be harvested relative to the player's level",
            "Formula: Real durabilityModifier = XPManager.Instance.level >= naturalResourceStat.requiredLevel ? 1 : (naturalResourceStat.requiredLevel / XPManager.Instance.level  * naturalResourceStat.durabilityModifier)")]
        public float durabilityModifier = 5;
        public string description;

        [InfoBox("Max resources ammount that a cluster resource contain")]
        [Range(3, 10)]
        public int maxAmount = 3;

        public float maxDurability = 100;
        public int recoverTime = 3;
        public int collectTime = 3;

        //public int gemEarnWhenHaverst;
    }
}