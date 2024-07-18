using UnityEngine;

using System.Collections.Generic;

namespace PJ.Data
{
	public class Order 
	{
		// VARIABLES
		public ItemSO[] OrderedItems => itemList.ToArray();
	
		private readonly List<ItemSO> itemList = new();

		// CONSTRUCTOR
		private Order(List<ItemSO> items)
		{
			itemList = new(items);
		}

        // METHODS
        public override string ToString()
        {
			string orderString = "Order: ";

			foreach (var item in itemList)
			{
				orderString += item.Name + ", ";
			}

			return orderString;
        }

        // HELPER CLASS
        public class Builder
		{
			public Order Build()
			{
				List<ItemSO> orderedItems = new();

				var allItems = Resources.LoadAll<ItemSO>("Items");

				for (int i = 0; i < Random.Range(1, 4); i++)
				{
					orderedItems.Add(allItems[Random.Range(0, allItems.Length)]);
				}

				Order newOrder  = new(orderedItems);
				return newOrder;
			}
		}
	}
}