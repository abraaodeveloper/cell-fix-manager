namespace CellFixManager.Desktop.Models
{
    public class Theme
    {
        public string Name { get; set; } = "";
        
        // Cores do Menu
        public string MenuBackground { get; set; } = "";
        public string MenuForeground { get; set; } = "";
        public string MenuItemHoverBackground { get; set; } = "";
        
        // Cores Gerais
        public string BackgroundColor { get; set; } = "";
        public string TextColor { get; set; } = "";
        
        // Cores dos Inputs
        public string InputBackground { get; set; } = "";
        public string InputForeground { get; set; } = "";
        public string InputBorder { get; set; } = "";
        public string InputPlaceholder { get; set; } = "";
        
        // Cores dos Botões
        public string PrimaryButtonBackground { get; set; } = "";
        public string PrimaryButtonForeground { get; set; } = "";
        public string SecondaryButtonBackground { get; set; } = "";
        public string SecondaryButtonForeground { get; set; } = "";
        public string DangerButtonBackground { get; set; } = "";
        public string DangerButtonForeground { get; set; } = "";
        
        // Cores de Destaque
        public string AccentColor { get; set; } = "";
        public string SuccessColor { get; set; } = "";
        public string WarningColor { get; set; } = "";
        public string ErrorColor { get; set; } = "";
        
        // Cores de Bordas e Separadores
        public string BorderColor { get; set; } = "";
        public string SeparatorColor { get; set; } = "";
        
        // Novas propriedades para estados dos inputs
        public string InputHoverBorder { get; set; } = "";
        public string InputFocusBorder { get; set; } = "";
        public string InputHoverBackground { get; set; } = "";
    }
} 