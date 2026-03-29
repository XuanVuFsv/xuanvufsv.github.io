using Sirenix.OdinInspector;
using UnityEngine;
using VitsehLand.Core.Stat;

namespace VitsehLand.Game.Stats
{
    [System.Serializable]
    public class FarmingCropStat : CollectableObjectStatComponent
    {
        public enum BodyType
        {
            None = -1,
            Tree = 0,
            Vegetable = 1,
            Climbing = 2
        }

        [DetailedInfoBox("Body Types  of Crop:", 
            "-None for Non-woody plants (e.g., lettuce).\n" +
            "-Tree for fruit-bearing crop (e.g., apple).\n" +
            "-Vegetable for vegetables (eg., carrot, lettuce).\n" +
            "-Climbing for climbing plants (eg., grapes).")]
        public BodyType bodyType;
        [Tooltip("Except None BodyType")]
        [Title("3D Models")]
        public GameObject growingBody;
        public GameObject defaultModelPlant;

        [Title("VFX")]
        public GameObject seedOuterEffect, wholeOuterEffect;

        [Title("Farming Stats")]
        public int totalGrowingTime = 10;
        public int totalHarvestingQuantity = 3;
        public int wateringTime = 1;

        //public int requiredLevel = 0;
        public string description;

        //public int gemEarnWhenHaverst;
    }
}