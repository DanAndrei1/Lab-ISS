using System.Windows.Input;
using ReactiveUI;

namespace AgentiVanzari.ViewModels;

public class OrderViewModel : ReactiveObject
{
    public ICommand OrderCammand { get; }
    
    public OrderViewModel()
    {
        OrderCammand = ReactiveCommand.Create(OrderProduct);
    }

    private void OrderProduct()
    {
    }
}