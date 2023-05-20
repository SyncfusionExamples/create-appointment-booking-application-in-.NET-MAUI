namespace AppointmentBooking;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Appointments = new AppointmentsInfo();
        IsAppointments = false;

    }
    public static AppointmentsInfo Appointments { get; set; }
    public static bool IsAppointments { get; set; }


    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 700;
        const int newHeight = 600;

        window.Width = newWidth;
        window.Height = newHeight;
        return window;
    }
}
