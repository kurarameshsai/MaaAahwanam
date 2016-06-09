using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace MaaAahwanam.Dal
{
    public class Maa_AhwaanamBase : IDisposable, IRepository_Indexes
    {
        DbContext _repositoryContext;
        Entities e = new Entities();
        public Maa_AhwaanamBase()
        {
            _repositoryContext = new Entities();
        }

        IRepository<MA_User_Login> _UserLoginDetails;
        public IRepository<MA_User_Login> UserLoginDetails
        {
            get
            {
                if (_UserLoginDetails == null) _UserLoginDetails = new BaseRepository<MA_User_Login>(_repositoryContext);

                return _UserLoginDetails;
            }

        }
        IRepository<SP_CART_ITEMSVIEW_Result> _SP_CART_ITEMSVIEW;
        public IRepository<SP_CART_ITEMSVIEW_Result> SP_CART_ITEMSVIEW 
        {
            get
            {
                if (_SP_CART_ITEMSVIEW  == null) _SP_CART_ITEMSVIEW  = new BaseRepository<SP_CART_ITEMSVIEW_Result>(_repositoryContext);

                return _SP_CART_ITEMSVIEW ;
            }

        }
        IRepository<MA_User_Details> _UserDetails;
        public IRepository<MA_User_Details> UserDetails
        {
            get
            {
                if (_UserDetails == null) _UserDetails = new BaseRepository<MA_User_Details>(_repositoryContext);

                return _UserDetails;
            }

        }
        
        IRepository<MA_IssueTickets> _IssueTickets;
        public IRepository<MA_IssueTickets> IssueTickets
        {
            get
            {
                if (_IssueTickets == null) _IssueTickets = new BaseRepository<MA_IssueTickets>(_repositoryContext);

                return _IssueTickets;
            }
        }

        IRepository<MA_Issue_Details> _IssueTickets_Details;
        public IRepository<MA_Issue_Details> IssueTickets_Details
        {
            get
            {
                if (_IssueTickets_Details == null) _IssueTickets_Details = new BaseRepository<MA_Issue_Details>(_repositoryContext);

                return _IssueTickets_Details;
            }
        }

        IRepository<MA_User_Vendor> _VendorDetails;
        public IRepository<MA_User_Vendor> VendorDetails
        {
            get
            {
                if (_VendorDetails == null) _VendorDetails = new BaseRepository<MA_User_Vendor>(_repositoryContext);

                return _VendorDetails;
            }
        }

        IRepository<MA_Vendor_Aminities>  _VendorAminitiesDetails;
        public IRepository<MA_Vendor_Aminities> VendorAminitiesDetails
        {
            get
            {
                if (_VendorAminitiesDetails == null) _VendorAminitiesDetails = new BaseRepository<MA_Vendor_Aminities>(_repositoryContext);

                return _VendorAminitiesDetails;
            }
        }
        
        IRepository<MA_Vendor_Images> _VendorImagesDetails;
        public IRepository<MA_Vendor_Images> VendorImagesDetails
        {
            get
            {
                if (_VendorImagesDetails == null) _VendorImagesDetails = new BaseRepository<MA_Vendor_Images>(_repositoryContext);

                return _VendorImagesDetails;
            }
       
        }

        //Sai
        IRepository<MA_Vendor_Packages> _Vendorpackages;
        public IRepository<MA_Vendor_Packages> Vendorpackages
        {
            get
            {
                if (_Vendorpackages == null) _Vendorpackages = new BaseRepository<MA_Vendor_Packages>(_repositoryContext);

                return _Vendorpackages;
            }

        }

        IRepository<MA_Invi_Designs> _InviDesigns;
        public IRepository<MA_Invi_Designs> InviDesigns
        {
            get
            {
                if (_InviDesigns == null) _InviDesigns = new BaseRepository<MA_Invi_Designs>(_repositoryContext);

                return _InviDesigns;
            }
        }


        IRepository<MA_InviDesignPrices> _InviDesignPrices;
        public IRepository<MA_InviDesignPrices> InviDesignPrices
        {
            get
            {
                if (_InviDesignPrices == null) _InviDesignPrices = new BaseRepository<MA_InviDesignPrices>(_repositoryContext);
                return _InviDesignPrices;
            }
        }

        IRepository<MA_ExceptionLogs> _ExceptionLogs;
        public IRepository<MA_ExceptionLogs> ExceptionLogs
        {
            get
            {
                if (_ExceptionLogs == null) _ExceptionLogs = new BaseRepository<MA_ExceptionLogs>(_repositoryContext);

                return _ExceptionLogs;
            }
        }

        IRepository<MA_UserLogInTimings> _UserLogInTimings;
        public IRepository<MA_UserLogInTimings> UserLogInTimings
        {
            get
            {
                if (_UserLogInTimings == null) _UserLogInTimings = new BaseRepository<MA_UserLogInTimings>(_repositoryContext);

                return _UserLogInTimings;
            }
        }

        IRepository<MA_ForgotPassword> _ForgetPassword;
        public IRepository<MA_ForgotPassword> ForgetPassword
        {
            get
            {
                if (_ForgetPassword == null) _ForgetPassword = new BaseRepository<MA_ForgotPassword>(_repositoryContext);

                return _ForgetPassword;
            }

        }

        IRepository<MA_User_AddBook> _UserAddBook;
        public IRepository<MA_User_AddBook> UserAddBook
        {
            get
            {
                if (_UserAddBook == null) _UserAddBook = new BaseRepository<MA_User_AddBook>(_repositoryContext);
                return _UserAddBook;
            }
        }      

        IRepository<MA_Giftdesigns> _Giftdesigns;
        public IRepository<MA_Giftdesigns> Giftdesigns
        {
            get
            {
                if (_Giftdesigns == null) _Giftdesigns = new BaseRepository<MA_Giftdesigns>(_repositoryContext);

                return _Giftdesigns;
            }
        }

       IRepository<sp_vendorlist_Result> _sp_vendorlist;
       public IRepository<sp_vendorlist_Result> sp_vendorlist
       {
           get
           {
               if (_sp_vendorlist == null) _sp_vendorlist = new BaseRepository<sp_vendorlist_Result>(_repositoryContext);
               return _sp_vendorlist;
           }
       }

       IRepository<Sp_Admin_UserProfile_Result> _Sp_Admin_UserProfile;
       public IRepository<Sp_Admin_UserProfile_Result> Sp_Admin_UserProfile
       {
           get
           {
               if (_Sp_Admin_UserProfile == null) _Sp_Admin_UserProfile = new BaseRepository<Sp_Admin_UserProfile_Result>(_repositoryContext);
               return _Sp_Admin_UserProfile;
           }
       }
       
       
       IRepository<MA_Comments> _Comments;
       public IRepository<MA_Comments> Comments
       {
           get
           {
               if (_Comments == null) _Comments = new BaseRepository<MA_Comments>(_repositoryContext);
               return _Comments;
           }
       }

       IRepository<MA_SiteFaq> _Sitefaq;
       public IRepository<MA_SiteFaq> sitefaq
       {
           get
           {
               if (_Sitefaq == null) _Sitefaq = new BaseRepository<MA_SiteFaq>(_repositoryContext);
               return _Sitefaq;
           }
       }
       IRepository<MA_ExceptionLogs> _Exceptionlogs;
       public IRepository<MA_ExceptionLogs> Exceptionlogs
       {
           get
           {
               if (_Exceptionlogs == null) _Exceptionlogs = new BaseRepository<MA_ExceptionLogs>(_repositoryContext);
               return _Exceptionlogs;
           }
       }


       IRepository<MA_EventsandTips> _Eventsandtips;
       public IRepository<MA_EventsandTips> Eventsandtips
       {
           get
           {
               if (_Eventsandtips == null) _Eventsandtips = new BaseRepository<MA_EventsandTips>(_repositoryContext);
               return _Eventsandtips;
           }
       }

       IRepository<MA_Admin_dashboardcounts_Result> _MA_Admin_Dashboardcounts;
       public IRepository<MA_Admin_dashboardcounts_Result> MA_Admin_Dashboardcounts
       {
           get
           {
               if (_MA_Admin_Dashboardcounts == null) _MA_Admin_Dashboardcounts = new BaseRepository<MA_Admin_dashboardcounts_Result>(_repositoryContext);
               return _MA_Admin_Dashboardcounts;
           }
       }

       IRepository<SP_TICKETLIST_Result> _SP_TICKETLIST;
       public IRepository<SP_TICKETLIST_Result> SP_TICKETLIST
       {
           get
           {
               if (_SP_TICKETLIST == null) _SP_TICKETLIST = new BaseRepository<SP_TICKETLIST_Result>(_repositoryContext);
               return _SP_TICKETLIST;
           }
       }

       IRepository<SP_TicketsUserList_Result> _SP_TicketsUserList;
         public IRepository<SP_TicketsUserList_Result> SP_TicketsUserList
       {
           get
           {
               if (_SP_TicketsUserList == null) _SP_TicketsUserList = new BaseRepository<SP_TicketsUserList_Result>(_repositoryContext);
               return _SP_TicketsUserList;
           }
       }
         IRepository<MA_Admin_giftdesigns_multipleimages> _giftdesigns_multipleimages;
         public IRepository<MA_Admin_giftdesigns_multipleimages> giftdesigns_multipleimages
         {
             get
             {
                 if (_giftdesigns_multipleimages == null) _giftdesigns_multipleimages = new BaseRepository<MA_Admin_giftdesigns_multipleimages>(_repositoryContext);
                 return _giftdesigns_multipleimages;
             }
         }
         IRepository<SP_TESTIMONIALSLIST_Result> _SP_TESTIMONIALSLIST;
         public IRepository<SP_TESTIMONIALSLIST_Result> SP_TESTIMONIALSLIST
         {
             get
             {
                 if (_SP_TESTIMONIALSLIST == null) _SP_TESTIMONIALSLIST = new BaseRepository<SP_TESTIMONIALSLIST_Result>(_repositoryContext);
                 return _SP_TESTIMONIALSLIST;
             }
         }

         IRepository<MA_Admin_Invitationdesigns_multiimages> _Invitationdesigns_multiimages;
         public IRepository<MA_Admin_Invitationdesigns_multiimages> Invitationdesigns_multiimages
         {
             get
             {
                 if (_Invitationdesigns_multiimages == null) _Invitationdesigns_multiimages = new BaseRepository<MA_Admin_Invitationdesigns_multiimages>(_repositoryContext);
                 return _Invitationdesigns_multiimages;
             }
         }
         IRepository<SP_ADDRESSBOOK_Result> _sp_AddressBook;
         public IRepository<SP_ADDRESSBOOK_Result> sp_AddressBook
         {
             get
             {
                 if (_sp_AddressBook == null) _sp_AddressBook = new BaseRepository<SP_ADDRESSBOOK_Result>(_repositoryContext);
                 return _sp_AddressBook;
             }
         }

         IRepository<SP_DEALSLIST_Result> _SP_DEALSLIST;
         public IRepository<SP_DEALSLIST_Result> SP_DEALSLIST
         {
             get
             {
                 if (_SP_DEALSLIST == null) _SP_DEALSLIST = new BaseRepository<SP_DEALSLIST_Result>(_repositoryContext);
                 return _SP_DEALSLIST;
             }
         }
         IRepository<SP_EVENT_BEAUTY_HEALTH_LIST_Result> _SP_EVENT_BEAUTY_HEALTH_LIST;
         public IRepository<SP_EVENT_BEAUTY_HEALTH_LIST_Result> SP_EVENT_BEAUTY_HEALTH_LIST
         {
             get
             {
                 if (_SP_EVENT_BEAUTY_HEALTH_LIST == null) _SP_EVENT_BEAUTY_HEALTH_LIST = new BaseRepository<SP_EVENT_BEAUTY_HEALTH_LIST_Result>(_repositoryContext);
                 return _SP_EVENT_BEAUTY_HEALTH_LIST;
             }
         }
         IRepository<MA_Events_Master> _Events_Master;
         public IRepository<MA_Events_Master> Events_Master
         {
             get
             {
                 if (_Events_Master == null) _Events_Master = new BaseRepository<MA_Events_Master>(_repositoryContext);
                 return _Events_Master;
             }
         }
         IRepository<MA_Enquiry> _Enquiry;
         public IRepository<MA_Enquiry> Enquiry
         {
             get
             {
                 if (_Enquiry == null) _Enquiry = new BaseRepository<MA_Enquiry>(_repositoryContext);
                 return _Enquiry;
             }
         }
         IRepository<MA_Subscription> _Subscription;
         public IRepository<MA_Subscription> Subscription
         {
             get
             {
                 if (_Subscription == null) _Subscription = new BaseRepository<MA_Subscription>(_repositoryContext);
                 return _Subscription;
             }
         }
         IRepository<SP_ADMIN_Servicerequest_Result> _SP_ADMIN_Servicerequest;
         public IRepository<SP_ADMIN_Servicerequest_Result> SP_ADMIN_Servicerequest
         {
             get
             {
                 if (_SP_ADMIN_Servicerequest == null) _SP_ADMIN_Servicerequest = new BaseRepository<SP_ADMIN_Servicerequest_Result>(_repositoryContext);
                 return _SP_ADMIN_Servicerequest;
             }
         }
         IRepository<SP_ADMIN_ORDERS_Result> _sp_AdminOrders;
         public IRepository<SP_ADMIN_ORDERS_Result> sp_AdminOrders
         {
             get
             {
                 if (_sp_AdminOrders == null) _sp_AdminOrders = new BaseRepository<SP_ADMIN_ORDERS_Result>(_repositoryContext);
                 return _sp_AdminOrders;
             }
         }
         IRepository<SP_ADMIN_ORDERDITEMS_USER_Result> _sp_AdminOrderItems;
         public IRepository<SP_ADMIN_ORDERDITEMS_USER_Result> sp_AdminOrderItems
         {
             get
             {
                 if (_sp_AdminOrderItems == null) _sp_AdminOrderItems = new BaseRepository<SP_ADMIN_ORDERDITEMS_USER_Result>(_repositoryContext);
                 return _sp_AdminOrderItems;
             }
         }
         IRepository<SP_EVENTDETAILSANDEVENTDATES_Result> _sp_EventDetailsAndEventDates;
         public IRepository<SP_EVENTDETAILSANDEVENTDATES_Result> sp_EventDetailsAndEventDates
         {
             get
             {
                 if (_sp_EventDetailsAndEventDates == null) _sp_EventDetailsAndEventDates = new BaseRepository<SP_EVENTDETAILSANDEVENTDATES_Result>(_repositoryContext);
                 return _sp_EventDetailsAndEventDates;
             }
         }
         IRepository<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result> _sp_CountsOfTicketsAndNotifications;
         public IRepository<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result> sp_CountsOfTicketsAndNotifications
         {
             get
             {
                 if (_sp_CountsOfTicketsAndNotifications == null) _sp_CountsOfTicketsAndNotifications = new BaseRepository<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result>(_repositoryContext);
                 return _sp_CountsOfTicketsAndNotifications;
             }
         }
         IRepository<MA_Payment_Carddetails> _PaymentDetails;
         public IRepository<MA_Payment_Carddetails> PaymentDetails
         {
             get
             {
                 if (_PaymentDetails == null) _PaymentDetails = new BaseRepository<MA_Payment_Carddetails>(_repositoryContext);
                 return _PaymentDetails;
             }
         }
         IRepository<MA_EventDates> _MAEventDates;
         public IRepository<MA_EventDates> MAEventDates
         {
             get
             {
                 if (_MAEventDates == null) _MAEventDates = new BaseRepository<MA_EventDates>(_repositoryContext);
                 return _MAEventDates;
             }
         }
        public void ConnectionOpen()
        {
            _repositoryContext.Database.Connection.Open();
        }
        public void SaveChanges()
        {
            _repositoryContext.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryContext.Dispose();
        }
    }
}