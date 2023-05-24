using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

public class BurgerViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Burger> Burgers { get; set; }

    public BurgerViewModel()
    {
        Burgers = new ObservableCollection<Burger>
        {
            new Burger { Name = "Classic Burger", Price = 5.99, Stock = 10 },
            new Burger { Name = "Cheeseburger", Price = 6.99, Stock = 8 },
            new Burger { Name = "Bacon Burger", Price = 7.99, Stock = 5 }
        };
    }
       public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Burger : INotifyPropertyChanged
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand IncreaseQuantityCommand => new Command(IncreaseQuantity);
    public ICommand DecreaseQuantityCommand => new Command(DecreaseQuantity);

    private void IncreaseQuantity()
    {
        if (Quantity < Stock)
        {
            Quantity++;
        }
    }

    private void DecreaseQuantity()
    {
        if (Quantity > 0)
        {
            Quantity--;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
