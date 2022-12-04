using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Numer Of Days")]
        [Required]
        [Range(1, 25, ErrorMessage = "Please Enter A Valid Number Of Days (1 - 25)")]
        public int DefaultDays { get; set; }
    }
}
