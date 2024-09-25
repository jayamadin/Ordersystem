namespace ArgusService
{
	public interface IMenuOrder
	{
        public double Starter { get; }
        public double Mains { get; }
        public double Drinks { get; }
        public bool ApplyDrinksDiscount { get; }
    }
}

