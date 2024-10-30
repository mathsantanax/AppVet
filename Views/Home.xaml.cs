using AppVet.DTO;
using System.ComponentModel;
using AppVet.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace AppVet.Views;

public partial class Home : ContentPage, INotifyPropertyChanged
{
    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value;
            OnPropertyChanged(nameof(IsRefreshing));
        }
    }
    Models.ServicoModel ServicoModel = new ServicoModel();

    public ICommand RefreshCommand { get; }
    public ICommand ItemSelectedCommand { get; }
    public ICommand DeleteCommand { get; }

    public Home()
    {
        InitializeComponent();
        BindingContext = this;
        RefreshCommand = new Command(executeRefreshCommand);
        ItemSelectedCommand = new Command<Pet>(OnItemSelected);
        cadastros();
    }

    private async void OnItemSelected(Pet selectedPet)
    {
        await Navigation.PushAsync(new NewService(selectedPet));
    }

    protected async void cadastros()
    {
        var Cadastros = await ServicoModel.ListarPetETutor();
        PetsCollectionView.ItemsSource = Cadastros;
        IsRefreshing = false;
    }

    protected void executeRefreshCommand()
    {
        IsRefreshing = true;
        cadastros();
        IsRefreshing = false;
    }

    async void OnItemTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        frame.BackgroundColor = Color.FromArgb("#D3D3D3"); // Light gray
        await Task.Delay(100); // Tap effect duration
        frame.BackgroundColor = Colors.White; // Original color
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private async void AddPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPet());
    }
}