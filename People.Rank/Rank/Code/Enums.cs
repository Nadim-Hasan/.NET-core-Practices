namespace Rank.Code
{

    /* Enum:
                 *An enumeration type (or enum type) is a value type defined by a set named constants 
                  of the underlying integral numeric type. To define an enumeration type. use the enum
                  key word and specify the names of enum memebers.


     In C# 

           enum Season{
                          spring,
                          summer,
                          winter,
                          Authmn,
                       }

           enum ErrorCode : ushort
               {
                   None = 0,
                   Unknown=1,
                   Connectionlost =100,
                   OutlierReading =200
                   }
      
     
     *     1.GetName() - Return The name of the Constant of the specified value of specified enum.
     *     2.GetNames()- Returns an array of string name of all the constant of specified enum.
     *     3.TryParse()-  Converts the strung representation of the name or numaric value of one 
           or more enumerated constands to an equivalent enumerated object.The return value indicateds wether 
           the conversion succeeded.
     */
    public class Enums
    {
        public enum Status {
            
           Default =0,
           Active =1,
           Disable=2,
           Delete=3
       
        }

        public enum TaskType :int
        {
            Good =1,
            Bad =2, 
        }

        //public enum Mark : int
        //{

        //    Study = 1,
        //    Religion = 2,
        //    Gym = 3,
            

        //}
        
    }
}
