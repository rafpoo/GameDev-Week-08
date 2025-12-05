using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("txtScore").GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.skor.ToString();
        GameObject.Find("txtHealth").GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.darah.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
