using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    float panjangRay = 100f;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("target3").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 arahTarget = target.position - transform.position;
        Ray ray = new Ray(transform.position, arahTarget);
        Debug.DrawLine(ray.origin, arahTarget * panjangRay, Color.red);

        RaycastHit hit;
        bool isRayHit = Physics.Raycast(ray, out hit, panjangRay);
        if (isRayHit)
        {
            Debug.Log("Ray CAM kena : " + hit.collider.name);
        }
    }
}
