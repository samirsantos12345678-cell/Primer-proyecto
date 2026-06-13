namespace Primer_proyecto;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce("¡Botón presionado!");
    }
}