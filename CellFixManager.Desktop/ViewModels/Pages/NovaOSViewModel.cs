using System;
using CellFixManager.Desktop.Services;
using ReactiveUI;

namespace CellFixManager.Desktop.ViewModels.Pages
{
    public class NovaOSViewModel : ViewModelBase
    {
        private string _cliente = string.Empty;
        private string _telefone = string.Empty;
        private string _email = string.Empty;
        private string _marca = string.Empty;
        private string _modelo = string.Empty;
        private string _imei = string.Empty;
        private string _senha = string.Empty;
        private string _acessorios = string.Empty;
        private string _problema = string.Empty;
        private string _observacoes = string.Empty;
        private decimal _valorServico;
        private decimal _valorPecas;
        private DateTime _previsao = DateTime.Now;
        private decimal _total;

        public string Cliente
        {
            get => _cliente;
            set => this.RaiseAndSetIfChanged(ref _cliente, value);
        }

        public string Telefone
        {
            get => _telefone;
            set => this.RaiseAndSetIfChanged(ref _telefone, value);
        }

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public string Marca
        {
            get => _marca;
            set => this.RaiseAndSetIfChanged(ref _marca, value);
        }

        public string Modelo
        {
            get => _modelo;
            set => this.RaiseAndSetIfChanged(ref _modelo, value);
        }

        public string IMEI
        {
            get => _imei;
            set => this.RaiseAndSetIfChanged(ref _imei, value);
        }

        public string Senha
        {
            get => _senha;
            set => this.RaiseAndSetIfChanged(ref _senha, value);
        }

        public string Acessorios
        {
            get => _acessorios;
            set => this.RaiseAndSetIfChanged(ref _acessorios, value);
        }

        public string Problema
        {
            get => _problema;
            set => this.RaiseAndSetIfChanged(ref _problema, value);
        }

        public string Observacoes
        {
            get => _observacoes;
            set => this.RaiseAndSetIfChanged(ref _observacoes, value);
        }

        public decimal ValorServico
        {
            get => _valorServico;
            set
            {
                this.RaiseAndSetIfChanged(ref _valorServico, value);
                CalcularTotal();
            }
        }

        public decimal ValorPecas
        {
            get => _valorPecas;
            set
            {
                this.RaiseAndSetIfChanged(ref _valorPecas, value);
                CalcularTotal();
            }
        }

        public DateTime Previsao
        {
            get => _previsao;
            set => this.RaiseAndSetIfChanged(ref _previsao, value);
        }

        public decimal Total
        {
            get => _total;
            private set => this.RaiseAndSetIfChanged(ref _total, value);
        }

        private void CalcularTotal()
        {
            Total = ValorServico + ValorPecas;
        }

        public NovaOSViewModel()
        {
            LogService.Info("Inicializando NovaOSViewModel");
            _previsao = DateTime.Now.AddDays(2); // Previsão padrão de 2 dias
        }
    }
} 