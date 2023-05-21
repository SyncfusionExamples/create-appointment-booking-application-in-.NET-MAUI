using Syncfusion.Maui.Calendar;
using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppointmentBooking
{
    public partial class DoctorPage : ContentPage
    {

        public DateTime SelectedDate { get; set; } = DateTime.Now.Date;

        public DoctorPage()
        {
            InitializeComponent();
            CalendarButton.Text = DateTime.Now.Date.ToString("yyyy'/'MM'/'dd");
            CheckDoctorAvailability();

        }

        private void CalendarButton_Clicked(object sender, EventArgs e)
        {
            popup.ShowRelativeToView(CalendarButton, PopupRelativePosition.AlignBottom);
        }

        private void calendar_ActionButtonClicked(object sender, Syncfusion.Maui.Calendar.CalendarSubmittedEventArgs e)
        {
            CheckDoctorAvailability();
            this.popup.IsOpen = false;
        }

        private void calendar_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            var calendar = sender as SfCalendar;
            if (e.NewValue == null)
            {
                this.CalendarButton.Text = ((DateTime)e.OldValue).ToString("yyyy'/'MM'/'dd");
            }
            else
            {
                this.CalendarButton.Text = ((DateTime)e.NewValue).ToString("yyyy'/'MM'/'dd");
                this.SelectedDate = (DateTime)calendar.SelectedDate;
            }
        }

        private void CheckDoctorAvailability()
        {
            if (this.SelectedDate == DateTime.Now.Date)
            {
                this.NoDoctors.IsVisible = true;
                this.listView.IsVisible = false;
            }
            else
            {
                this.NoDoctors.IsVisible = false;
                this.listView.IsVisible = true;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new BookingAppointment() { BindingContext = button.BindingContext });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new AppShell());
        }
    }
}