namespace ArgusService
{
	public class OrderProcessor
	{
		private readonly IList<double> _currentBill = new List<double>();
        private readonly IList<IMenuOrder> _orderQue = new List<IMenuOrder>();

        public OrderProcessor(IMenuOrder menuOrder)
		{
			_orderQue.Add(menuOrder);
		}

		public OrderProcessor(IList<IMenuOrder> menuOrders)
		{
			foreach(var menuOrder in menuOrders)
			{
				_orderQue.Add(menuOrder);
			}
		}
		
		public OrderProcessor(){}

		public void CalculateOrder()
		{
			foreach (var item in _orderQue)
			{
				var drinksTotal = item.Drinks * MenuPrices.Drinks;
				var starterTotal = item.Starter * MenuPrices.Starter;
				var mainsTotal = item.Mains * MenuPrices.Mains;

				var foodServiceCharge = (starterTotal + mainsTotal) * ServiceCharges.Food;
				if (item.ApplyDrinksDiscount)
				{
					var discountAmount = drinksTotal * Discounts.Drinks;
                    drinksTotal -= discountAmount;
				}
				var total = drinksTotal + starterTotal + mainsTotal + foodServiceCharge;
				_currentBill.Add(total);
			} 
			_orderQue.Clear();
		}

		public void AddOrder(MenuOrder menuOrder)
		{
			_orderQue.Add(menuOrder);
		}

		public void RemoveOrder(int orderIndex = 0)
		{
			if (_currentBill.Count > 0)
			{
				_currentBill.RemoveAt(orderIndex);
			}	
		}

		public double GetCurrentBill()
		{
			return  Math.Round(_currentBill.Sum(),1);
		}

		
	}


}

