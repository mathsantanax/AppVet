
using AppVet.DTO;
using System.ComponentModel.Design;
using System.Globalization;

namespace AppVet.Views;

public partial class NewService : ContentPage
{
	public NewService(Pet pet)
	{
		InitializeComponent();
		PetColletionView.ItemsSource = new object[] { pet };
    }


    DatePicker datePicker = new DatePicker
    {
        MinimumDate = new DateTime(2018, 1, 1),
        MaximumDate = new DateTime(2018, 12, 31),
        Date = new DateTime(2018, 6, 21)
    };
}