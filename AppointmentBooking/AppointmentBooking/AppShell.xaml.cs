namespace AppointmentBooking;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Appointments = new AppointmentsInfo();
        IsAppointments = false;
    }

    public static AppointmentsInfo Appointments { get; set; }

    public static bool IsAppointments { get; set; }

    private void Shell_Loaded(object sender, EventArgs e)
    {
       if(Shell.Current != null)
        {
            Shell.Current.GoToAsync("appointments");
        }
    }
}
