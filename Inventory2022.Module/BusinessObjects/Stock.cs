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

    }
}