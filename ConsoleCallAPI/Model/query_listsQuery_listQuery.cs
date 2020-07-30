using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCallAPI.Model
{

    // 注意: 產生的程式碼可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class query_lists
    {

        private byte bhnocountField;

        private query_listsQuery_list[] query_listField;

        /// <remarks/>
        public byte bhnocount
        {
            get
            {
                return this.bhnocountField;
            }
            set
            {
                this.bhnocountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("query_list")]
        public query_listsQuery_list[] query_list
        {
            get
            {
                return this.query_listField;
            }
            set
            {
                this.query_listField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class query_listsQuery_list
    {

        private string ipField;

        private query_listsQuery_listQuery[] queryField;

        /// <remarks/>
        public string ip
        {
            get
            {
                return this.ipField;
            }
            set
            {
                this.ipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("query")]
        public query_listsQuery_listQuery[] query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class query_listsQuery_listQuery
    {

        private string bhnoField;

        private byte hcmioField;

        private byte hcnrhField;

        private byte hcrrhField;

        private byte hdbrhField;

        private byte hcdtdField;

        private uint tcnudField;

        private ushort tcrudField;

        private ushort tdbudField;

        private byte adjcoField;

        private byte hrhodField;

        private byte hcntdField;

        /// <remarks/>
        public string bhno
        {
            get
            {
                return this.bhnoField;
            }
            set
            {
                this.bhnoField = value;
            }
        }

        /// <remarks/>
        public byte hcmio
        {
            get
            {
                return this.hcmioField;
            }
            set
            {
                this.hcmioField = value;
            }
        }

        /// <remarks/>
        public byte hcnrh
        {
            get
            {
                return this.hcnrhField;
            }
            set
            {
                this.hcnrhField = value;
            }
        }

        /// <remarks/>
        public byte hcrrh
        {
            get
            {
                return this.hcrrhField;
            }
            set
            {
                this.hcrrhField = value;
            }
        }

        /// <remarks/>
        public byte hdbrh
        {
            get
            {
                return this.hdbrhField;
            }
            set
            {
                this.hdbrhField = value;
            }
        }

        /// <remarks/>
        public byte hcdtd
        {
            get
            {
                return this.hcdtdField;
            }
            set
            {
                this.hcdtdField = value;
            }
        }

        /// <remarks/>
        public uint tcnud
        {
            get
            {
                return this.tcnudField;
            }
            set
            {
                this.tcnudField = value;
            }
        }

        /// <remarks/>
        public ushort tcrud
        {
            get
            {
                return this.tcrudField;
            }
            set
            {
                this.tcrudField = value;
            }
        }

        /// <remarks/>
        public ushort tdbud
        {
            get
            {
                return this.tdbudField;
            }
            set
            {
                this.tdbudField = value;
            }
        }

        /// <remarks/>
        public byte adjco
        {
            get
            {
                return this.adjcoField;
            }
            set
            {
                this.adjcoField = value;
            }
        }

        /// <remarks/>
        public byte hrhod
        {
            get
            {
                return this.hrhodField;
            }
            set
            {
                this.hrhodField = value;
            }
        }

        /// <remarks/>
        public byte hcntd
        {
            get
            {
                return this.hcntdField;
            }
            set
            {
                this.hcntdField = value;
            }
        }
    }


}
