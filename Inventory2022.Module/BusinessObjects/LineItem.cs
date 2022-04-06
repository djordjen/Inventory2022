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
    [ImageName("BO_Sale_Item")]
    [OptimisticLocking(false), DeferredDeletion(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class LineItem : XPObject
    {
        public LineItem(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Random r = new Random();
            Date = DateTime.Today.AddDays(0 - r.Next(1, 50));
        }

        decimal stockPrice;
        bool levelAffected;
        Warehouse warehouse;
        double balance;
        double change;
        double prevBalance;
        string type;
        double quantity;
        DateTime date;
        Product product;


        [RuleRequiredField]
        [Association("Warehouse-LineItems")]
        public Warehouse Warehouse
        {
            get { return warehouse; }
            set { SetPropertyValue("Warehouse", ref warehouse, value); }
        }

        [RuleRequiredField]
        [Association("Product-LineItems")]
        public Product Product
        {
            get { return product; }
            set { SetPropertyValue("Product", ref product, value); }
        }

        [Nullable(false)]
        [RuleRequiredField]
        [DbType("smalldatetime")]
        [Indexed(Name = "IX_Date")]
        public DateTime Date
        {
            get { return date; }
            set { SetPropertyValue("Date", ref date, value); }
        }

        /// <summary>
        /// Can be:
        ///     I => input
        ///     O => output
        ///     B => balance
        /// </summary>
        [Size(1)]
        [Nullable(false)]
        [DbType("char(1)")]
        [RuleRequiredField]
        [Indexed(Name = "IX_Type")]
        public string Type
        {
            get { return type; }
            set { SetPropertyValue("Type", ref type, value); }
        }

        [Nullable(false)]
        [Indexed(Name = "IX_LevelAffected")]
        [ToolTip("Level affected")]
        [ModelDefault("Caption", "LA")]
        public bool LevelAffected
        {
            get { return levelAffected; }
            set { SetPropertyValue("LevelAffected", ref levelAffected, value); }
        }

        [Nullable(false)]
        [RuleRequiredField]
        [DbType("decimal(5, 2)")]
        [ModelDefault("DisplayFormat", "#,0.00")]
        public double Quantity
        {
            get { return quantity; }
            set { SetPropertyValue("Quantity", ref quantity, value); }
        }

        [Nullable(false)]
        [RuleRequiredField]
        [DbType("decimal(10, 4)")]
        [ModelDefault("DisplayFormat", "#,0.0000")]
        [ModelDefault("EditMask", "###,##0.0000")]
        public decimal StockPrice
        {
            get { return stockPrice; }
            set { SetPropertyValue("StockPrice", ref stockPrice, value); }
        }

        [FetchOnly]
        [DbType("decimal(5, 2)")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("Caption", "Previous")]
        [ModelDefault("DisplayFormat", "#,0.00")]
        public double PrevBalance
        {
            get { return prevBalance; }
            set { SetPropertyValue("PrevBalance", ref prevBalance, value); }
        }

        [FetchOnly]
        [DbType("decimal(5, 2)")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "+#,0.00;-#,0.00;0")] // https://docs.devexpress.com/WindowsForms/2141/common-features/formatting-values/format-specifiers
        public double Change
        {
            get { return change; }
            set { SetPropertyValue("Change", ref change, value); }
        }

        [FetchOnly]
        [DbType("decimal(5, 2)")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "#,0.00")]
        public double Balance
        {
            get { return balance; }
            set { SetPropertyValue("Balance", ref balance, value); }
        }
        
    }
}