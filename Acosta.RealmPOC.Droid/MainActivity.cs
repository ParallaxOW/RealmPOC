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
    public class MainActivity : ListActivity
    {
        CycleService cycleService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            cycleService = new CycleService();
            var cycles = cycleService.GetAllCycles().ToList().OrderBy(a => a.CycleYear).ThenBy(b => b.CycleNumber).ThenBy(c => c.ESP);

            if(cycles.Count() == 0)
            {
                Toast.MakeText(Application, "No Cycles Loading Fresh realm!", ToastLength.Short).Show();

                cycleService.LoadCycles();
                cycles = cycleService.GetAllCycles().ToList().OrderBy(a => a.CycleYear).ThenBy(b => b.CycleNumber).ThenBy(c => c.ESP);

                ShowMessageDialog("Done!", "Initial Realm Load Complete!");
            }
            else
            {
                Toast.MakeText(Application, "Retrieving data from existing Realm!", ToastLength.Short).Show();
            }

            
            string[] cycleNames = cycles.Select(x => x.CycleYear.ToString() + x.CycleNumber.ToString() + x.ESP + "::" + x.Id.ToString()).ToArray<string>();

            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, cycleNames);
            ListView.TextFilterEnabled = true;

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                string cycletext = ((TextView)args.View).Text;
                string[] aCycleText = cycletext.Split(new string[1] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                int cycleId = 0;

                if(Int32.TryParse(aCycleText[1], out cycleId))
                {
                    ShowCycleDetails(cycleId);
                }
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

