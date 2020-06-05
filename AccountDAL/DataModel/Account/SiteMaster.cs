using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDAL.Account
{
    public class SiteMaster
    {
        public int? SiteId { get; set; }     
        public String SiteName   { get; set; }      
        public String Address   { get; set; }      
        public string Phone   { get; set; }         
        public string Mobile   { get; set; }       
        public int? CityId   { get; set; }        
        public int? Stateid   { get; set; }       
        public int? CountryId   { get; set; }     
        public decimal? PinCode   { get; set; }     
        public bool? IsActive   { get; set; }       
        public int? CreatedBy   { get; set; }       
        public DateTime? CreatedDate   { get; set; }   
        public int? UodatedBy   { get; set; }        
        public DateTime? UpdatedDate   { get; set; }   
        public byte[] Logo   { get; set; }          
        public String Comments   { get; set; }  
    }
    }
