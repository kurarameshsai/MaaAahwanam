using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MaaAahwanam.Dal
{
    public interface IRepository_Indexes
    {
        IRepository<MA_User_Login> UserLoginDetails { get; }
        IRepository<MA_User_Details> UserDetails { get; }      
        IRepository<MA_IssueTickets> IssueTickets { get; }
        IRepository<MA_Issue_Details> IssueTickets_Details { get; }       
        IRepository<MA_Invi_Designs> InviDesigns { get; }
        IRepository<MA_InviDesignPrices> InviDesignPrices { get; }
        IRepository<MA_ExceptionLogs> ExceptionLogs { get; }
        IRepository<MA_UserLogInTimings> UserLogInTimings { get; }
        IRepository<MA_ForgotPassword> ForgetPassword { get; }
        IRepository<MA_User_Vendor> VendorDetails { get; }
        IRepository<MA_Vendor_Aminities> VendorAminitiesDetails { get; }
        IRepository<MA_Vendor_Images> VendorImagesDetails { get; }
        IRepository<MA_User_AddBook> UserAddBook { get; }      
        IRepository<MA_Giftdesigns> Giftdesigns { get; }      
        IRepository<Sp_Admin_UserProfile_Result> Sp_Admin_UserProfile { get; }
        IRepository<sp_vendorlist_Result> sp_vendorlist { get; }
        IRepository<MA_Vendor_Packages> Vendorpackages { get; }     
        IRepository<MA_Comments> Comments { get; }
        IRepository<MA_SiteFaq> sitefaq { get; }
        IRepository<MA_ExceptionLogs> Exceptionlogs { get; }
        IRepository<MA_EventsandTips> Eventsandtips { get; }
        IRepository<MA_Admin_giftdesigns_multipleimages> giftdesigns_multipleimages { get; }
        IRepository<MA_Admin_dashboardcounts_Result> MA_Admin_Dashboardcounts { get; }
        IRepository<SP_CART_ITEMSVIEW_Result> SP_CART_ITEMSVIEW { get; }
        IRepository<SP_TICKETLIST_Result> SP_TICKETLIST { get; }
        IRepository<SP_TicketsUserList_Result> SP_TicketsUserList { get; }
        IRepository<SP_TESTIMONIALSLIST_Result> SP_TESTIMONIALSLIST { get; }
        IRepository<MA_Admin_Invitationdesigns_multiimages> Invitationdesigns_multiimages { get; }
        IRepository<SP_DEALSLIST_Result> SP_DEALSLIST { get; }
        IRepository<SP_ADDRESSBOOK_Result> sp_AddressBook { get; }
        IRepository<SP_EVENT_BEAUTY_HEALTH_LIST_Result> SP_EVENT_BEAUTY_HEALTH_LIST { get; }
        IRepository<SP_ADMIN_Servicerequest_Result> SP_ADMIN_Servicerequest { get; }
        IRepository<SP_ADMIN_ORDERS_Result> sp_AdminOrders { get; }
        IRepository<SP_ADMIN_ORDERDITEMS_USER_Result> sp_AdminOrderItems { get; }
        IRepository<SP_EVENTDETAILSANDEVENTDATES_Result> sp_EventDetailsAndEventDates { get; }
        IRepository<SP_COUNTS_TICKETS_AND_NOTIFICATIONS_Result> sp_CountsOfTicketsAndNotifications { get; }
        IRepository<MA_Events_Master> Events_Master { get; }
        IRepository<MA_Enquiry> Enquiry { get; }
        IRepository<MA_Subscription> Subscription { get; }
        IRepository<MA_Payment_Carddetails> PaymentDetails { get; }
        IRepository<MA_EventDates> MAEventDates { get; }
        void ConnectionOpen();
        void SaveChanges();
    }
}
