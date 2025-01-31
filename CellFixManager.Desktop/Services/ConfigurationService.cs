using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using CellFixManager.Desktop.Models;

namespace CellFixManager.Desktop.Services
{
    public static class ConfigurationService
    {
        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CellFixManager",
            "config.json"
        );

        private static Configuration _config = new();

        static ConfigurationService()
        {
            LoadConfiguration();
        }

        private static void LoadConfiguration()
        {
            if (!File.Exists(ConfigPath))
            {
                _config = new Configuration();
                SaveConfiguration();
                return;
            }

            var json = File.ReadAllText(ConfigPath);
            _config = JsonSerializer.Deserialize<Configuration>(json) ?? new Configuration();
        }

        private static void SaveConfiguration()
        {
            var directory = Path.GetDirectoryName(ConfigPath);
            if (!Directory.Exists(directory) && directory != null)
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(_config);
            File.WriteAllText(ConfigPath, json);
        }

        public static string GetLogoPath()
        {
            return _config.LogoPath;
        }
        
        public static void SaveLogoPath(string path)
        {
            _config.LogoPath = path;
            SaveConfiguration();
        }

        public static Theme GetCurrentTheme()
        {
            return Themes[_config.Theme];
        }

        public static void SaveTheme(string theme)
        {
            _config.Theme = theme;
            SaveConfiguration();
        }

        public static int GetMenuStyle() => _config.MenuStyle;

        public static readonly Dictionary<string, Theme> Themes = new()
        {
            ["Dark"] = new Theme
            {
                Name = "Dark",
                MenuBackground = "#1E1E1E",
                MenuForeground = "#808080",
                MenuItemHoverBackground = "#333333",
                BackgroundColor = "#121212",
                TextColor = "#FFFFFF",
                InputBackground = "#2D2D2D",
                InputForeground = "#FFFFFF",
                InputBorder = "#404040",
                InputPlaceholder = "#808080",
                PrimaryButtonBackground = "#2196F3",
                PrimaryButtonForeground = "#FFFFFF",
                SecondaryButtonBackground = "#424242",
                SecondaryButtonForeground = "#FFFFFF",
                DangerButtonBackground = "#F44336",
                DangerButtonForeground = "#FFFFFF",
                AccentColor = "#2196F3",
                SuccessColor = "#4CAF50",
                WarningColor = "#FFC107",
                ErrorColor = "#F44336",
                BorderColor = "#404040",
                SeparatorColor = "#333333"
            },
            ["Light"] = new Theme
            {
                Name = "Light",
                MenuBackground = "#1E1E1E",
                MenuForeground = "#FFFFFF",
                MenuItemHoverBackground = "#333333",
                BackgroundColor = "#FFFFFF",
                TextColor = "#212121",
                InputBackground = "#FFFFFF",
                InputForeground = "#212121",
                InputBorder = "#BDBDBD",
                InputPlaceholder = "#9E9E9E",
                InputHoverBorder = "#90CAF9",
                InputFocusBorder = "#64B5F6",
                InputHoverBackground = "#FAFAFA",
                PrimaryButtonBackground = "#1976D2",
                PrimaryButtonForeground = "#FFFFFF",
                SecondaryButtonBackground = "#F5F5F5",
                SecondaryButtonForeground = "#424242",
                DangerButtonBackground = "#D32F2F",
                DangerButtonForeground = "#FFFFFF",
                AccentColor = "#1976D2",
                SuccessColor = "#388E3C",
                WarningColor = "#F57C00",
                ErrorColor = "#D32F2F",
                BorderColor = "#E0E0E0",
                SeparatorColor = "#EEEEEE"
            },
            ["Blue"] = new Theme
            {
                Name = "Blue",
                MenuBackground = "#1976D2",
                MenuForeground = "#FFFFFF",
                MenuItemHoverBackground = "#1565C0",
                BackgroundColor = "#E3F2FD",
                TextColor = "#000000",
                InputBackground = "#FFFFFF",
                InputForeground = "#000000",
                InputBorder = "#90CAF9",
                InputPlaceholder = "#64B5F6",
                PrimaryButtonBackground = "#2196F3",
                PrimaryButtonForeground = "#FFFFFF",
                SecondaryButtonBackground = "#90CAF9",
                SecondaryButtonForeground = "#000000",
                DangerButtonBackground = "#F44336",
                DangerButtonForeground = "#FFFFFF",
                AccentColor = "#2196F3",
                SuccessColor = "#4CAF50",
                WarningColor = "#FFC107",
                ErrorColor = "#F44336",
                BorderColor = "#90CAF9",
                SeparatorColor = "#BBDEFB"
            }
        };

        public static void SaveMenuStyle(int style)
        {
            _config.MenuStyle = style;
            SaveConfiguration();
        }

        private class Configuration
        {
            public int MenuStyle { get; set; } = 0;
            public string Theme { get; set; } = "Dark";
            public string LogoPath { get; set; } = "";
        }
    }
} 