using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarDoctors
{
    // Define a singleton class for List of Doctors. This way the list could not be altered from outside and
    // we can have just one instance of this class.
    public class MockData
    {
        // private static object of itself
        private static MockData ListClassObj;
        
        public List<DoctorViewModel> ListOfDoctors { get; set; }
        
        public static MockData GetInstance()
        {
            if (ListClassObj == null)
            {
                ListClassObj = new MockData();
                return ListClassObj;
            }
            else
            {
                return ListClassObj;
            }
        }

        // Private constructor
        private MockData()
        {
            ListOfDoctors = new List<DoctorViewModel>
            {
                new DoctorViewModel{ Id = 1,Name = "Mark Smith",Speciality="Pediatrics",AreaCode="90034",Organisation="Pacific Alliance",ReviewScore=4.5,NumberOfReviews=18,Degree="MD"},
                new DoctorViewModel{ Id = 2,Name = "John Cooper",Speciality="Internal",AreaCode="90030",Organisation="Pacific Alliance",ReviewScore=3.5,NumberOfReviews=50,Degree="DO"},
                new DoctorViewModel{ Id = 3,Name = "Jill Anderson",Speciality="Pediatrics",AreaCode="90029",Organisation="White Memorial",ReviewScore=5,NumberOfReviews=20,Degree="MD"},
                new DoctorViewModel{ Id = 4,Name = "Phil Triu",Speciality="Internal",AreaCode="90013",Organisation="White Memorial",ReviewScore=2.9,NumberOfReviews=15,Degree="MD"},
                new DoctorViewModel{ Id = 5,Name = "Rakesh Mehta",Speciality="Pediatrics",AreaCode="90034",Organisation="Pacific Alliance",ReviewScore=4,NumberOfReviews=32,Degree="DO"},
                new DoctorViewModel{ Id = 6,Name = "Jim Summers",Speciality="Pediatrics",AreaCode="90034",Organisation="Silver Lake",ReviewScore=3.2,NumberOfReviews=22,Degree="MD"}
            };
        }

        // Display list of doctors to the user
        public static void DisplayListOfdoctors()
        {
            Console.WriteLine("Please select the id from following list of Doctors:");
            Console.WriteLine("    1 : Mark Smith\n    2 : John Cooper\n    3 : Jill Anderson\n    4 : Phil Triu\n    5 : Rakesh Mehta");
            Console.WriteLine("    6 : Jim Summers\n");
        }

        public static void DisplayListOfAllDoctorsData()
        { 
            
        }
    }
}
