using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Acosta.RealmPOC.Core;
using Java.Lang;

namespace Acosta.RealmPOC.Droid
{
    public class StoresAdapter : BaseAdapter
    {
        Activity context;

        public List<Store> Stores { get; set; }

        public override int Count
        {
            get { return Stores.Count; }
        }

        public StoresAdapter(Activity context) : base()
        {
            this.context = context;
        }

        public StoresAdapter(Activity context, List<Store> stores) : base()
        {
            this.context = context;
            this.Stores = stores;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = Stores[position];
            var view = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.list_item, parent, false)) as RelativeLayout;

            var storeName = view.FindViewById<TextView>(Resource.Id.textTop);
            var storeNumber = view.FindViewById<TextView>(Resource.Id.textBottom);

            storeName.SetText(item.StoreName, TextView.BufferType.Normal);
            storeNumber.SetText(item.StoreNumber, TextView.BufferType.Normal);

            return view;
        }

        public Store GetItemAtPosition(int position)
        {
            return Stores[position];
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
    }
}