package hyy.pathfinder.Data;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Location;
import android.support.design.widget.AppBarLayout;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.util.Log;

import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.LocationListener;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.Marker;

import java.util.ArrayList;
import java.util.List;

import hyy.pathfinder.Interfaces.AppDataInterface;
import hyy.pathfinder.Objects.StationList;
import hyy.pathfinder.Objects.fullRoute;
//import hyy.pathfinder.Objects.Route;

/**
 * Created by H8244 on 10/28/2016.
 */

public class ApplicationData extends Application
{
    public static final int MY_PERMISSIONS_REQUEST_LOCATION = 99;
    public static GoogleApiClient mGoogleApiClient;
    public static Context mContext;
    public static Location mLastLocation;
    public static LocationRequest mLocationRequest;
    public static LocationListener locationListener;
    public static ApplicationDataCallbacks applicationDataCallbacks;
    public static GoogleMap mMap;
    public static boolean deviceLocationIsOrigin;
    public static StationList stationData = new StationList();
    public static AppBarLayout routePresenterAppBar;
    public static fullRoute selectedRoute;
    public static fullRoute masterRoute;
    public static Marker mMarker;
    // Pitää ajaa getApplicationContext(), setApplicationDataCallbacks(), setApplicationDataCallbacksDelegate, setLocationListener(), buildGoogleApiClient ja viimeisenä createLocationRequest() (järjestys oleellinen, nullpointerit herkässä)
    // Tämän luokan onCreatessa homma ei toimi, koska luokasta ei koskaan tehdä insanssia - sen toimintoja käytetään vain staattisten funktioiden ja muuttujien kautta.
    // Aina kun siirrytään uuteen aktiviteettiin täytyy asettaa se aktiviteetti delegaatiksi jolle interface paiskaa vastuun callbackista, pysäyttää edellisen mGoogleApiClientin updatet ja luoda uusi googleApiClient uudelle aktiviteetille


    public static void setApplicationDataCallbacks()
    {
        Log.d("ApplicationData", "setApplicationDataCallbacks");
        applicationDataCallbacks = new ApplicationDataCallbacks();
    }


    public static void setLocationListener()
    {
        Log.d("ApplicationData", "setLocationListener");
        ApplicationData.locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
                applicationDataCallbacks.delegate.atLocationChanged(location);
            }
        };
    }

    public static void setApplicationDataCallbacksDelegate(AppDataInterface Delegate)
    {
        Log.d("ApplicationData", "setting delegate");
        applicationDataCallbacks.delegate = Delegate;
    }


    public static void startLocationUpdates(Activity activity)
    {
        Log.d("ApplicationData", "startLocationUpdates");
        if(checkLocationPermission(activity)) {

            Log.d("ApplicationData", "permission granted, updating location");
            LocationServices.FusedLocationApi.requestLocationUpdates(mGoogleApiClient, mLocationRequest, locationListener);
            getLastLocation(activity);
        }
    }

    protected static void stopLocationUpdates() {

        Log.d("ApplicationData", "stopLocationServices");
        LocationServices.FusedLocationApi.removeLocationUpdates(mGoogleApiClient, locationListener);
    }


    public static void getLastLocation(Activity activity)
    {
        Log.d("ApplicationData", "getLastLocation");
        if(checkLocationPermission(activity)) {
            mLastLocation = LocationServices.FusedLocationApi.getLastLocation(mGoogleApiClient);
        }
    }

    public static boolean checkLocationPermission(Activity activity){
        if (ContextCompat.checkSelfPermission(activity,
                android.Manifest.permission.ACCESS_FINE_LOCATION)
                != PackageManager.PERMISSION_GRANTED) {

            // Asking user if explanation is needed
            if (ActivityCompat.shouldShowRequestPermissionRationale(activity,
                    android.Manifest.permission.ACCESS_FINE_LOCATION)) {
                // Show an expanation to the user *asynchronously* -- don't block
                // this thread waiting for the user's response! After the user
                // sees the explanation, try again to request the permission.

                //Prompt the user once explanation has been shown
                ActivityCompat.requestPermissions(activity,
                        new String[]{android.Manifest.permission.ACCESS_FINE_LOCATION},
                        MY_PERMISSIONS_REQUEST_LOCATION);

            } else {
                // No explanation needed, we can request the permission.
                ActivityCompat.requestPermissions(activity,
                        new String[]{android.Manifest.permission.ACCESS_FINE_LOCATION},
                        MY_PERMISSIONS_REQUEST_LOCATION);
            }
            return false;
        } else {
            return true;
        }
    }

    public static void createLocationRequest() {

        Log.d("ApplicationData", "createLocationRequest");
        mLocationRequest = new LocationRequest();
        mLocationRequest.setInterval(10000);
        mLocationRequest.setFastestInterval(5000);
        mLocationRequest.setPriority(LocationRequest.PRIORITY_BALANCED_POWER_ACCURACY);
    }


    public static synchronized void buildGoogleApiClient(Activity activity) {
        Log.d("ApplicationData", "buildGoogleApiClient");
        mGoogleApiClient = new GoogleApiClient.Builder(activity)
                .addConnectionCallbacks(applicationDataCallbacks)
                .addApi(LocationServices.API)
                .build();
    }

    public static void connectGoogleApiClient()
    {
        mGoogleApiClient.connect();
    }
}
