using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] AudioSource sumberSuara;
    [SerializeField] AudioClip clipMusik;
    [SerializeField] AudioClip clipMusik2;
    [SerializeField] AudioClip footstep;


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

    public void playFootstep()
    {
        sumberSuara.PlayOneShot(footstep, 0.5f);
    }
}
