using System.ComponentModel.DataAnnotations;

namespace ReactNet.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        public List<Employee> Employees { get; set; }
        
    }
}
