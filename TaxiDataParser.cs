using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaxiTrip
{
    public string tpep_pickup_datetime;
    public string tpep_dropoff_datetime;
    public float pickup_latitude;
    public float pickup_longitude;
    public float dropoff_latitude;
    public float dropoff_longitude;
}

[System.Serializable]
public class TaxiTripList
{
    public List<TaxiTrip> taxiTrips;
}

public class TaxiDataParser : MonoBehaviour
{
    public string jsonFileName = "yellow_taxi_data";
    public GameObject pickupPrefab;
    public GameObject dropoffPrefab;
    public GameObject lineContainerPrefab;
    public float scale = 0.001f;
    public Vector3 offset = new Vector3(0, 0, 0);

    void Start()
    {
        LoadAndParseJson();
    }

    void LoadAndParseJson()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>(jsonFileName);
        if (jsonTextFile != null)
        {
            TaxiTripList taxiTripList = JsonUtility.FromJson<TaxiTripList>("{\"taxiTrips\":" + jsonTextFile.text + "}");

            foreach (var trip in taxiTripList.taxiTrips)
            {
                Debug.Log($"Pickup: {trip.pickup_latitude}, {trip.pickup_longitude} | Dropoff: {trip.dropoff_latitude}, {trip.dropoff_longitude}");

                Vector3 pickupPosition = new Vector3(trip.pickup_longitude, 0, trip.pickup_latitude) * scale + offset;
                Vector3 dropoffPosition = new Vector3(trip.dropoff_longitude, 0, trip.dropoff_latitude) * scale + offset;

                Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);
                Instantiate(dropoffPrefab, dropoffPosition, Quaternion.identity);

                DrawLine(pickupPosition, dropoffPosition);
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.SetParent(lineContainerPrefab.transform);
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
    }
}
