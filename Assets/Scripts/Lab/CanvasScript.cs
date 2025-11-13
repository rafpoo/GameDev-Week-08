using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    GameObject TeksJudul;
    GameObject PlayButton;
    GameObject OptionButton;
    // Start is called before the first frame update
    void Start()
    {
        TeksJudul = transform.Find("Panel").Find("bground").Find("txtJudul").gameObject;
        PlayButton = transform.Find("Panel").Find("bground").Find("btnPlay").gameObject;
        OptionButton = transform.Find("Panel").Find("bground").Find("btnExit").gameObject;

        iTween.MoveFrom(TeksJudul, iTween.Hash("y", 1000, "time", 2f, "delay", 0f, "easeType", "easeOutBounce"));
        iTween.ScaleFrom(PlayButton, iTween.Hash("x", 0, "y", 0, "time", 2f, "delay", 1f, "easeType", "easeOutQuart"));
        iTween.MoveFrom(OptionButton, iTween.Hash("x", -1000, "time", 2f, "delay", 2f, "easeType", "easeOutExpo", "oncomplete", "selesaianim", "oncompletetarget", gameObject));
    }

    void selesaianim()
    {
        Debug.Log("selesai sudah animasinya");
        transform.Find("Panel").Find("bground").GetComponent<Image>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
