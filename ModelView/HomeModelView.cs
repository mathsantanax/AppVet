using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppVet.Models;
using AppVet.Views;

namespace AppVet.ModelView
{
    public class HomeModelView : INotifyPropertyChanged
    {
        const int RefreshDuration = 2;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        ServicoModel servicoModel = new ServicoModel();

        public ObservableCollection<PetAndTutor> petAndTutors { get; private set; }

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        public ICommand ItemSelectedCommand { get; }
        public HomeModelView()
        {
            petAndTutors = new ObservableCollection<PetAndTutor>();
            GetRegister();
            ItemSelectedCommand = new Command<PetAndTutor>(OnItemSelected);
        }
        private async void OnItemSelected(PetAndTutor selectedPet)
        {
            if (selectedPet != null)
            {
                Debug.WriteLine($"Item selecionado: {selectedPet.nomePet}");
                await Application.Current.MainPage.Navigation.PushAsync(new NewService(selectedPet));
            }
        }

        async void GetRegister()
        {
            try// tratamento de excecões
            {
                petAndTutors.Clear();
                var getTutor = await servicoModel.ListarTutor(); // Pega os tutores no banco de dados e atribui na variavel
                if (getTutor != null && getTutor.Any()) // testa para saber se está nullo
                {
                    foreach(var t in getTutor) // loop para verificar o itens de gettutor
                    {
                        var getPet = await servicoModel.SelectPet(t.IdPet); // seleciona o pet com base na foreingn key no tutor
                        if (getPet != null) // testa para saber se esta nullo
                        {
                            var getRaca = await servicoModel.SelectRaca(getPet.IdRaca); // seleciona a raca com base na foreingn key do pet
                            if(getRaca != null)
                            {
                                // Adiciona o dados a uma lista de pet e tutor
                                petAndTutors.Add(new PetAndTutor{
                                   
                                    Id = t.Id,
                                    tutor = t.tutor,
                                    tel = t.tel,
                                    IdPet = getPet.Id,
                                    nomePet = getPet.nomePet,
                                    especie = getPet.especie,
                                    IdMicrochip = getPet.IdMicrochip,
                                    idade = getPet.idade,
                                    sexo = getPet.sexo,
                                    peso = getPet.peso,
                                    raca = getRaca.raca,
                                    IdRaca = getRaca.Id,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            GetRegister();
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
