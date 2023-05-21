namespace AppointmentBooking;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Appointments = new AppointmentsInfo();

    }
    public static AppointmentsInfo Appointments { get; set; }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.Width = 700;
        window.Height = 600;

        return window;
    }
}
