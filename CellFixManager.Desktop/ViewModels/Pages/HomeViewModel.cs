using ReactiveUI;
using CellFixManager.Desktop.Services;

namespace CellFixManager.Desktop.ViewModels.Pages;

public class HomeViewModel : ViewModelBase
{
    private string _logoPath = string.Empty;
    
    public string LogoPath
    {
        get => _logoPath;
        set => this.RaiseAndSetIfChanged(ref _logoPath, value);
    }
    
    public HomeViewModel()
    {
        _logoPath = ConfigurationService.GetLogoPath();
    }
}