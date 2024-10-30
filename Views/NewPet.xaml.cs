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


    private void OnAddPetAndTutor(object sender, EventArgs e)
    {

        Tutor tutor = new Tutor {
            tutor = EntryTutor.Text.ToUpper(),
            tel = decimal.Parse(EntryCel.Text),
            Pet = new Pet
            {
                nomePet = EntryNomePet.Text,
                IdMicrochip = EntryMicrochip.Text,
                especie = especiePicker.SelectedItem?.ToString(),
                idade = int.Parse(EntryIdadePet.Text),
                sexo = sexagemPicker.SelectedItem?.ToString(),
                peso = float.Parse(entryPeso.Text),
                raca = new Raca
                {
                    raca = racaPicker.SelectedItem.ToString(),
                },
            },
        };
        if(ValidarCampos())
        {
            service.CadastrarPetETutor(tutor);
            DisplayAlert("Cadastro Criado com Sucesso", "Alerta", "Ok");
        }
    }
}