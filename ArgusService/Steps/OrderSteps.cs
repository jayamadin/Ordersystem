using FluentAssertions;

namespace ArgusService.Steps;

[Binding]
public class OrderSteps
{
    private readonly OrderProcessor _orderProcessor = new();
    private int _noOfPeopleOrdering;
    private double _timeOfOrder;


    [Given(@"A group of (.*) people place an order at (.*)")]
    [When(@"A group of (.*) people place an order at (.*)")]
    public void AGroupOfPeopleMakeAnOrder(int noOfPeople,double orderTime)
    {
        _noOfPeopleOrdering = noOfPeople;
        _timeOfOrder = orderTime;
        
    }


    [Given(@"The order contains (.*) starter (.*) drinks (.*) main per person")]
    [When(@"The order contains (.*) starter (.*) drinks (.*) main per person")]
    public void GivenTheOrderContainsStartsDrinksMainPerPersons(int noOfStarters, int noOfDrinks, int noOfMain)
    {
        for (int i = 0; i < _noOfPeopleOrdering ; i++)
        {
            _orderProcessor.AddOrder(new MenuOrder(noOfStarters, noOfDrinks, noOfMain,_timeOfOrder));
        }
    }


 

    [When (@"The bill is requested")]
    [Given (@"The bill is requested")]
    public void WhenTheBillIsRequested()
    {
         _orderProcessor.CalculateOrder();
    }

    [Then (@"The correct amount of (.*) is Returned")]
    [Given (@"The correct amount of (.*) is Returned")]
    public void ThenTheCorrectAmountOfIsReturned(double billAmount)
    {
        _orderProcessor.GetCurrentBill().Should().Be(billAmount);
    }


    [When(@"An order is removed from the bill")]
    public void WhenAnOrderIsRemovedFromTheBill()
    {
        _orderProcessor.RemoveOrder();
    }
}