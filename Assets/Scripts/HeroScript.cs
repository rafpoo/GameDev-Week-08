using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    float panjangRay = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, 0, v) * 3f * Time.deltaTime);
        transform.Rotate(new Vector3(0, h, 0));

        Ray ray = new Ray(
            transform.position,
            transform.forward
        );

        Debug.DrawRay(
            transform.position,
            transform.forward * panjangRay,
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
