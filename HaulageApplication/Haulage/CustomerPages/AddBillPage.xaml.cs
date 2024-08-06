using Haulage.BaseClasses.BillingHandler;
using Haulage.DatabaseExecutionServices;
using SQLite;
using System.Runtime.CompilerServices;
namespace Haulage;

public partial class AddBillPage : ContentPage
{
	public AddBillPage()
	{
		InitializeComponent();

		Button SaveBill = FindByName("SaveBill") as Button;
		SaveBill.Clicked += SaveBill_Clicked;
	}

    private void SaveBill_Clicked(object sender, EventArgs e)
    {
		string customerBillId = BillIdEntry.Text;
		string customerFullname = FullnameEntry.Text;
		string customerEmail = EmailEntry.Text;
        string customerItem = ItemEntry.Text;
        string customerItemDesc = ItemDescEntry.Text;
        string customerItemCost = CostEntry.Text;
        string customerPaid = PaidEntry.Text;

		var sql = $"INSERT INTO Bill VALUES ({customerBillId}, '{customerFullname}', '{customerEmail}', '{customerItem}', '{customerItemDesc}', '{customerItemCost}', '{customerPaid}');";

        using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
        {
            var command = new SQLite.SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteQuery<DBNull>();
        }

        DisplayAlert("Success", "Bill details saved successfully.", "OK");
        Console.WriteLine("Bill successfully Added");

    }
}