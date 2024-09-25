namespace ArgusService
{
	public class MenuOrder :IMenuOrder
	{
		public double Starter { get;}
        public double Mains { get; }
        public double Drinks { get; }
		public bool ApplyDrinksDiscount { get; }
 

        public MenuOrder(int starterQuantity,int mainQuantity,int drinksQuantity,double orderTime)
		{
			Starter = starterQuantity;
			Mains = mainQuantity;
			Drinks = drinksQuantity;
			if (orderTime < 19.00)
				ApplyDrinksDiscount = true;
		}
	}
}

