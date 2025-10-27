using AppContactos.Models;
using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace AppContactos;

public partial class ResumenPage : ContentPage
{
    private Contacto contacto;

    public ResumenPage(Contacto contacto)
    {
        InitializeComponent();
        this.contacto = contacto;

        double aporteIESS = contacto.Salario * 0.0945;

        datosLabel.Text = $"ID: {contacto.TipoIdentificacion} - {contacto.Identificacion}\n" +
                          $"Nombre: {contacto.Nombres} {contacto.Apellidos}\n" +
                          $"Fecha de nacimiento: {contacto.FechaNacimiento:dd/MM/yyyy}\n" +
                          $"Correo: {contacto.Correo}\n" +
                          $"Salario: {contacto.Salario:C}\n" +
                          $"Aporte al IESS: {aporteIESS:C}";
    }

    private async void OnExportarClicked(object sender, EventArgs e)
    {
        string ruta = Path.Combine(FileSystem.AppDataDirectory, "contacto.txt");
        await File.WriteAllTextAsync(ruta, datosLabel.Text);
        await DisplayAlert("Exportado", $"Archivo guardado en:\n{ruta}", "OK");
    }
}
