using AppVet.DTO;
using System.ComponentModel;
using AppVet.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using AppVet.ModelView;

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
        ItemSelectedCommand = new Command<PetAndTutor>(OnItemSelected);
        executeRefreshCommand();
    }

    private async void OnItemSelected(PetAndTutor selectedPet)
    {
        await Navigation.PushAsync(new NewService(selectedPet));
    }

    protected async Task<List<PetAndTutor>> cadastros()
    {
        var petAndTutors = new List<PetAndTutor>();
        var tutors = await ServicoModel.ListarTutor();

        if (tutors != null && tutors.Any())
        {
            foreach (var tutor in tutors)
            {
                var pet = await ServicoModel.SelectPet(tutor.IdPet);
                DisplayAlert("Alert", $"{tutor.IdPet}\n{tutor.tutor}", "Ok");
                if (pet != null)
                {
                    var raca = await ServicoModel.SelectRaca(pet.IdRaca);
                    if (raca != null)
                    {
                        petAndTutors.Add(new PetAndTutor
                        {
                            Id = tutor.Id,
                            tutor = tutor.tutor,
                            tel = tutor.tel,
                            IdPet = pet.Id,
                            nomePet = pet.nomePet,
                            especie = pet.especie,
                            IdMicrochip = pet.IdMicrochip,
                            idade = pet.idade,
                            sexo = pet.sexo,
                            peso = pet.peso,
                            raca = raca.raca,
                            IdRaca = raca.Id,
                        });
                    }
                    else
                    {
                        await DisplayAlert($"Raça não encontrada para Pet ID: {pet.IdRaca}", "Alerta", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert($"Nenhum Pet encontrado para Tutor ID: {tutor.IdPet}", "Alerta", "Ok");
                }
            }

            PetsCollectionView.ItemsSource = petAndTutors;

            if (petAndTutors.Count == 0)
            {
                await DisplayAlert("Nenhum PetAndTutor encontrado", "Alerta", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Nenhum tutor encontrado", "Alerta", "Ok");
        }

        return petAndTutors;
    }

    protected async void executeRefreshCommand()
    {
        DisplayAlert($"Refreshing", "Refreshing", "Ok");
        await cadastros();
        IsRefreshing = false;
    }

    async void OnItemTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        frame.BackgroundColor = Color.FromArgb("#D3D3D3");
        await Task.Delay(100);
        frame.BackgroundColor = Colors.White;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private async void AddPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPet());
    }
}