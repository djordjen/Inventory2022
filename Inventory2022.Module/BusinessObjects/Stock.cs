using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Inventory2022.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Price_Item")]
    [DeferredDeletion(false), OptimisticLocking(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class Stock : XPObject
    {

        public Stock(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        DateTime lastRestock;
        double reserved;
        DateTime lastChange;
        decimal stockPrice;
        decimal _value;
        double balance;
        Warehouse warehouse;
        Product product;

        [Association("Product-Stocks")]
        public Product Product
        {
            get { return product; }
            set { SetPropertyValue("Product", ref product, value); }
        }

        [Association("Warehouse-Stocks")]
        public Warehouse Warehouse
        {
            get { return warehouse; }
            set { SetPropertyValue("Warehouse", ref warehouse, value); }
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

        [FetchOnly]
        [DbType("decimal(5, 2)")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "#,0.0000")]
        public decimal StockPrice
        {
            get { return stockPrice; }
            set { SetPropertyValue("StockPrice", ref stockPrice, value); }
        }

        [FetchOnly]
        [DbType("money")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "#,0.00")]
        public decimal Value
        {
            get { return _value; }
            set { SetPropertyValue("Value", ref _value, value); }
        }

        [FetchOnly]
        [DbType("smalldatetime")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "dd/MM/yyyy HH:mm")]
        public DateTime LastChange
        {
            get { return lastChange; }
            set { SetPropertyValue("LastChange", ref lastChange, value); }
        }
        [FetchOnly]
        [DbType("smalldatetime")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "dd/MM/yyyy HH:mm")]
        public DateTime LastRestock
        {
            get { return lastRestock; }
            set { SetPropertyValue("LastRestock", ref lastRestock, value); }
        }

        [FetchOnly]
        [DbType("decimal(5, 2)")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "#,0.00")]
        public double Reserved
        {
            get { return reserved; }
            set { SetPropertyValue("Reserved", ref reserved, value); }
        }


    }
}