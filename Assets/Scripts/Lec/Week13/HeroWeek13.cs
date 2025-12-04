using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeek13 : MonoBehaviour
{
    Animator anim;
    GameObject cam;
    float panjangRay = 10f;
    float rotasiVertikal = 0;
    Canvas cvsCrosshair;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");

        cam.transform.position = transform.Find("ObjSorot").position;

        cvsCrosshair = GameObject.Find("CanvasCrosshair").GetComponent<Canvas>();
        cvsCrosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //putaran horizontal hero
        float rotasiHorisontal = Input.GetAxis("Mouse X") * 2f + transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(0, rotasiHorisontal, 0);

        // gerakan position
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime);

        if (h != 0 || v != 0)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("IsAim", true);
            cam.transform.position = transform.Find("AimSorot").position;
            cvsCrosshair.enabled = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("IsAim", false);
            cam.transform.position = transform.Find("ObjSorot").position;
            cvsCrosshair.enabled = false;
        }

        if (anim.GetBool("IsAim") == true)
        {
            // putaran vertikal camera
            rotasiVertikal += Input.GetAxis("Mouse Y") * 2f;
            rotasiVertikal = Mathf.Clamp(rotasiVertikal, -30, 30);

            Camera.main.transform.localEulerAngles = new Vector3(-rotasiVertikal, 0, 0);

            // // raycastingh
            // Ray ray = new Ray(Camera.main.transform.position, transform.forward);
            // Debug.DrawRay(Camera.main.transform.position, transform.forward * panjangRay, Color.red);

            // RaycastHit hit;
            // bool isRayHit = Physics.Raycast(ray, out hit, panjangRay);
            // if (isRayHit)
            // {
            //     Debug.Log("Kena: " + hit.collider.tag);
            //     if (hit.collider.tag == "enemy")
            //     {
            //         if (Input.GetMouseButtonDown(0))
            //         {
            //             hit.collider.SendMessage("MusuhKena");
            //         }
            //     }
            // }
        }
    }
}
