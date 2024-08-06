using System.Collections.ObjectModel;
using System;
using Haulage.BaseClasses.BillingHandler;
using SQLite;
using Haulage.DatabaseExecutionServices;
namespace Haulage.CustomerPages;
public partial class ManageBillingPage : ContentPage
{
	public ManageBillingPage()
	{
		InitializeComponent();
    }

    private void AddBills_Clicked(object sender, EventArgs e)
    {
        AddBills.Clicked += async (sender, args) => { await Navigation.PushAsync(new AddBillPage()); };
    }

    private void DeleteBill_Clicked(object sender, EventArgs e)
    {
        var sql = $"DELETE FROM Bill WHERE BillID = {EntryBillId.Text}";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        if(EntryBillId.Text != null)
        {
            var billId = EntryBillId.Text.Trim();

            if (Int32.TryParse(billId, out var parsedID))
            {
                DisplayAlert("Success", "Bill details removed successfully.", "OK");
                Console.WriteLine("Bill successfully removed");
            }
            else
            {
                Console.WriteLine("Unable to parse value");
                DisplayAlert("Error", $"Failed to delete {EntryBillId}", "OK");
            }
        }
    }
}