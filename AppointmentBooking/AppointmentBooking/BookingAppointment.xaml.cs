using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using Color = Microsoft.Maui.Graphics.Color;

namespace AppointmentBooking
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class BookingAppointment : ContentPage
    {
        /// <summary>
        /// The time slot string is used to handle while book an appointment. While select the time slot then time slot variable value will be updates with respective tapped time slot.
        /// It is used to reset the time slot.
        /// </summary>
        private string timeSlot = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Year" /> class.
        /// </summary>
        public BookingAppointment()
        {
            InitializeComponent();
            this.border.Stroke = Color.FromArgb("#E6E6E6");
            this.InitializeCalendar(this.appointmentBooking);
        }

        /// <summary>
        /// Initialize the calendar.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="parent">Parent view of calendar control.</param>
        private void InitializeCalendar(Syncfusion.Maui.Calendar.SfCalendar calendar)
        {
            calendar.MinimumDate = DateTime.Now.Date.AddDays(-1);
            calendar.MaximumDate = DateTime.Now.Date.AddDays(7);
            calendar.SelectedDate = DateTime.Now.Date;
        }

        /// <summary>
        /// Method to update the selected date changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">Event arguments.</param>
        private void AppointmentBooking_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
            this.UpdateDateSelection(this.appointmentBooking, this.label, this.flexLayout);
            this.timeSlot = string.Empty;
        }

        /// <summary>
        /// Update the UI based on calendar selected date.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="textLabel">Selected date text label.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private void UpdateDateSelection(Syncfusion.Maui.Calendar.SfCalendar calendar, Label textLabel, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                return;
            }

            DateTime dateTime = calendar.SelectedDate.Value;
            string dayText = dateTime.ToString("MMMM" + " " + dateTime.Day.ToString() + ", " + dateTime.ToString("yyyy"), CultureInfo.CurrentUICulture);
            textLabel.Text = dayText;
            //// The time slot is empty then no need to reset the time slot.
            if (this.timeSlot == string.Empty)
            {
                return;
            }

            foreach (Button child in buttonLayout.Children)
            {
                Button button = (Button)child;
                button.TextColor = Colors.Black;
                button.Background = Colors.White;
            }
        }

        /// <summary>
        /// Method to Book an Appointment based on the selected date and selected time slot.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">Event arguments.</param>
        private void AppointmentBooking(object sender, EventArgs e)
        {
            this.BookAppointment(this.appointmentBooking, this.flexLayout);
        }

        /// <summary>
        /// Book the appointment on selected date and time slot.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private async void BookAppointment(Syncfusion.Maui.Calendar.SfCalendar calendar, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a date to book an appointment ", "Ok");
                return;
            }

            if (this.timeSlot == string.Empty)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a time to book an appointment ", "Ok");
                return;
            }

            DateTime dateTime = calendar.SelectedDate.Value;
            string dayText = dateTime.ToString("MMMM" + " " + dateTime.Day.ToString() + ", " + dateTime.ToString("yyyy"), CultureInfo.CurrentUICulture);
            string text = "Appointment booked for " + dayText + " " + timeSlot;
            popup.Message = text;
            popup.Show();

            await Task.Delay(2000);
            popup.IsOpen = false;

            var appointmentList = new AppointmentsInfo();
            var doctorInfo = this.BindingContext as DoctorInfo;
            doctorInfo.AppointmentTime = dateTime;
            AppShell.Appointments.Appointments.Add(doctorInfo);
            AppShell.IsAppointments = true;
            App.Current.MainPage = new NavigationPage();
            var appShell = new AppShell();
            App.Current.MainPage.Navigation.PushAsync(appShell);
            AppShell.IsAppointments = false;
            //await Task.Delay(1000);

            

           // await Shell.Current.GoToAsync("//appointments");
        }

        /// <summary>
        /// Method to update the slot booking.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">Event arguments.</param>
        private void SlotBooking_Changed(object sender, EventArgs e)
        {
            this.UpdateTimeSlotSelection(this.appointmentBooking, (Button)sender, this.flexLayout);
        }

        /// <summary>
        /// Update the UI based on selected time slot.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="selectedButton">Selected time slot button.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private void UpdateTimeSlotSelection(Syncfusion.Maui.Calendar.SfCalendar calendar, Button selectedButton, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a date to book an appointment ", "Ok");
                return;
            }

            foreach (Button child in buttonLayout.Children)
            {
                Button unPressedbutton = (Button)child;
                if (unPressedbutton == selectedButton)
                {
                    selectedButton.TextColor = Colors.White;
                    selectedButton.Background = Color.FromArgb("#6200EE");
                    timeSlot = selectedButton.Text;
                    continue;
                }

                unPressedbutton.TextColor = Colors.Black;
                unPressedbutton.Background = Colors.White;
            }
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
             //Shell.Current.GoToAsync("appointments");
        }
    }
}