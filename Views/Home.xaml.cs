using AppVet.DTO;
using System.ComponentModel;
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
    public List<Pet> CreatePet()
	{
        return new List<Pet>
        { 
            new Pet
            {
                tutor = "Matheus Augusto Santana",
                tel = 13981639944,
                nomePet = "Broinha",
                especie = "Cachorro",
                raca = "Jack Russel",
                idade = 2,
                sexo = "Macho",
                peso = 8.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            },
            new Pet
            {
                tutor = "Ieda Cristina dos Santos Duclos",
                tel = 13982104931,
                nomePet = "Princess",
                especie = "Cachorro",
                raca = "Lulu da pomerania",
                idade = 1,
                sexo = "Femea",
                peso = 2.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            },
            new Pet
            {
                tutor = "Maria José da Silva",
                tel = 139815153315,
                nomePet = "Geleia",
                especie = "Gato",
                raca = "SRD",
                idade = 3,
                sexo = "Femea",
                peso = 2.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            },
            new Pet
            {
                tutor = "Lucia Duclos",
                tel = 139815153315,
                nomePet = "Sexta Feira",
                especie = "Gato",
                raca = "SRD",
                idade = 6,
                sexo = "Femea",
                peso = 2.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            },
            new Pet
            {
                tutor = "Lucia Duclos",
                tel = 139815153315,
                nomePet = "Lichia",
                especie = "Gato",
                raca = "SRD",
                idade = 4,
                sexo = "Femea",
                peso = 2.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            },
            new Pet
            {
                tutor = "Lucia Duclos",
                tel = 139815153315,
                nomePet = "Domingos",
                especie = "Gato",
                raca = "SRD",
                idade = 5,
                sexo = "Macho",
                peso = 2.5f,
                dataVacinacao = DateTime.Now.Date.AddDays(-360),
                dataProximaVacinacao = DateTime.Now.Date.AddDays(30),
                vacina = "Raiva",
                laboratorio = "Zoetis"
            }
        };
	}

    private async void OnItemSelected(Pet selectedPet)
    {
        await Navigation.PushAsync(new NewService(selectedPet));
    }

    protected void cadastros()
    {
        PetsCollectionView.ItemsSource = CreatePet();
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