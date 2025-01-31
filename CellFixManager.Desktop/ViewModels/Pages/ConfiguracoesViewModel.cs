using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using CellFixManager.Desktop.Services;
using ReactiveUI;
using CellFixManager.Desktop.Models;

namespace CellFixManager.Desktop.ViewModels.Pages
{
    public class ConfiguracoesViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel _mainViewModel;
        private int _menuStyle;
        private string _selectedTheme;
        
        public int MenuStyle
        {
            get => _menuStyle;
            set
            {
                try
                {
                    LogService.Info($"Alterando estilo do menu para: {value}");
                    this.RaiseAndSetIfChanged(ref _menuStyle, value);
                    ConfigurationService.SaveMenuStyle(value);
                    _mainViewModel.RefreshMenuStyle();
                    LogService.Info("Estilo do menu alterado com sucesso");
                }
                catch (Exception ex)
                {
                    LogService.Error("Erro ao alterar estilo do menu", ex);
                    throw;
                }
            }
        }

        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                try
                {
                    LogService.Info($"Alterando tema para: {value}");
                    this.RaiseAndSetIfChanged(ref _selectedTheme, value);
                    ConfigurationService.SaveTheme(value);
                    ThemeResourceService.UpdateThemeResources();
                    LogService.Info("Tema alterado com sucesso");
                }
                catch (Exception ex)
                {
                    LogService.Error("Erro ao alterar tema", ex);
                    throw;
                }
            }
        }

        public string[] AvailableThemes => new[] { "Light", "Dark", "Blue" };

        public ICommand SalvarCommand { get; }

        public ConfiguracoesViewModel(MainWindowViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            try
            {
                LogService.Info("Inicializando ConfiguracoesViewModel");
                _menuStyle = ConfigurationService.GetMenuStyle();
                _selectedTheme = ConfigurationService.GetCurrentTheme().Name;
                SalvarCommand = new RelayCommand<object>(_ => ExecuteSalvar());
                LogService.Info("ConfiguracoesViewModel inicializado com sucesso");
            }
            catch (Exception ex)
            {
                LogService.Error("Erro ao inicializar ConfiguracoesViewModel", ex);
                throw;
            }
        }

        private void ExecuteSalvar()
        {
            try
            {
                LogService.Info($"Salvando configurações. MenuStyle: {MenuStyle}, Theme: {SelectedTheme}");
                ConfigurationService.SaveMenuStyle(MenuStyle);
                ConfigurationService.SaveTheme(SelectedTheme);
                ThemeResourceService.UpdateThemeResources();
                NotifyMainWindowOfChanges();
                LogService.Info("Configurações salvas com sucesso");
            }
            catch (Exception ex)
            {
                LogService.Error("Erro ao salvar configurações", ex);
            }
        }

        private void NotifyMainWindowOfChanges()
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                if (desktop.MainWindow?.DataContext is MainWindowViewModel mainVM)
                {
                    mainVM.RefreshMenuStyle();
                }
            }
        }
    }
} 