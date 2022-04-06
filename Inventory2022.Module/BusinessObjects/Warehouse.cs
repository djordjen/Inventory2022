using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace Inventory2022.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Code")]
    [ImageName("BO_Product_Group")]
    [DeferredDeletion(false), OptimisticLocking(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    public class Warehouse : XPObject
    {

        string code;

        public Warehouse(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Size(5)]
        [DbType("varchar(5)")]
        [RuleRequiredField, RuleUniqueValue]
        [Indexed(Name = "IX_Code", Unique = true)]
        public string Code
        {
            get { return code; }
            set { SetPropertyValue("Code", ref code, value); }
        }

        [Association("Warehouse-LineItems")]
        public XPCollection<LineItem> LineItems
        {
            get { return GetCollection<LineItem>(nameof(LineItems)); }
        }

        [Association("Warehouse-Stocks")]
        public XPCollection<Stock> Stocks
        {
            get { return GetCollection<Stock>(nameof(Stocks)); }
        }

    }
}