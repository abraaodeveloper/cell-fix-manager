using Avalonia.Controls;
using Avalonia.Threading;
using CellFixManager.Desktop.Services;
using CellFixManager.Desktop.Views.Pages;
using CellFixManager.Desktop.ViewModels.Pages;
using System;
using System.Windows.Input;
using CellFixManager.Desktop.Models;
using ReactiveUI;

namespace CellFixManager.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentPage;
        private Theme _selectedTheme;

        public ViewModelBase CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }

        public Theme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedTheme, value);
                ConfigurationService.SaveTheme(value.Name);
                ThemeResourceService.UpdateThemeResources();
            }
        }

        public bool IsVerticalMenu => ConfigurationService.GetMenuStyle() == 0;

        public MainWindowViewModel()
        {
            LogService.Info("Inicializando MainWindowViewModel");
            
            try
            {
                _selectedTheme = ConfigurationService.GetCurrentTheme();
                _currentPage = new HomeViewModel();
                
                ThemeResourceService.UpdateThemeResources();

                LogService.Info("MainWindowViewModel inicializado com sucesso");
            }
            catch (Exception ex)
            {
                LogService.Error("Erro ao inicializar MainWindowViewModel", ex);
                throw;
            }
        }

        public void NavigateToHome() => CurrentPage = new HomeViewModel();
        public void NavigateToNovaOS() => CurrentPage = new NovaOSViewModel();
        public void NavigateToClientes() => CurrentPage = new ClientesViewModel();
        public void NavigateToConfiguracoes() => CurrentPage = new ConfiguracoesViewModel(this);

        public void RefreshMenuStyle()
        {
            this.RaisePropertyChanged(nameof(IsVerticalMenu));
        }
    }

    // Implementação básica do RelayCommand
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T?> _execute;

        public RelayCommand(Action<T?> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _execute((T?)parameter);
        }
    }
}
