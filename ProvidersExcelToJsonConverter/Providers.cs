using System.ComponentModel;
using Newtonsoft.Json;

namespace ProvidersExcelToJsonConverter
{
    public class Provider
    {
        private string _centreEmailAddress = string.Empty;
        private string _centreFax = string.Empty;
        private string _centreWebsite = string.Empty;
        private string _centrePhone = string.Empty;
        private string _centrePostcode = string.Empty;
        private string _centreSuburb = string.Empty;
        private string _centreStreet = string.Empty;
        private string _itemTitle = string.Empty;

        [JsonProperty(PropertyName = "Item_Title", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Item_Title
        {
            get { return _itemTitle; }
            set { _itemTitle = value; }
        }

        [JsonProperty(PropertyName = "Centre_Street", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Street
        {
            get { return _centreStreet; }
            set { _centreStreet = value; }
        }

        [JsonProperty(PropertyName = "Centre_Suburb", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Suburb
        {
            get { return _centreSuburb; }
            set { _centreSuburb = value; }
        }

        [JsonProperty(PropertyName = "Centre_Postcode", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Postcode
        {
            get { return _centrePostcode; }
            set { _centrePostcode = value; }
        }

        [JsonProperty(PropertyName = "Centre_Phone", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Phone
        {
            get { return _centrePhone; }
            set { _centrePhone = value; }
        }


        [JsonProperty(PropertyName = "Centre_Website", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Website
        {
            get { return _centreWebsite; }
            set { _centreWebsite = value; }
        }

        [JsonProperty(PropertyName = "Centre_Fax", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Fax
        {
            get { return _centreFax; }
            set { _centreFax = value; }
        }

        [JsonProperty(PropertyName = "Centre_Email_Address", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Centre_Email_Address
        {
            get { return _centreEmailAddress; }
            set { _centreEmailAddress = value; }
        }
    }
}