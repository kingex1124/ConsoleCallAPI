using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCallAPI.Model
{

    public class XmlJsonData
    {
        public Xml xml { get; set; }
        public Query_Lists query_lists { get; set; }
    }

    public class Xml
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public string standalone { get; set; }
    }

    public class Query_Lists
    {
        public string bhnocount { get; set; }
        public Query_List[] query_list { get; set; }
    }

    public class Query_List
    {
        public string ip { get; set; }
        public Query[] query { get; set; }
    }

    public class Query
    {
        public string bhno { get; set; }
        public string hcmio { get; set; }
        public string hcnrh { get; set; }
        public string hcrrh { get; set; }
        public string hdbrh { get; set; }
        public string hcdtd { get; set; }
        public string tcnud { get; set; }
        public string tcrud { get; set; }
        public string tdbud { get; set; }
        public string adjco { get; set; }
        public string hrhod { get; set; }
        public string hcntd { get; set; }
    }
}
