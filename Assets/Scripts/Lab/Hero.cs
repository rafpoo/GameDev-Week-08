using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float minimumY = -60f;
    public float maximumY = 60f;
    private float speedPutar = 5f;

    float rotationX = 0f;
    float rotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * speedPutar;

        rotationX += Input.GetAxis("Mouse Y") * speedPutar;
        rotationX = Mathf.Clamp(rotationX, minimumY, maximumY);

        // perputaran koordinat y camera
        Vector3 rotasiCamera = transform.localEulerAngles;
        rotasiCamera.y = rotationY;
        transform.localEulerAngles = rotasiCamera;

        // perputaran kooredinat x player
        Vector3 rotasiPlayer = transform.Find("Main Camera").localEulerAngles;
        rotasiPlayer.x = -rotationX;
        transform.Find("Main Camera").localEulerAngles = rotasiPlayer;

        // gerakan maju mundur\
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5f);

        // lompat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * 7f;
        }
    }
}
