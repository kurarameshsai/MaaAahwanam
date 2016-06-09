using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;
using MaaAahwanam.Models;
using MaaAahwanam.Utility;
using System.Configuration;

namespace MaaAahwanam
{
    public class UserAddressBookBal
    {
        Maa_AhwaanamBase _Respositories = new Maa_AhwaanamBase();

        public void SavingAddressBookDetails(UserAddBook useraddbook)
        {
            MA_User_AddBook addbook = new MA_User_AddBook();
            addbook.UserLoginId = ValidUserUtility.ValidUser();
            addbook.PersonName = useraddbook.PersonName;
            addbook.PersonPhone = useraddbook.PersonPhone;
            addbook.PersonEmail = useraddbook.PersonEmail;
            addbook.PersonLocation = useraddbook.PersonLocation;
            addbook.PersonCity = useraddbook.PersonCity;
            addbook.PersonAddress = useraddbook.PersonAddress;
            _Respositories.UserAddBook.Add(addbook);
            _Respositories.SaveChanges();
        }
        
       public List<SP_ADDRESSBOOK_Result> Addressbook(int id)
        {
            return _Respositories.sp_AddressBook.ExecuteProcedure_WithParameters("exec sp_AddressBook {0},{1}", id, 1).ToList();
        }
    }
}
