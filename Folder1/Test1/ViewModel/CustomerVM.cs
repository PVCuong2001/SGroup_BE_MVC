using System;

namespace Test1.ViewModel
{
    public class CustomerVM
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DTB { get; set; }
        public GenderEnum Gender { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
    public enum GenderEnum
    
    {
        Male ,
        Female
    }
    }
}