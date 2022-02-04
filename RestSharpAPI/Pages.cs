using System;
using System.Collections.Generic;

namespace RestSharpAPI
{
    public partial class Pages
    {

        public long Page { get; set; }
        public long Per_Page { get; set; }
        public long Total { get; set; }
        public long Total_Pages { get; set; }
        public List<Data> Data { get; set; }
    }

    public partial class Data
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Uri Avatar { get; set; }
    }

    
}
