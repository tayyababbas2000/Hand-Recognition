using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    public Vector3[] handPointsHard;

    public bool isLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        handPointsHard = new Vector3[21];
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        //print(data);
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');
        //print(points[0]);
        for (int i = 0; i < 21; i++)
        {
            float x = float.Parse(points[i * 3]) / 100f;
            float y = float.Parse(points[(i * 3) + 1]) / 100f;
            float z = float.Parse(points[(i * 3) + 2]) / 100f;

            handPointsHard[i] = new Vector3(x, y, z);
        }

        for (int i = 0; i < 21; i++)
        {
           
            handPoints[i].transform.localPosition = Vector3.Lerp(handPoints[i].transform.localPosition, handPointsHard[i], Time.deltaTime*10f);
        }

    }

}
