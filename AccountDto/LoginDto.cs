using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDto
{
    public class LoginDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsSeesionActive { get; set; }
        public DateTime? LoginStartTime { get; set; }
        public DateTime LoginEndTime { get; set; }
        public int SiteId { get; set; }
    }
}
