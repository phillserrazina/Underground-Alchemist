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

		public class Builder
		{
			public Order Build()
			{
				List<ItemSO> orderedItems = new();

				Order newOrder  = new(orderedItems);
				return newOrder;
			}
		}
	}
}