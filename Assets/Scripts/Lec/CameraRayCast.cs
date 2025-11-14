using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    float panjangRay = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawLine(ray.origin, Camera.main.transform.forward * panjangRay, Color.red);

        RaycastHit hit;
        bool isRayHit = Physics.Raycast(ray, out hit, panjangRay);
        if (isRayHit)
        {
            Debug.Log("Ray CAM kena : " + hit.collider.name);
        }
    }
}
