using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Inventory2022.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class RefreshAfterCommitVC : ViewController
    {
        bool needRefresh = false;
        public RefreshAfterCommitVC()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.Committed += ObjectSpace_Committed;
            ObjectSpace.Committing += ObjectSpace_Committing;
            ObjectSpace.Reloaded += ObjectSpace_Reloaded;
        }
        protected override void OnDeactivated()
        {
            ObjectSpace.Committed -= ObjectSpace_Committed;
            ObjectSpace.Committing -= ObjectSpace_Committing;
            ObjectSpace.Reloaded -= ObjectSpace_Reloaded;
            base.OnDeactivated();
        }
        private void ObjectSpace_Reloaded(object sender, EventArgs e)
        {
            needRefresh = false;
        }
        private void ObjectSpace_Committing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var objectSpace = (IObjectSpace)sender;
            foreach (var obj in objectSpace.GetObjectsToSave(false))
            {
                if (objectSpace.IsNewObject(obj))
                {
                    needRefresh = true; break;
                }

                // Radi, ali mozda valja uvesti neki kriterijum - ako je objekat takav da ima kalkulisane vrijednosti
                // TODO - Uvesti neki kriterijum, da je potrebno osvjeziti samo ako ima kalkulisanih vrijednosti
                if (objectSpace.IsObjectToSave(obj))
                {
                    needRefresh = true; break;
                }
            }
        }
        private void ObjectSpace_Committed(object sender, EventArgs e)
        {
            if (needRefresh)
            {
                ((IObjectSpace)sender).Refresh();
                needRefresh = false;
            }
        }
    }
}
