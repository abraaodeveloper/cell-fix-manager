using ReactiveUI;
using System;
using System.Windows.Input;

namespace CellFixManager.Desktop.ViewModels
{
    public class SearchBarViewModel : ReactiveObject
    {
        private string? _searchText;
        private string? _selectedStatus;
        private DateTime? _selectedDate;

        public string? SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public string? SelectedStatus
        {
            get => _selectedStatus;
            set => this.RaiseAndSetIfChanged(ref _selectedStatus, value);
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set => this.RaiseAndSetIfChanged(ref _selectedDate, value);
        }

        public ICommand SearchCommand { get; }

        public SearchBarViewModel()
        {
            SearchCommand = ReactiveCommand.Create(ExecuteSearch);
            _searchText = string.Empty;
            _selectedStatus = string.Empty;
        }

        private void ExecuteSearch()
        {
            // Implementar lógica de pesquisa
        }
    }
} 