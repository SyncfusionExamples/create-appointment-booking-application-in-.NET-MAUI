namespace AppointmentBooking;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
    }


    private void Shell_Loaded(object sender, EventArgs e)
    {
       if(App.IsAppointments)
        {
           // Shell.Current.GoToAsync("appointments");
            App.IsAppointments = false;

        }
    }
}
