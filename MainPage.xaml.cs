using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace BuscaDinamicaProdutos
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Produtos { get; set; } = new ObservableCollection<string>
        {
            "Notebook",
            "Smartphone",
            "Tablet",
            "Smartwatch",
            "Fone de Ouvido",
            "Teclado",
            "Mouse",
            "Monitor"
        };

        public ObservableCollection<string> ProdutosFiltrados { get; set; } = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            ProdutosFiltrados = new ObservableCollection<string>(Produtos);
            BindingContext = this;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string textoBusca = e.NewTextValue?.ToLower() ?? string.Empty;

            ProdutosFiltrados.Clear();

            var resultados = Produtos.Where(p => p.ToLower().Contains(textoBusca));

            foreach (var produto in resultados)
            {
                ProdutosFiltrados.Add(produto);
            }
        }
    }
}

