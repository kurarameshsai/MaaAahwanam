using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaaAahwanam.Dal;

namespace MaaAahwanam.Models
{
    public class MultipleImagesforInvitations
    {
        public int id { get; set; }
        public int Invitaitonid { get; set; }
        public string image { get; set; }
        public string imageid { get; set; }
    }
}
