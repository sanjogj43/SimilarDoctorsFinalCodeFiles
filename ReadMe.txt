Steps to follow to run the project:

1) Download the code files and import them in new project in Visual Studio 
2) Click the 'Run' Button to run the project.

Concept :

1) I have used the concept of 'Similarity weights' in this project. 
2) Every property of the Class 'Doctor' is assinged a weight (W), if the value of this property of the given (input) 
doctor object matches the same property of of any other 'Doctor' object in the list, then the 'Similarity weight' of 
this object with respect to the given object increases by W. 
3) Similarly other properties have different weights assigned. 
4) The 'Doctor' object in the given list which has the maximum 'similarity weight' with respect to the input 'Doctor' 
object, is most similar to the input object

Enhancements :

1) The method 'ComputeSimilarityWeights' in class 'DoctorViewModel' is the heart of this project. 
2) This method can be modified in anyway without effecting the other logic. 
3) It can be enhanced by including range for integer and float variables. Meaning, the 'similarity weight' would differ 
based on the range in which a particular property value is compared to the given input objects property value. 
4) Similarly, the string values can be compared to get the comparison count instead of doing exact string comparison. 
5) Given more time the above cases can be handled in 'ComputeSimilarityWeights' method.