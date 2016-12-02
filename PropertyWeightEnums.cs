using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarDoctors
{
    /// <summary>
    /// This enum represents the weights that are being assignedto the doctor properties.
    /// Based on these weights the similarity factor of a doctor with selected doctor is decided.
    /// The doctor with maximum similarity weight is the most similar doctor to the selected doctor.
    /// </summary>
    public enum PropertyWeights
    {
        None = 0,
        ReviewScore = 1,
        AreaCode = 2,
        Degree = 3,
        Organisation = 4,
        Speciality = 5
    }
}
