using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6
        }

        public enum GroomFrequencies
        {
            EveryWeek = 0,
            EveryOtherWeek = 1,
            FirstWeekEachMonth = 2
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        public long UserId { get; set; }
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
