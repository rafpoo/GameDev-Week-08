using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] AudioSource sumberSuara;
    [SerializeField] AudioClip clipMusik;
    [SerializeField] AudioClip clipMusik2;

    GameObject objCamera;

    // Start is called before the first frame update
    void Start()
    {
        // sumberSuara.clip = clipMusik;
        // sumberSuara.loop = true;
        // sumberSuara.volume = 0.8f;
        // sumberSuara.Play();

        objCamera = transform.Find("Main Camera").gameObject;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubahMusik1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "areaMusuh")
        {
            objCamera.SendMessage("rubahMusik2");
        }
    }

    public void rubahMusik1()
    {
        sumberSuara.Stop();

        sumberSuara.clip = clipMusik2;
        sumberSuara.Play();
    }

    public void rubahMusik2()
    {
        sumberSuara.Stop();

        sumberSuara.clip = clipMusik;
        sumberSuara.Play();
    }
}
