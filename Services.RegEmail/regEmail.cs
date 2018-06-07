using System;

namespace Services.RegEmail
{
    public class RegEmail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool isReg { get; set; }
        public DateTime? TimeClone { get; set; }
    }
}
