
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
        var doctorPage = new DoctorPage();
        var bindingContext = new DoctorInfoRepository((sender as ImageButton).AutomationId.ToString());
        doctorPage.BindingContext = bindingContext;
        App.Current.MainPage.Navigation.PushAsync(doctorPage);
    }
}

