using AppContactos.Models;

namespace AppContactos;

public partial class ContactoPage : ContentPage
{
    public ContactoPage()
    {
        InitializeComponent(); // Este sí debe estar
    }

    async void OnGuardarClicked(object sender, EventArgs e)
    {
        string? tipoId = identificacionPicker.SelectedItem?.ToString();
        string id = identificacionEntry.Text;
        string nombres = nombresEntry.Text;
        string apellidos = apellidosEntry.Text;
        DateTime fecha = fechaPicker.Date;
        string correo = correoEntry.Text;
        string salarioTexto = salarioEntry.Text;

        if (string.IsNullOrWhiteSpace(tipoId) || string.IsNullOrWhiteSpace(id) ||
            string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
            string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(salarioTexto))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        if ((tipoId == "CI" && id.Length != 10) || (tipoId == "RUC" && id.Length != 13))
        {
            await DisplayAlert("Error", "Número de identificación inválido", "OK");
            return;
        }

        if (!double.TryParse(salarioTexto, out double salario))
        {
            await DisplayAlert("Error", "Salario inválido", "OK");
            return;
        }

        var contacto = new Contacto
        {
            TipoIdentificacion = tipoId,
            Identificacion = id,
            Nombres = nombres,
            Apellidos = apellidos,
            FechaNacimiento = fecha,
            Correo = correo,
            Salario = salario
        };

        await Navigation.PushAsync(new ResumenPage(contacto));
    }
}
