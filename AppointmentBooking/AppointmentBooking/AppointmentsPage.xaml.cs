using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public partial class AppointmentsPage : ContentPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            this.BindingContext = AppShell.Appointments;
            var upcomingEvents = (this.BindingContext as AppointmentsInfo).Appointments.Where(x => (x as DoctorInfo).AppointmentTime > DateTime.Now).ToList();
            CheckAppointemnts(upcomingEvents);

            this.listView.ItemsSource = upcomingEvents;

        }

        private void CheckAppointemnts(List<DoctorInfo> upcomingEvents)
        {
            if (upcomingEvents.Count == 0)
            {
                this.noAppointment.IsVisible = true;
                this.listView.IsVisible = false;

            }
            else
            {
                this.noAppointment.IsVisible = false;
                this.listView.IsVisible = true;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var upcomingAppointmentBorder = this.FindByName("UpcomingBorder") as BoxView;
            var pastAppointmentBordeer = this.FindByName("PastBordeer") as BoxView;


            if (button != null && button.Text == "Upcoming appointments")
            {
                var upcomingEvents = (this.BindingContext as AppointmentsInfo).Appointments.Where(x => (x as DoctorInfo).AppointmentTime > DateTime.Now).ToList();
                if (upcomingAppointmentBorder != null)
                {
                    upcomingAppointmentBorder.Color = Color.FromArgb("#512BD4");
                }
                if (pastAppointmentBordeer != null)
                {
                    pastAppointmentBordeer.Color = Colors.Transparent;

                }
                CheckAppointemnts(upcomingEvents);
                this.listView.ItemsSource = upcomingEvents; 

            }
            else if (button != null && button.Text == "Past appointments")
            {
                var pastAppointments = (this.BindingContext as AppointmentsInfo).Appointments.Where(x => (x as DoctorInfo).AppointmentTime < DateTime.Now).ToList();

                if (pastAppointmentBordeer != null)
                {
                    pastAppointmentBordeer.Color = Color.FromArgb("#512BD4");
                }
                if (upcomingAppointmentBorder != null)
                {
                    upcomingAppointmentBorder.Color = Colors.Transparent;

                }
                CheckAppointemnts(pastAppointments);
                this.listView.ItemsSource = pastAppointments;


            }

        }
    }

    public class AppointmentsInfo
    {
        public ObservableCollection<DoctorInfo> Appointments { get; set; }

        public AppointmentsInfo()
        {
            AddPastAppointments();
        }

        internal void AddPastAppointments()
        {
            Appointments = new ObservableCollection<DoctorInfo>();
            Appointments.Add(new DoctorInfo() { Name = "Dr. Peter", Details = "Dentist", AppointmentTime = DateTime.Now.Date.AddDays(-1).AddHours(9),Image="profile.png"});
            Appointments.Add(new DoctorInfo() { Name = "Dr. John", Details = "Dentist", AppointmentTime = DateTime.Now.Date.AddDays(-8).AddHours(11), Image = "profile.png" });
        }
    }
}