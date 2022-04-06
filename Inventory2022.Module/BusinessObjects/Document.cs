using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Validation;

namespace Inventory2022.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Document")]
    [DefaultProperty("Number")]
    [ModelDefault("IsCloneable", "True")]
    [OptimisticLocking(false), DeferredDeletion(false)]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    public class Document : XPObject
    {
        public Document(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        DateTime date;
        string number;

        [Size(10)]
        [NonCloneable]
        [RuleRequiredField, RuleUniqueValue]
        [Indexed(Name = "IX_Number", Unique = true)]
        public string Number
        {
            get { return number; }
            set { SetPropertyValue("Number", ref number, value); }
        }

        [NonCloneable]
        [DbType("smalldatetime")]
        [VisibleInLookupListView(true)]
        public DateTime Date
        {
            get { return date; }
            set { SetPropertyValue("Date", ref date, value); }
        }

    }
}