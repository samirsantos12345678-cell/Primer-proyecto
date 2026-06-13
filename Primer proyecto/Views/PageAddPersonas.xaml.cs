using Primer_proyecto.Controllers;
using Primer_proyecto.Models;

namespace Primer_proyecto.Views;

public partial class PageAddPersonas : ContentPage
{
    private Personas _personaEditar;

    public PageAddPersonas(Personas persona = null)
    {
        InitializeComponent();
        if (persona != null)
        {
            _personaEditar = persona;
            Nombre.Text = persona.Nombre;
            Apellido.Text = persona.Apellido;
            FechaNac.Date = persona.FechaNac;
            Correo.Text = persona.Correo;
            Telefono.Text = persona.Telefono;
            btnguardar.Text = "Actualizar";
        }
        else
        {
            btnguardar.Text = "Guardar";
        }
    }

    private async void btnguardar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrWhiteSpace(Apellido.Text))
        {
            await DisplayAlert("Error", "Nombre y Apellido son obligatorios", "OK");
            return;
        }

        Personas person = new Personas
        {
            Nombre = Nombre.Text,
            Apellido = Apellido.Text,
            FechaNac = (DateTime)FechaNac.Date,
            Correo = Correo.Text,
            Telefono = Telefono.Text
        };

        PersonasController controller = new PersonasController();

        if (_personaEditar != null)
        {
            person.Id = _personaEditar.Id;
            await controller.ActualizarPersona(person);
            await DisplayAlert("Información", "Registro Actualizado", "OK");
        }
        else
        {
            await controller.GuardarPerson(person);
            await DisplayAlert("Información", "Registro Guardado", "OK");
        }

      
        Nombre.Text = Apellido.Text = Correo.Text = Telefono.Text = string.Empty;
        FechaNac.Date = DateTime.Now;
    }
}