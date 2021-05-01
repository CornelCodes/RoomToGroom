using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Customers")]
    public class Customer
    {
        public enum GroomDays
        {
            Monday, Tuesday, Wednesday,
            Thursday, Friday, Saturday,
            Sunday
        }

        public enum GroomFrequencies
        {
            EveryWeek, EveryOtherWeek, FirstWeekEachMonth
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerID { get; set; }
        public long GroomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CustomerSince { get; set; }
        public GroomDays GroomDay { get; set; }
        public GroomFrequencies GroomFrequency{ get; set; }
        public List<Pet> Pets{ get; set; }

    }
}
