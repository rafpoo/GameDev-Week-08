using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(h, 0.0f, v);

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * Time.deltaTime * 5.0f, Space.World);
        }
    }
}
