using System.ComponentModel.DataAnnotations;

namespace ReactNet.Models
{
    public class EmployeeForm
    {
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "EmployeeCity is required..")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Department is required..")]
        public string Department { set; get; }

        [Required(ErrorMessage = "Gender is required..")]
        public string Gender { set; get; }
    }

    public class CityForm
    {
        [Required(ErrorMessage = "CityName is required..")]
        public string CityName { get; set; }
    }
}
