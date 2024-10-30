using AppVet.DTO;
using AppVet.Interface;
using AppVet.Models;

namespace AppVet.Views;

public partial class NewPet : ContentPage
{

    public NewPet()
    {
        InitializeComponent();
        OnListRaca();
    }
    Models.ServicoModel service = new ServicoModel();

    private async void OnAddRacaClicked(object sender, EventArgs e)
    {
        Raca raca = new Raca();
        string novaRaca = await DisplayPromptAsync("Adicionar Raça", "Digite o nome da nova raça:");
        if (!string.IsNullOrEmpty(novaRaca))
        {
            raca.raca = novaRaca.ToUpper();
            service.CadastrarRaca(raca);
            await DisplayAlert($"Raça Cadastrada Com sucesso \n{raca.raca}", "Alerta", "Ok");
            OnListRaca();
        }
    }

    private async void OnListRaca()
    {
        racaPicker.ItemsSource = null;
        racaPicker.Items.Clear();
        var racas = await service.ListarRaca();
        racaPicker.ItemsSource = racas.Select(r => r.raca).ToList();
    }

    private bool ValidarCampos()
    {
        var campos = new List<object>
        {
        EntryTutor.Text,
        EntryCel.Text,
        EntryNomePet.Text,
        sexagemPicker.SelectedItem,
        especiePicker.SelectedItem,
        racaPicker.SelectedItem
        };

        bool todosPreenchidos = campos.All(campo => !string.IsNullOrWhiteSpace(campo?.ToString()));

        if (!todosPreenchidos)
        {
            DisplayAlert("Erro", "Todos os campos devem ser preenchidos.", "OK");
            return false;
        }

        return true;
    }


    private async void OnAddPetAndTutor(object sender, EventArgs e)
    {
        Pet pet = new Pet
        {
            nomePet = EntryNomePet.Text.ToUpper(),
            IdMicrochip = EntryMicrochip.Text,
            especie = especiePicker.SelectedItem?.ToString().ToUpper(),
            idade = int.Parse(EntryIdadePet.Text),
            sexo = sexagemPicker.SelectedItem.ToString().ToUpper(),
            peso = float.Parse(entryPeso.Text),
            IdRaca = racaPicker.SelectedIndex + 1,
        };


        if(pet != null)
        {
            service.CadastrarPet(pet);
            await DisplayAlert("Alert", $"{pet.nomePet}", "Ok");


            var retornoPet = await service.SelectedPet(pet);
            await DisplayAlert("Alert", $"{retornoPet.Id}", "Ok");

            if(retornoPet != null)
            {
                Tutor tutor = new Tutor
                {
                    IdPet = retornoPet.Id,
                    tutor = EntryTutor.Text.ToUpper(),
                    tel = decimal.Parse(EntryCel.Text),
                };
                service.CadastrarTutor(tutor);
                await DisplayAlert("Cadastro Criado com Sucesso", "Alerta", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alguma coisa esta nula no retorno do pet", "Alerta", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Alguma coisa esta nula", "Alerta", "Ok");
        }


    }
}