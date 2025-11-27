using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 posPintuAwal;
    Vector3 posPintuBuka;
    GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        posPintuAwal = transform.position;

        posPintuBuka = posPintuAwal;
        posPintuBuka.x += 3;

        hero = GameObject.Find("hero");
    }

    // Update is called once per frame
    void Update()
    {
        float jarakHero = Vector3.Distance(
            hero.transform.position,
            transform.position
        );

        if (jarakHero < 3)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                posPintuBuka,
                Time.deltaTime
            );
        }

        if (jarakHero > 5)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                posPintuAwal,
                Time.deltaTime
            );
        }
    }
}
