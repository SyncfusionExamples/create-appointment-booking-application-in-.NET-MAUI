
namespace AppointmentBooking;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage();
        App.Current.MainPage.Navigation.PushAsync(new DoctorPage());
    }
}

