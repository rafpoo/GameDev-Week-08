using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int skor;
    public int darah;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TambahSkor(int nilai)
    {
        skor += nilai;
    }

    public void UpdateDarah(int damage, bool isBoss = false)
    {
        if (isBoss)
        {
            darah -= damage * 2;
        }
        else
        {
            darah -= damage;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("LecScene2");
        }
    }
}
