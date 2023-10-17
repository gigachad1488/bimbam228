using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;

namespace bimbam537.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public static ObservableCollection<Request> requests { get; set; } = new ObservableCollection<Request>();
    public static ObservableCollection<Status> statuses { get; set; } = new ObservableCollection<Status>();
    
    public static ObservableCollection<Defect> defects { get; set; } = new ObservableCollection<Defect>();
    
    public static ObservableCollection<Responsible> responsibles { get; set; } = new ObservableCollection<Responsible>();
    
    public static Db db = new Db();

    public MainWindowViewModel()
    {
        requests.AddRange(MainWindowViewModel.db.GetRequests());
        statuses.AddRange(db.GetStatuses());
        defects.AddRange(db.GetDefects());
        responsibles.AddRange(db.GetResponsibles());
    }

    public static void UpdateCollections()
    {
        requests.Clear();
        statuses.Clear();
        defects.Clear();
        responsibles.Clear();
        
        requests.AddRange(MainWindowViewModel.db.GetRequests());
        statuses.AddRange(db.GetStatuses());
        defects.AddRange(db.GetDefects());
        responsibles.AddRange(db.GetResponsibles());
    }
}