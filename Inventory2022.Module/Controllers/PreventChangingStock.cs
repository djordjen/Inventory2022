using DevExpress.ExpressApp;
using Inventory2022.Module.BusinessObjects;

// How to set the AllowNew, AllowDelete and AllowEdit properties for all detail views of a business class in one place
// https://supportcenter.devexpress.com/ticket/details/s134620/how-to-set-the-allownew-allowdelete-and-allowedit-properties-for-all-detail-views-of-a

namespace Inventory2022.Module.Controllers
{
    public class PreventChangingStock : ViewController
    {
        const string keyCustomize = "Customize";
        public PreventChangingStock()
        {
            TargetViewType = ViewType.Any;
            TargetObjectType = typeof(Stock);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            if (View is DetailView)
            {
                DetailView detailView = (DetailView)View;
                detailView.AllowEdit[keyCustomize] = false;
                detailView.AllowDelete[keyCustomize] = false;
                detailView.AllowNew[keyCustomize] = false;
            }

            if (View is ListView)
            {
                ListView listView = (ListView)View;
                listView.AllowEdit[keyCustomize] = false;
                listView.AllowDelete[keyCustomize] = false;
                listView.AllowNew[keyCustomize] = false;
            }
        }
    }
}
