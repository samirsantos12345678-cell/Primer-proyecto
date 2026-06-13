using Primer_proyecto.Controllers;
using Primer_proyecto.Models;

namespace Primer_proyecto.Views;

public partial class PageListPersonas : ContentPage
{
    private PersonasController _controller;

    public PageListPersonas()
    {
        InitializeComponent();
        _controller = new PersonasController();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarPersonas();
    }

    private async Task CargarPersonas()
    {
        var personas = await _controller.ObtenerPersonas();
        listaPersonas.ItemsSource = personas;
    }

    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.CommandParameter as Personas;
        if (persona != null)
        {
            await Navigation.PushAsync(new PageAddPersonas(persona));
        }
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.CommandParameter as Personas;
        if (persona != null)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {persona.NombreCompleto}?", "Sí", "No");
            if (confirm)
            {
                await _controller.EliminarPersona(persona);
                await CargarPersonas();
            }
        }
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageAddPersonas());
    }
}