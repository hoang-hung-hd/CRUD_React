using System.ComponentModel.DataAnnotations;

namespace ReactNet.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Name is required..")]
        public string EmployeeName { get; set; }

        

        [Required(ErrorMessage = "Department is required..")]
        public string Department { set; get; }

        [Required(ErrorMessage = "Gender is required..")]
        public string Gender { set; get; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
