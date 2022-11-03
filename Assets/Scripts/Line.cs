using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;

    List<GameObject> colliders = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.1f;
        //AddCollidersBetween();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        //MoveCollidersBetween();
    }

    void AddCollidersBetween()
    {
        const int padding = 2;
        const int colliderCount = 10 + padding;
        const float cubeSize = 0.5f;

        const float lerpMultiplier = 1f / colliderCount;

        for (int i = 1; i < colliderCount; i++)
        {
            float lerpFactor = i * lerpMultiplier;

            GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeObject.name = "Cube " + i;

            Transform cube = cubeObject.transform;
            cube.position = Vector3.Lerp(
                origin.transform.position, destination.transform.position, lerpFactor
            );
            cube.localScale = Vector3.one * cubeSize;
            cube.LookAt(destination.transform.position);
            
            
            colliders.Add(cubeObject);
        }
    }

    void MoveCollidersBetween()
    {


        const int padding = 2;
        const int colliderCount = 15 + padding;
        const float cubeSize = 0.5f;

        const float lerpMultiplier = 1f / colliderCount;

        int index = 0;
        for (int i = 1; i < colliderCount; i++)
        {
            float lerpFactor = i * lerpMultiplier;

            //GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cubeObject.name = "Cube " + i;

            colliders[index].gameObject.transform.position = Vector3.Lerp(origin.transform.position, destination.transform.position, lerpFactor);
            colliders[index].gameObject.transform.localScale = Vector3.one * cubeSize;
            colliders[index].gameObject.transform.LookAt(destination.transform.position);
        }
    }

}
