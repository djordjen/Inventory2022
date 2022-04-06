using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Inventory2022.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Product")]
    [OptimisticLocking(false), DeferredDeletion(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class Product : XPObject
    {
        public Product(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Random r = new Random();
            refNo = r.Next(10000000, 99999999).ToString();
        }

        double onStock;
        string refNo;
        string name;

        [Size(13)]
        [Nullable(false)]
        [DbType("char(8)")]
        [RuleRequiredField, RuleUniqueValue]
        [Indexed(Name = "IX_RefNo", Unique = true)]
        public string RefNo
        {
            get { return refNo; }
            set { SetPropertyValue("RefNo", ref refNo, value); }
        }

        [Size(100)]
        [Nullable(false)]
        [RuleRequiredField, RuleUniqueValue]
        [Indexed(Name = "IX_Name", Unique = true)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        [FetchOnly]
        [ModelDefault("AllowEdit", "false")]
        public double OnStock
        {
            get { return onStock; }
            set { SetPropertyValue("OnStock", ref onStock, value); }
        }

        [Association("Product-LineItems")]
        public XPCollection<LineItem> LineItems
        {
            get { return GetCollection<LineItem>(nameof(LineItems)); }
        }

        [Association("Product-Stocks")]
        public XPCollection<Stock> Stocks
        {
            get { return GetCollection<Stock>(nameof(Stocks)); }
        }

    }
}