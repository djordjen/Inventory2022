using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace Inventory2022.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Code")]
    [ImageName("BO_Product_Group")]
    [DeferredDeletion(false), OptimisticLocking(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Bottom)]
    public class Warehouse : XPObject
    {
        public Warehouse(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string code;

        [Size(5)]
        [DbType("varchar(5)")]
        [RuleRequiredField, RuleUniqueValue]
        [Indexed(Name ="IX_Code", Unique = true)]
        public string Code
        {
            get { return code; }
            set { SetPropertyValue("Code", ref code, value); }
        }

        [Association("Warehouse-Stocks")]
        public XPCollection<Stock> Stocks
        {
            get { return GetCollection<Stock>(nameof(Stocks)); }
        }

        [Association("Warehouse-LineItems")]
        public XPCollection<LineItem> LineItems
        {
            get { return GetCollection<LineItem>(nameof(LineItems)); }
        }

    }
}