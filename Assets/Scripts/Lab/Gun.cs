using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] objWeapon;
    private int senjataAktif = 0;
    // Start is called before the first frame update
    void Start()
    {
        gantiSenjata(0);
    }

    private void gantiSenjata(int noSenjata)
    {
        if (transform.Find("senjataAktif") != null)
        {
            Destroy(transform.Find("senjataAktif").gameObject);
        }
        GameObject playerWeapon = Instantiate(
            objWeapon[noSenjata],
            transform.position,
            transform.rotation) as GameObject;

        playerWeapon.transform.SetParent(transform);
        playerWeapon.name = "senjataAktif";
        senjataAktif = noSenjata;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gantiSenjata(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gantiSenjata(1);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (senjataAktif == 0)
            {
                gantiSenjata(1);
            }
            else
            {
                gantiSenjata(0);
            }
        }
    }
}
