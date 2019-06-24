using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationService : MonoBehaviour
{
    private double baseLatitude = 10.279811;
    private double baseLongitude = -84.810764;
    private double calculatedLatitude = 0;
    private double calculatedLongitude = 0;
    private double factor = 89000;
    public GameObject point;


    IEnumerator Start()
    {
        point.SetActive(false);
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            point.SetActive(true);
            setPointer(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    void setPointer(double _lat, double _long)
    {
        calculatedLatitude = (_lat - baseLatitude);
        calculatedLongitude = (_long - baseLongitude);
        Debug.Log("Latitude " + calculatedLatitude);
        Debug.Log("Longitude " + calculatedLongitude);
        point.transform.localPosition = new Vector3((float)(calculatedLongitude * factor), (float)(calculatedLatitude * factor), 0);
    }
}
