using AppVet.DTO;
using System.ComponentModel;
using AppVet.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using AppVet.ModelView;

namespace AppVet.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        BindingContext = this;
        RefreshCommand = new Command(async () => await GetCadastros());
        ItemSelectedCommand = new Command<PetAndTutor>(OnItemSelected);
        GetCadastros();
    }

    Models.ServicoModel ServicoModel = new ServicoModel();

    public ICommand RefreshCommand { get; }
    public ICommand ItemSelectedCommand { get; }

    //Cria uma lista de pet e tutor
    public List<PetAndTutor> getCadastros = new List<PetAndTutor>();

    private bool IsRefreshing;
    private async void OnItemSelected(PetAndTutor selectedPet)
    {
        await Navigation.PushAsync(new NewService(selectedPet));
    }
    //protected async void executeRefreshCommand()
    //{
    //    await DisplayAlert($"Refreshing", "Refreshing", "Ok");
    //    await cadastros();
    //    IsRefreshing = false;
    //}

    private async Task GetCadastros()
    {
        //pega os tutores no banco de dados
        var getTutor = await ServicoModel.ListarTutor();

        try
        {
        await DisplayAlert("Alert", $"{IsRefreshing}", "OK");
            //verifica se está nullo o getTutor
            if (getTutor != null && getTutor.Any())
            {
                //colocar a lista dentro de um variavel para ter acesso aos conteudos
                foreach(var t in getTutor)
                {
                    // Pega o Pet no banco de dados referente ao id dele no tutor
                    var pet = await ServicoModel.SelectPet(t.IdPet);
                    // Verifica se pet está nullo
                    if(pet != null)
                    {
                        // pega a raca do pet no banco de dados referente a id da raca no pet
                        var racaPet = await ServicoModel.SelectRaca(pet.IdRaca);

                        // Verifica se raca está nullo
                        if(racaPet != null)
                        {
                            // Adiciona o dados a uma lista de pet e tutor
                            getCadastros.Add(new PetAndTutor
                            {
                                Id = t.Id,
                                tutor = t.tutor,
                                tel = t.tel,
                                IdPet = pet.Id,
                                nomePet = pet.nomePet,
                                especie = pet.especie,
                                IdMicrochip = pet.IdMicrochip,
                                idade = pet.idade,
                                sexo = pet.sexo,
                                peso = pet.peso,
                                raca = racaPet.raca,
                                IdRaca = racaPet.Id,
                            });
                        }
                    }
                }
                IsRefreshing = true; // define o refresh como true
                await DisplayAlert("Alert", $"{IsRefreshing}", "OK");
                PetsCollectionView.ItemsSource = getCadastros; //adciona os dados no itemsource
            }
        }
        catch (Exception ex)
        {
            // retorna o erro em mensagem
            await DisplayAlert("Alert",$"{ex.Message}","OK");
            await DisplayAlert("Alert", $"{IsRefreshing}", "OK");
            IsRefreshing = false; // define o refresh como false
        }
        finally
        {
            IsRefreshing = false;// define o refresh como false
            await DisplayAlert("Alert", $"{IsRefreshing}", "OK");
        }
    }

    //protected async Task<List<PetAndTutor>> cadastros()
    //{
    //    var petAndTutors = new List<PetAndTutor>();
    //    var tutors = await ServicoModel.ListarTutor();

    //    if (tutors != null && tutors.Any())
    //    {
    //        foreach (var tutor in tutors)
    //        {
    //            var pet = await ServicoModel.SelectPet(tutor.IdPet);
    //            await DisplayAlert("Alert", $"{tutor.IdPet}\n{tutor.tutor}", "Ok");
    //            if (pet != null)
    //            {
    //                var raca = await ServicoModel.SelectRaca(pet.IdRaca);
    //                if (raca != null)
    //                {
    //                    petAndTutors.Add(new PetAndTutor
    //                    {
    //                        Id = tutor.Id,
    //                        tutor = tutor.tutor,
    //                        tel = tutor.tel,
    //                        IdPet = pet.Id,
    //                        nomePet = pet.nomePet,
    //                        especie = pet.especie,
    //                        IdMicrochip = pet.IdMicrochip,
    //                        idade = pet.idade,
    //                        sexo = pet.sexo,
    //                        peso = pet.peso,
    //                        raca = raca.raca,
    //                        IdRaca = raca.Id,
    //                    });
    //                }
    //                else
    //                {
    //                    await DisplayAlert($"Raça não encontrada para Pet ID: {pet.IdRaca}", "Alerta", "Ok");
    //                }
    //            }
    //            else
    //            {
    //                await DisplayAlert($"Nenhum Pet encontrado para Tutor ID: {tutor.IdPet}", "Alerta", "Ok");
    //            }
    //        }

    //        PetsCollectionView.ItemsSource = petAndTutors;

    //        if (petAndTutors.Count == 0)
    //        {
    //            await DisplayAlert("Nenhum PetAndTutor encontrado", "Alerta", "Ok");
    //        }
    //    }
    //    else
    //    {
    //        await DisplayAlert("Nenhum tutor encontrado", "Alerta", "Ok");
    //    }

    //    return petAndTutors;
    //}


    async void OnItemTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        frame.BackgroundColor = Color.FromArgb("#D3D3D3");
        await Task.Delay(100);
        frame.BackgroundColor = Colors.White;
    }

    private async void AddPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPet());
    }
}