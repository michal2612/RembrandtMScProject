using System;
using System.ComponentModel.DataAnnotations;
using Rembrandt.Contracts.Classes.Dataset;

namespace Rembrandt.Dataset.Core.Models
{
    public class Contributor
    {
        [Key]
        public int PrimaryKey { get; set; }

        public string Id { get; protected set; }

        public int? Age { get; protected set; }

        public int? Gender { get; protected set; }

        public bool? DutchNationality { get; protected set; }

        public int? Education { get; protected set; }

        public bool? VisitDaily { get; protected set; }

        public int? VisitFreq { get; protected set; }

        public bool? VisitAlone { get; protected set; }

        public int? VisitOtherParks { get; protected set; }

        public bool? MoreInvolved { get; protected set; }

        public int? NatureOriented { get; protected set; }
        
        public bool? WithChildren { get; protected set; }

        protected Contributor()
        {
            
        }

        public Contributor(string id, int? age, int? gender, bool? dutchNationality, int? education, bool? visitDaily, int? visitFrequency, bool? visitAlone, int? visitOtherParks, bool? moreInvoled, int? natureOriented, bool? withChildren)
        {
            Id = id;
            Age = SetAge(age);
            Gender = SetGender(gender);
            DutchNationality = dutchNationality;
            Education = SetEducation(education);
            VisitDaily = visitDaily;
            VisitFreq = SetVisitFrequency(visitFrequency);
            VisitAlone = visitAlone;
            VisitOtherParks = SetVisitOtherParks(visitOtherParks);
            MoreInvolved = moreInvoled;
            NatureOriented = SetNatureOriented(natureOriented);
            WithChildren = withChildren;
        }

        static int? SetAge(int? age)
            => CheckForEnum(typeof(Age), age);
        
        static int? SetGender(int? gender)
            => CheckForEnum(typeof(Gender), gender);

        static int? SetEducation(int? education)
            => CheckForEnum(typeof(Education), education);

        static int? SetNatureOriented(int? natureOriented)
            => CheckForEnum(typeof(NatureOriented), natureOriented);

        static int? SetVisitFrequency(int? visitFrequency)
            => CheckForEnum(typeof(VisitFrequency), visitFrequency);

        static int? SetVisitOtherParks(int? visitOtherParks)
            => CheckForEnum(typeof(VisitOtherParks), visitOtherParks);

        static int? CheckForEnum(Type enumType, int? value)
        {
            if(value == null)
                return (int)Enum.Parse(enumType, "Undefined");

            bool exists = Enum.IsDefined(enumType, value);
            
            if(exists == false)
                throw new ArgumentException($"Can't find a definition for {enumType.Name} value!");

            return value;
        }
    }
}