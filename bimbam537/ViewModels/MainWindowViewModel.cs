using System.Collections.Generic;

namespace bimbam537.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<asd> asd { get; set; }

    public MainWindowViewModel()
    {
        asd = new List<asd>();
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        asd.Add(new asd("1", "2", "3", "4", "5"));
        
        asd.Add(new asd("1", "2", "3", "4", "5"));
    }
}