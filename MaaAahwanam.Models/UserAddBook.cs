using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class UserAddBook
    {
        public int AddBookId { get; set; }
        public int UserLoginId { get; set; }
        public string PersonName { get; set; }
        public string PersonPhone { get; set; }
        public string PersonEmail { get; set; }
        public string PersonLocation { get; set; }
        public string PersonAddress { get; set; }
        public string PersonCity { get; set; }

        public List<SP_ADDRESSBOOK_Result> sp_AddressBook1;
    }
}
