using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using CellFixManager.Desktop.ViewModels;
using CellFixManager.Desktop.Views;
using CellFixManager.Desktop.Services;
using System;

namespace CellFixManager.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        try
        {
            AvaloniaXamlLoader.Load(this);
            LogService.Info("Aplicação inicializada com sucesso");
        }
        catch (Exception ex)
        {
            LogService.Error("Erro ao inicializar a aplicação", ex);
            throw;
        }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        try
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                ThemeResourceService.UpdateThemeResources(); // Inicializa os recursos do tema
                LogService.Info("Configurando janela principal");
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
            }
            base.OnFrameworkInitializationCompleted();
            LogService.Info("Framework inicializado com sucesso");
        }
        catch (Exception ex)
        {
            LogService.Error("Erro ao completar inicialização do framework", ex);
            throw;
        }
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}