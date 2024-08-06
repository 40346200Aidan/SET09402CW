using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System;
using Haulage.AdminPages;
namespace Haulage;

public partial class ManageVehiclesPage : ContentPage
{

    public ManageVehiclesPage()
    {
        InitializeComponent();
        AddVehicle.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddVehiclePage()); };
    }

    private void RemoveVehicle_Clicked(object sender, EventArgs e)
    {
        if (entryId.Text != null) 
        {
            var vehicleId = entryId.Text.Trim();

            if (Int32.TryParse(vehicleId, out var parsedID))
            {
                VehicleExecutionService.DeleteVehicle(parsedID);
                Console.WriteLine("Vehicle Removed Successfully");
                DisplayAlert("Success", $"{vehicleId} removed successfully.", "OK");
            }
            else
            {
                Console.WriteLine("Unable to parse value");
                DisplayAlert("Error", $"Failed to delete {vehicleId}", "OK");
            }
        }
    }
}