using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RealEstates {
    namespace Models {
        [PrimaryKey(nameof(Id))]
        [Table("real_estates")]
        public class RealEstate : DbContext {
            public long Id { get; }
            public float Area { get; set; }
            public int Number { get; set; }
            public string Street { get; set; }

            public string City { get; set; }

            public RealEstate(string city, string street, float area, int number) {
                City = city;
                Street = street;
                Area = area;
                Number = number;
            }
        }
    }
}