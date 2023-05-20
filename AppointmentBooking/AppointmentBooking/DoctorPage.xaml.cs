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
            CalendarButton.Text = DateTime.Now.Date.ToString("yyyy'-'MM'-'dd");
            CheckDoctorAvailability();

        }

        private void CalendarButton_Clicked(object sender, EventArgs e)
        {
            popup.ShowRelativeToView(CalendarButton, PopupRelativePosition.AlignBottom);
        }

        private void calendar_ActionButtonClicked(object sender, Syncfusion.Maui.Calendar.CalendarSubmittedEventArgs e)
        {
            this.popup.IsOpen = false;
        }

        private void calendar_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            var calendar = sender as SfCalendar;
            if (e.NewValue == null)
            {
                this.CalendarButton.Text = ((DateTime)e.OldValue).ToString("yyyy'-'MM'-'dd");
            }
            else
            {
                this.CalendarButton.Text = ((DateTime)e.NewValue).ToString("yyyy'-'MM'-'dd");
                this.SelectedDate = (DateTime)calendar.SelectedDate;
            }

            CheckDoctorAvailability();

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
    }

    public class DoctorInfo 
    {
        public string Name { get; set; }

        public string Details { get; set; }

        public string Image { get; set; }

        public DateTime AppointmentTime { get; set; }

    }

    public class DoctorInfoRepository
    {
        public ObservableCollection<DoctorInfo> DoctorInfo { get; set; }

        public DateTime MinimumDate { get; set; } = DateTime.Now.Date;

        public DateTime MaximumDate { get; set; } = DateTime.Now.Date.AddDays(7);

        public DoctorInfoRepository(string specialist)
        {
            
            GenerateBookInfo();
            if(specialist == "General")
            {
                GeneralPhysicianBookInfo();
            }

            if (specialist == "skin")
            {
            }

            if (specialist == "cardiology")
            {
            }

            if (specialist == "neurology")
            {
            }

            if (specialist == "pediatrician")
            {
            }

            if (specialist == "eye")
            {
            }

            if (specialist == "dermatologist")
            {
            }

            if (specialist == "psychiatrist")
            {
            }

            if (specialist == "gynecologist")
            {
            }


        }

        internal void GenerateBookInfo()
        {
            DoctorInfo = new ObservableCollection<DoctorInfo>();
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Peter", Details = "Dentist \nMBBS \n10 years experience",Image = "profile.png" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. John", Details = "Dentist \nMBBS \n10 years experience", Image = "profile.png" });
        }

        internal void GeneralPhysicianBookInfo()
        {
            DoctorInfo = new ObservableCollection<DoctorInfo>();
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Peter", Details = "General Physician \nMBBS \n10 years experience", Image = "profile.png" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. John", Details = "General Physician \nMBBS \n10 years experience", Image = "profile.png" });
        }
    }
}