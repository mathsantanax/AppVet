using AppVet.DTO;
using System.ComponentModel;
using AppVet.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using AppVet.ModelView;
using System.Diagnostics;

namespace AppVet.Views;

public partial class Home : ContentPage
{
    public ICommand ItemSelectedCommand { get; }
    public Home()
    {
        InitializeComponent();
    }

    async void OnItemTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var originalColor = Colors.White;
        frame.BackgroundColor = Color.FromArgb("#D3D3D3");
        await Task.Delay(100);
        frame.BackgroundColor = originalColor;
    }

    private async void AddPet(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPet());
    }
}