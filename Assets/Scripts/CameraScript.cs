using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] AudioSource sumberSuara;
    [SerializeField] AudioClip clipMusik;

    // Start is called before the first frame update
    void Start()
    {
        sumberSuara.clip = clipMusik;
        sumberSuara.loop = true;
        sumberSuara.volume = 0.8f;
        sumberSuara.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
