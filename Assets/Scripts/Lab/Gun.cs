using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] objWeapon;
    private int senjataAktif = 0;
    public GameObject[] objMuzzleFlash;
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

        // menembak
        if (Input.GetMouseButton(0))
        {
            shakingShootingAndFlash();
        }

        // Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("FpsCharacterPrefab")
                .GetComponent<Animator>()
                .SetBool("reloading", true);

            Invoke("selesaiReload", 0.5f);
        }
    }

    void selesaiReload()
    {
        GameObject.Find("FpsCharacterPrefab")
            .GetComponent<Animator>()
            .SetBool("reloading", false);
    }

    void shakingShootingAndFlash()
    {
        Vector3 pos = GameObject.Find("Player").transform.position;
        pos.x -= (Random.value - 0.5f) * 0.5f;
        pos.y -= (Random.value - 0.5f) * 0.5f;
        pos.z -= 0.05f;
        GameObject.Find("Player").transform.position = pos;

        // Flash saat menembak
        int randFlash = Random.Range(0, objMuzzleFlash.Length);

        Vector3 posFlash = GameObject.Find("tempatFlash").transform.position;
        GameObject objFlash = Instantiate(
            objMuzzleFlash[randFlash],
            posFlash,
            transform.rotation
        ) as GameObject;

        objFlash.transform.parent = GameObject.Find("tempatFlash").transform;
        Destroy(objFlash, 0.1f);
    }
}
