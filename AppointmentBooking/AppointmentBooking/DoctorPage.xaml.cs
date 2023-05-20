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
        public DoctorPage()
        {
            InitializeComponent();
            CalendarButton.Text = DateTime.Now.Date.ToString("yyyy'-'MM'-'dd");
        }

        private void CalendarButton_Clicked(object sender, EventArgs e)
        {
            popup.ShowRelativeToView(CalendarButton, PopupRelativePosition.AlignBottom);
        }


        private void listView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new BookingAppointment() {  BindingContext = e.DataItem});
        }

      

        private void calendar_ActionButtonClicked(object sender, Syncfusion.Maui.Calendar.CalendarSubmittedEventArgs e)
        {
            this.popup.IsOpen = false;
        }

        private void calendar_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            var calendar = sender as SfCalendar;
            if(calendar.SelectedDate == null)
            {
                this.CalendarButton.Text = ((DateTime)e.OldValue).ToString("yyyy'-'MM'-'dd");
            }
            else
            {
                this.CalendarButton.Text = ((DateTime)e.NewValue).ToString("yyyy'-'MM'-'dd");
            }
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
        

        public DoctorInfoRepository()
        {
            GenerateBookInfo();
        }

        internal void GenerateBookInfo()
        {
            DoctorInfo = new ObservableCollection<DoctorInfo>();
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Peter", Details = "Dentist",Image = "profile.png" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. John", Details = "Dentist", Image = "profile.png" });
        }
    }
}