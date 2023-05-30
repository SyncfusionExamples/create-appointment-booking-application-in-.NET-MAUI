using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class DoctorInfoRepository
    {
        public ObservableCollection<DoctorInfo> DoctorInfo { get; set; }

        public DateTime MinimumDate { get; set; } = DateTime.Now.Date;

        public DateTime MaximumDate { get; set; } = DateTime.Now.Date.AddDays(7);

        public DateTime SelectedDate { get; set; } = DateTime.Now.Date;

        public DoctorInfoRepository(string specialist)
        {
            string department = "";
            switch (specialist)
            {
                case "General":
                    department = "Physician";
                    break;
                case "skin":
                    department = "Skin Specialist";
                    break;
                case "cardiology":
                    department = "Cardiology";
                    break;
                case "neurology":
                    department = "Neurology";
                    break;
                case "pediatrician":
                    department = "Pediatrician";
                    break;
                case "eye":
                    department = "Eye Specialist";
                    break;
                case "dermatologist":
                    department = "Dermatologist";
                    break;
                case "psychiatrist":
                    department = "Psychiatrist";
                    break;
                case "gynecologist":
                    department = "Gynecologist";
                    break;
            }

            GenerateBookInfo(department);
        }

        private void GenerateBookInfo(string department)
        {
            DoctorInfo = new ObservableCollection<DoctorInfo>();
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Jennifer", Department = department, Details = "MBBS \n5 years experience" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Peter", Department = department, Details = "MBBS MD \n5 years experience" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. John", Department = department, Details = "MBBS \n10 years experience" });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Marilyn", Department = department, Details = "MBBS MD \n10 years experience", });
            DoctorInfo.Add(new DoctorInfo() { Name = "Dr. Daniel", Department = department, Details = "MBBS \n10 years experience" });

            for (int i = 0; i < 5; i++)
            {
                DoctorInfo[i].Image = "profile" + (i + 1).ToString() + ".png";
            }

        }
    }
}
