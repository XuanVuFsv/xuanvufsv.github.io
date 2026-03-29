using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VitsehLand.Game.Farming.General;
using VitsehLand.Game.Weapon.General;
using VitsehLand.Core.Stat;

namespace VitsehLand.Game.Stats
{
    [CreateAssetMenu(fileName = "New Collectable Object", menuName = "Collectable Object")]
    public class CollectableObjectStat : ScriptableObject, ICollectableObjectStat
    {
        [Flags]
        public enum CollectableObjectComponentBitmaskEnum
        {
            None = 0,
            FarmingCropStat = 1 << 1,
            AttackingCropStat = 1 << 2,
            CraftedProductStat = 1 << 3,
            NaturalResourceStat = 1 << 4,
            All = FarmingCropStat | AttackingCropStat | CraftedProductStat | NaturalResourceStat
        }
        List<string> componentEnums = new List<string>();

        string namespaceName;

        [PropertySpace(SpaceBefore = 20, SpaceAfter = 10)]
        [Title("Choose Collectable Object Components")]
        [OnValueChanged("UpdateContainingComponents")]
        public CollectableObjectComponentBitmaskEnum selectedComponents;
        // Convert componentEnums to a list of component names
        List<string> strSelectedComponents = new List<string>();
        // Convert containing components to a list of component names
        List<string> strComponents = new List<string>();

        public void UpdateContainingComponents()
        {
            componentEnums = Enum.GetNames(typeof(CollectableObjectComponentBitmaskEnum)).ToList();
            namespaceName = (new CollectableObjectStatComponent()).GetType().Namespace + ".";

            if (selectedComponents.Equals(CollectableObjectComponentBitmaskEnum.All))
            {
                for (int i = 1; i < componentEnums.Count - 1; i++)
                {
                    if (strSelectedComponents.Contains(componentEnums[i])) continue;
                    strSelectedComponents.Add(componentEnums[i]);
                }
            }
            else if (!selectedComponents.Equals(CollectableObjectComponentBitmaskEnum.None))
            {
                strSelectedComponents = selectedComponents.ToString().Split(", ").ToList();
            }

            if (selectedComponents.Equals(CollectableObjectComponentBitmaskEnum.None))
            {
                components.Clear();
                strSelectedComponents.Clear();
                strComponents.Clear();
            }
            else
            {
                strComponents = components.Select(item => item.GetType().Name).ToList();

                // Removal check
                for (int i = strComponents.Count - 1; i >= 0; i--)
                {
                    if (strComponents[i] == null || selectedComponents.Equals(CollectableObjectComponentBitmaskEnum.All)) break;

                    if (!strSelectedComponents.Contains(strComponents[i]))
                    {
                        components.RemoveAt(i);
                        strComponents.RemoveAt(i);
                    }
                }

                // Addition check
                foreach (var component in strSelectedComponents)
                {
                    if (!strComponents.Contains(component))
                    {
                        var type = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(a => a.GetTypes())
                            .FirstOrDefault(t => t.Name == component);

                        if (type != null)
                            components.Add((CollectableObjectStatComponent)Activator.CreateInstance(type));
                        else
                            Debug.LogWarning($"[CollectableObjectStat] Type not found: {component}");

                        strComponents.Add(component);
                    }
                }
            }
        }

        [PropertySpace(SpaceBefore = 20, SpaceAfter = 20)]
        [Title("Containing Components")]
        [InfoBox("Components are groups of data that the game uses to process the corresponding actions of the player with a Collectable Object. Not having Component A,B or C means that the player cannot perform the corresponding action on that Collectable Object.")]
        [SerializeReference]
        public List<CollectableObjectStatComponent> components = new List<CollectableObjectStatComponent>();
        public Dictionary<string, CollectableObjectStatComponent> dictComponents;

        [Button("AssignStatFromOldModelToComponentModel")]

        void AssignStat()
        {
            foreach (var component in components)
            {
                capacity = maxCount = 9999;

                if (component is AttackingCropStat)
                {

                }

                if (component is FarmingCropStat)
                {
                    (component as FarmingCropStat).description = description;
                }

                if (component is CraftedProductStat)
                {

                }
            }
        }

        [Title("Base Collectable Object Attributes")]
        [InfoBox("A collectable object is set to Weapon Slot 3 by default. It will be assigned to Weapon Slot 1 or Weapon Slot 2 if it can be used in one of those respective slots.")]
        public ActiveWeapon.WeaponSlot weaponSlot;
        public GameObjectType.FilteredType filteredType;
        public GameObjectType.FeaturedType featuredType;

        [Title("Base ID")]
        public string baseID;
        [Button("Auto Fill Base ID")]

        void AutoFillBaseID()
        {
            if (baseID != null && baseID != "")
            {
                Debug.LogWarning("Base ID is already assigned. Clear the field before auto filling.");
                return;
            }

            if (collectableObjectName == null || collectableObjectName == "")
            {
                Debug.LogWarning("Collectable Object Name is empty. Please assign a name if you want to auto filling Base ID.");
                return;
            }

            baseID = collectableObjectName.Replace(" ", "_").ToLower();
        }

        public Sprite icon;
        public string collectableObjectName;

        [InfoBox("Backpack's slots capacity", InfoMessageType.Info)]
        public int maxCount;

        [InfoBox("Warning: It will be created later. List of object can store collectable object and its max quantity can be stored. Not active now", InfoMessageType.Warning)]
        public int capacity = 9999;

        public int requiredLevel;

        public CollectableObjectStatComponent GetCollectableObjectStatComponent<T>() where T : CollectableObjectStatComponent
        {
            var component = components.OfType<T>().FirstOrDefault();
            if (component == null) Debug.Log($"No component of type {typeof(T).Name} found.");

            return component;
        }

        public int ammmoHolding = 1;
        public string description;
    }
}