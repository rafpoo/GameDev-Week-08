using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Camera cam;
    public float shootDistance = 100f;
    public float damage = 20f;
    public LayerMask zombieLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootDistance, zombieLayer))
        {
            Debug.Log("Kena: " + hit.collider.name);

            ZombieHealth zh = hit.collider.GetComponent<ZombieHealth>();
            if (zh != null)
            {
                zh.TakeDamage(damage);
            }
        }
    }
}
