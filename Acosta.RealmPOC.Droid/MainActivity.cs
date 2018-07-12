using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Acosta.RealmPOC.Core;
using Acosta.RealmPOC.Services;
using System;
using System.Linq;
using Android.Views;

namespace Acosta.RealmPOC.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    [MetaData("com.google.android.maps.v2.API_KEY", Value = "AIzaSyB6gpySUw0CppseU9WgQMUbxvGrtB113M0")]
    public class MainActivity : ListActivity
    {
        CycleService cycleService;
        StoreService storeService;

        StoresAdapter storesAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            storeService = new StoreService();
            cycleService = new CycleService();

            var cycles = cycleService.GetAllCycles().ToList().OrderBy(a => a.CycleYear).ThenBy(b => b.CycleNumber).ThenBy(c => c.ESP);

            if(cycles.Count() == 0)
            {
                Toast.MakeText(Application, "No Cycles! Loading Cycle Data!", ToastLength.Short).Show();

                cycleService.LoadCycles();
                cycles = cycleService.GetAllCycles().ToList().OrderBy(a => a.CycleYear).ThenBy(b => b.CycleNumber).ThenBy(c => c.ESP);
            }
            else
            {
                Toast.MakeText(Application, "Retrieving data from existing Realm!", ToastLength.Short).Show();
            }

            var stores = storeService.GetAllStores().ToList().OrderBy(s => s.AcostaNumber).ToList();
            if(stores.Count() == 0)
            {
                Toast.MakeText(Application, "No Stores! Loading Store Data!", ToastLength.Short).Show();
                storeService.LoadStores();
                stores = storeService.GetAllStores().ToList().OrderBy(s => s.AcostaNumber).ToList();
            }
            else
            {
                Toast.MakeText(Application, "Retrieving store data from existing Realm!", ToastLength.Short).Show();
            }

            //string[] cycleNames = cycles.Select(x => x.CycleYear.ToString() + x.CycleNumber.ToString() + x.ESP + "::" + x.Id.ToString()).ToArray<string>();



            //ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, cycleNames);
            //ListView.TextFilterEnabled = true;

            //ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            //{
            //    string cycletext = ((TextView)args.View).Text;
            //    string[] aCycleText = cycletext.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            //    int cycleId = 0;

            //    if(Int32.TryParse(aCycleText[1], out cycleId))
            //    {
            //        ShowCycleDetails(cycleId);
            //    }
            //};
            
            ListAdapter = new StoresAdapter(this, stores);

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var item = ((StoresAdapter)ListAdapter).GetItemAtPosition(args.Position);
                string messageFormat = "{0}\n{1} : {2}\n{3}\n{4}, {5} {6}\n{7}";
                long phone = 0;
                Int64.TryParse(item.StorePhone, out phone);
                string phoneNumber = string.Format("{0:(###)###-####}", phone);
                long izip = 0;
                Int64.TryParse(item.StoreZip, out izip);
                string szip = string.Format("{0:#####-####}", izip);
                string dialogMessage = string.Format(messageFormat, item.AcostaNumber, item.StoreName, item.StoreNumber, item.StoreAddress, item.StoreCity, item.StoreState, szip, phoneNumber);

                Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                alert.SetTitle("Store Details");
                alert.SetMessage(dialogMessage);
                alert.SetPositiveButton("OK", (senderAlert, e) => { /*just want to dismiss the dialog, not do anything else!*/ });
                Dialog dialog = alert.Create();
                dialog.Show();

            };

        }

        public void ShowCycleDetails(int cycleId)
        {
            var cycle = cycleService.GetCycleById(cycleId);
            string messageFormat = "Cycle ID: {0}\nCycle Year: {1}\nCycle Number: {2}\nCycle ESP Number: {3}\nCycle StartDate: {4}\nCycle EndDate: {5}";
            string dialogMessage = string.Format(messageFormat, cycle.Id, cycle.CycleYear, cycle.CycleNumber, cycle.ESP, cycle.StartDate, cycle.EndDate);

            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle("Cycle Details");
            alert.SetMessage(dialogMessage);
            alert.SetPositiveButton("OK", (senderAlert, args) => { /*just want to dismiss the dialog, not do anything else!*/ });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public void ShowMessageDialog(string title, string message)
        {
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", (senderAlert, args) => { /*just want to dismiss the dialog, not do anything else!*/ });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}

