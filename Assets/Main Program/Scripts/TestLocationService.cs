using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLocationService : MonoBehaviour
{

    // Comunity center location
    // Latitude 10.275922
    // Longitude -84.797672


    public double latitude = 0;
    public double longitude = 0;
    private double baseLatitude = 10.279811;
    private double baseLongitude = -84.810764;
    private double calculatedLatitude = 0;
    private double calculatedLongitude = 0;
    private double factor = 89000;
    public GameObject point;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setPointer(latitude, longitude);
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
