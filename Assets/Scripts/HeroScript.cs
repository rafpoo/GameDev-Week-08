using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    float panjangRay = 10f;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("target1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, 0, v) * 3f * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0));

        Vector3 arahTarget = target.position - transform.position;
        Ray ray = new Ray(
            transform.position,
            arahTarget
        );

        Debug.DrawRay(
            transform.position,
            arahTarget * panjangRay,
            Color.red
        );

        RaycastHit hit;
        bool isRayHit = Physics.Raycast(ray, out hit, panjangRay);
        if (isRayHit)
        {
            Debug.Log("Ray kena: " + hit.collider.name);
        }
    }
}
