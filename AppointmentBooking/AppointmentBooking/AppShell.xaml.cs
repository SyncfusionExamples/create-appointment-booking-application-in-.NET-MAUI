namespace AppointmentBooking;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Appointments = new AppointmentsInfo();

    }

    public static AppointmentsInfo Appointments { get; set; }


}
