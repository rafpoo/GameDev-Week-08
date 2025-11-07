using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    GameObject objCamera;

    private AudioSource sfxFootstepSource;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        objCamera = transform.Find("Main Camera").gameObject;
        sfxFootstepSource = GameObject.Find("sfxFootstep").gameObject.GetComponent<AudioSource>();
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

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v) * Time.deltaTime * 3f);
        transform.Rotate(new Vector3(0, h, 0) * 10f);

        if (h != 0 || v != 0)
        {
            if (!isMoving)
            {
                isMoving = true;
                sfxFootstepSource.Play();
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                sfxFootstepSource.Stop();
            }
        }
    }
}
