using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Test1.ViewModel
{
    public class CustomerVM
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }
        public string SeoAlias { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Date of Birth")]
        [DataType(DataType.Date , ErrorMessage ="Wrong Date Format")]
        public DateTime DTB { get; set; }
        [EnumDataType(typeof(GenderEnum), ErrorMessage = "Wrong Gender type")]
        public GenderEnum Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the address")]
        public string Address { get; set; }
        public List<string> ListImage { get; set; }
        [Required(ErrorMessage = "Please choose profile image")]  
        [Display(Name = "Please enter Pictures")]  
        public List<IFormFile> ListFormImage { get; set; } 
        
        
    public enum GenderEnum
    
    {
        Male ,
        Female
    }
    }
}