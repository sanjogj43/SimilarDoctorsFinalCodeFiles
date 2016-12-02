using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarDoctors
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public string AreaCode { get; set; }

        public string Organisation { get; set; }

        public double ReviewScore { get; set; }

        public int NumberOfReviews { get; set; }

        public string Degree { get; set; }

        //  FOR UNIT TESTING : Following line populates the mock data for for unit testing
        public static List<DoctorViewModel> ListOfDoctors = MockData.GetInstance().ListOfDoctors;

        public Dictionary<int, int> SimilarityWeights;

        public DoctorViewModel()
        {
            SimilarityWeights = new Dictionary<int, int>();
        }

        /// <summary>
        /// Display doctor details
        /// </summary>
        /// <param name="pSimilarityWeight">Similarity weight which needs to be displayed</param>
        /// <param name="pIsSelectedDoctor">Indicates if the current doctor is the selected doctor or not</param>
        public void Display(int pSimilarityWeight = 0, bool pIsSelectedDoctor = true)
        {
            Console.WriteLine("Id                       :       {0}", this.Id);
            Console.WriteLine("Name                     :       {0}", this.Name);
            Console.WriteLine("Speciality               :       {0}", this.Speciality);
            Console.WriteLine("Organization             :       {0}", this.Organisation);
            Console.WriteLine("Degree                   :       {0}", this.Degree);
            Console.WriteLine("Area Code                :       {0}", this.AreaCode);
            Console.WriteLine("Review Score             :       {0}", this.ReviewScore);
            if (!pIsSelectedDoctor)
            {
                Console.WriteLine("Similarity Weight        :       {0}", pSimilarityWeight);
            }
            Console.WriteLine("------------ --------------------- --------------");
        }

        /// <summary>
        /// Compute similarity weights of all the doctors with respect to the properties of selected doctor.
        /// </summary>
        public void ComputeSimilarityWeights()
        {
            foreach (var doc in ListOfDoctors)
            {
                if(doc.Id == this.Id)
                {
                    continue;
                }
                int currentWeight = 0;
                if (doc.Speciality == this.Speciality)
                {
                    currentWeight += Convert.ToInt32(PropertyWeights.Speciality);
                }
                if (doc.Organisation == this.Organisation)
                {
                    currentWeight += Convert.ToInt32(PropertyWeights.Organisation);
                }
                if (doc.Degree == this.Degree)
                {
                    currentWeight += Convert.ToInt32(PropertyWeights.Degree);
                }
                if (doc.AreaCode == this.AreaCode)
                {
                    currentWeight += Convert.ToInt32(PropertyWeights.AreaCode);
                }
                if (doc.ReviewScore == this.ReviewScore)
                {
                    currentWeight += Convert.ToInt32(PropertyWeights.ReviewScore);
                }
                
                this.SimilarityWeights.Add(doc.Id, currentWeight);
            }
        }

        /// <summary>
        /// Sort the smilarity weights dictionary in desc order with respect to the similarity weights.
        /// And filter top 5 similar doctors
        /// </summary>
        public void SortAndFilterSimilarityWeights()
        {
            // Sort dictionary SW in descending order with respect to assinged SW value. 
            this.SimilarityWeights = this.SimilarityWeights.OrderByDescending(x => x.Value).Take(5).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Display the output.
        /// </summary>
        public void DisplayOutput()
        {
            Console.WriteLine("------------- SELECTED DOCTOR --------------");
            this.Display();

            Console.WriteLine("------------- SIMILAR DOCTORS --------------");
            foreach (var item in this.SimilarityWeights)
            {
                var currDoc = ListOfDoctors.FirstOrDefault(x => x.Id == item.Key);
                currDoc.Display(item.Value, false);
            }
        }
    }
}
