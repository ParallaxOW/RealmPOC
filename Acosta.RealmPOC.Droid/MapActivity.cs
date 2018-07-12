
using Android.App;
using Android.OS;


namespace Acosta.RealmPOC.Droid
{
    [Activity(Label = "Store Location")]
    public class MapActivity : Activity//, IOnMapReadyCallback
    {
        //private static float StoreLat;
        //private static float StoreLon;
        //private GoogleMap _map;
        //private MapFragment _mapFragment;


        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    SetContentView(Resource.Layout.map_layout);

        //    InitMapFragment();


        //}

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    SetupMapIfNeeded();
        //}

        //private void InitMapFragment()
        //{
        //    _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
        //    if (_mapFragment == null)
        //    {
        //        GoogleMapOptions mapOptions = new GoogleMapOptions()
        //            .InvokeMapType(GoogleMap.MapTypeSatellite)
        //            .InvokeZoomControlsEnabled(false)
        //            .InvokeCompassEnabled(true);

        //        FragmentTransaction fragTx = FragmentManager.BeginTransaction();
        //        _mapFragment = MapFragment.NewInstance(mapOptions);
        //        fragTx.Add(Resource.Id.map, _mapFragment, "map");
        //        fragTx.Commit();
        //    }
        //    _mapFragment.GetMapAsync(this);
        //}
    }
}