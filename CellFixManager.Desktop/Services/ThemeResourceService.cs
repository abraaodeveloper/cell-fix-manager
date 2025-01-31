using Avalonia;
using Avalonia.Media;
using System.Collections.Generic;

namespace CellFixManager.Desktop.Services
{
    public static class ThemeResourceService
    {
        public static void UpdateThemeResources()
        {
            var theme = ConfigurationService.GetCurrentTheme();
            var app = Application.Current;
            if (app == null) return;

            var resources = new Dictionary<object, object>();

            // Função auxiliar para adicionar cor apenas se não estiver vazia
            void AddColor(string key, string colorHex)
            {
                if (!string.IsNullOrWhiteSpace(colorHex))
                {
                    var color = Color.Parse(colorHex);
                    resources[key + "Color"] = color;
                    resources[key + "Brush"] = new SolidColorBrush(color);
                }
            }

            // Menu
            AddColor("MenuBackground", theme.MenuBackground);
            AddColor("MenuForeground", theme.MenuForeground);
            AddColor("MenuItemHover", theme.MenuItemHoverBackground);

            // Geral
            AddColor("Background", theme.BackgroundColor);
            AddColor("TextColor", theme.TextColor);

            // Inputs
            AddColor("Input", theme.InputBackground);
            AddColor("InputForeground", theme.InputForeground);
            AddColor("InputBorder", theme.InputBorder);
            AddColor("InputPlaceholder", theme.InputPlaceholder);

            // Botões
            AddColor("PrimaryButton", theme.PrimaryButtonBackground);
            AddColor("PrimaryButtonForeground", theme.PrimaryButtonForeground);
            AddColor("SecondaryButton", theme.SecondaryButtonBackground);
            AddColor("SecondaryButtonForeground", theme.SecondaryButtonForeground);
            AddColor("DangerButton", theme.DangerButtonBackground);
            AddColor("DangerButtonForeground", theme.DangerButtonForeground);

            // Destaques
            AddColor("Accent", theme.AccentColor);
            AddColor("Success", theme.SuccessColor);
            AddColor("Warning", theme.WarningColor);
            AddColor("Error", theme.ErrorColor);

            // Bordas
            AddColor("Border", theme.BorderColor);
            AddColor("Separator", theme.SeparatorColor);

            foreach (var resource in resources)
            {
                app.Resources[resource.Key] = resource.Value;
            }
        }
    }
} 