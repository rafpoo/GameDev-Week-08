using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    GameObject objTeksScore;
    GameObject objTeksHealth;
    // Start is called before the first frame update
    private void Start()
    {
        objTeksScore = GameObject.Find("txtScore");
        objTeksHealth = GameObject.Find("txtHealth");
    }

    public void PukulMusuh()
    {
        GameManager.Instance.TambahSkor(10);
        objTeksScore.GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.skor.ToString();
    }

    public void KenaMusuh()
    {
        GameManager.Instance.UpdateDarah(10, false);
        objTeksHealth.GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.darah.ToString();
    }

    public void KenaBoss()
    {
        GameManager.Instance.UpdateDarah(10, true);
        objTeksHealth.GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.darah.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
