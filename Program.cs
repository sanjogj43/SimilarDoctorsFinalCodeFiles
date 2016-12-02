using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarDoctors
{
    //A site contains a listing of doctors. Users can browse for doctors given a 
    //specific specialty, area, review score etc. You need to help write the logic 
    //for returning similar doctors.  Specifically, write a class(es) which when 
    //given a doctor, provides a list of similar doctors, in a prioritized order. 
    //You define what similar means and the result ordering but clearly document any 
    //assumptions in your code.  Please include unit tests. You can assume the entire 
    //directory of doctors fits into memory.  Write in whatever language you're most 
    //comfortable with. 


    class Program
    {
        static void Main(string[] args)
        {
            // FOR UNIT TESTING : Following line populates the mock data for for unit testing
            MockData listObj = MockData.GetInstance();
            List<DoctorViewModel> ListOfDoctors = listObj.ListOfDoctors;

            // Display the list of available doctors 
            
            while (true)
            {
                Console.Clear();
                MockData.DisplayListOfdoctors();

                // Accept input doctor id for which similar doctors are to be searched
                Console.Write("Please select User Id:");
                int selectedDoctorId = Convert.ToInt32(Console.ReadLine());

                // Check if the selected doctor exists
                var selectedDoctor = ListOfDoctors.FirstOrDefault(x => x.Id == selectedDoctorId);
                ListOfDoctors = ListOfDoctors.Where(x => x.Id != selectedDoctorId).ToList();

                // If exists proceed
                if (selectedDoctor != null)
                {
                    // Compute the Similarity weights for all the doctors with respect to the selected doctor
                    selectedDoctor.ComputeSimilarityWeights();

                    // Sort the Similarity weights dictionary in descending order with respect to computed similarity 
                    // weights and get top 5 entries from them
                    selectedDoctor.SortAndFilterSimilarityWeights();

                    // Display the output.
                    selectedDoctor.DisplayOutput();
                }
                else
                {
                    Console.WriteLine("Please select valid entry");
                }
                Console.WriteLine("Press 'q' to quit. Press 'c' to continue.");
                char c = Convert.ToChar(Console.ReadLine());
                if (c == 'q')
                    break;
            }

        }
    }
}
