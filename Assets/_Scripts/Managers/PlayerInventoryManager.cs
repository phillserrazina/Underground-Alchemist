using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

using Sirenix.OdinInspector;
using Lucerna.Common.Singletons;

using PJ.Data;

namespace PJ.Managers
{
	public class PlayerInventoryManager : Singleton<PlayerInventoryManager>
	{
		// VARIABLES
		[SerializeField] private int startingMoney = 5;
        [SerializeField] private ItemSO[] startingItems;

        [Title("Debug")]
		[SerializeField] private bool useDebugData;
		[SerializeField, ShowIf("useDebugData")] private int debugMoney = 100;

		[ShowInInspector, ReadOnly] public int CurrentMoneyOwned { get; private set; }

		public Dictionary<ItemSO, int> ItemsDictionary { get; private set; } = new();

		public event Action OnInitialized;
		public event Action<int> OnMoneyChanged;
		public event Action<Dictionary<ItemSO, int>> OnInventoryChanged;

        // EXECUTION FUNCTIONS
        private void Start()
        {
            if (useDebugData)
            {
                Initialize(debugMoney);
            }
            else
            {
                // TODO: Check if a save file exists, if not just create a new one
                Initialize(startingMoney);
            }
        }

        private void Update()
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                AddMoney(1);
            }
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RemoveMoney(1);
            }
        }

        // METHODS
        public void Initialize(int money)
		{
			CurrentMoneyOwned = money;

			foreach (var item in startingItems)
			{
				AddItem(item);
			}

			OnInitialized?.Invoke();
		}

		public void AddMoney(int amount)
		{
			SetMoneyValue(CurrentMoneyOwned + amount);
		}

        public void RemoveMoney(int amount)
        {
            SetMoneyValue(CurrentMoneyOwned - amount);
        }

        private void SetMoneyValue(int value)
		{
			CurrentMoneyOwned = value;
			CurrentMoneyOwned = Mathf.Clamp(CurrentMoneyOwned, 0, 99999);

			OnMoneyChanged?.Invoke(CurrentMoneyOwned);
		}

		public void AddItem(ItemSO item)
		{
			if (!ItemsDictionary.ContainsKey(item))
			{
				ItemsDictionary.Add(item, 0);
			}

			ItemsDictionary[item]++;
			OnInventoryChanged?.Invoke(ItemsDictionary);
		}

		public void RemoveItem(ItemSO item)
		{
			ItemsDictionary[item]--;

			if (ItemsDictionary[item] == 0)
			{
				ItemsDictionary.Remove(item);
			}

            OnInventoryChanged?.Invoke(ItemsDictionary);
        }
    
		public bool HasItem(ItemSO item) => ItemsDictionary.ContainsKey(item);

		public int GetItemAmount(ItemSO item)
		{
			if (!HasItem(item))
			{
				return 0;
			}

			return ItemsDictionary[item];
		}

		public bool CanCraftRecipe(RecipeSO recipe)
		{
			foreach (var ingredient in recipe.Ingredients)
			{
				if (!HasItem(ingredient))
				{
					return false;
				}
			}

			return true;
		}
	}
}