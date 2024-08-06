using Haulage.BillviewModel;
using SQLite;
using System.Runtime.CompilerServices;
using Haulage.CustomerPages;
namespace Haulage;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();

        Button ManageBilling = FindByName("ManageBilling") as Button;
        ManageBilling.Clicked += async (sender, args) => { await Navigation.PushAsync(new ManageBillingPage()); };
    }

   private void ManageBilling_Clicked(object sender, EventArgs e)
    {


    }
    
       
    
}