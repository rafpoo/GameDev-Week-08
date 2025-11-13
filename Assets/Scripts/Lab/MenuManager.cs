using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionPanel;
    public TextMeshProUGUI soundButtonText;
    public TextMeshProUGUI musicButtonText;

    private bool isSoundOn = true;
    private bool isMusicOn = true;
    private RectTransform mainRect;
    private Vector2 mainStartPos;

    void Start()
    {
        mainRect = mainPanel.GetComponent<RectTransform>();
        mainStartPos = mainRect.anchoredPosition;

        mainPanel.SetActive(true);
        optionPanel.SetActive(false);

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        soundButtonText.text = isSoundOn ? "On" : "Off";
        musicButtonText.text = isMusicOn ? "On" : "Off";
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        UpdateButtonText();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        UpdateButtonText();
    }

    public void OpenOptionMenu()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", mainStartPos.x,
            "to", mainStartPos.x - 2000,
            "time", 0.7f,
            "easeType", "easeInBack",
            "onupdate", "UpdateMainPanelPos",
            "oncomplete", "ShowOptions"
        ));
    }

    public void ShowOptions()
    {
        mainPanel.SetActive(false);
        optionPanel.SetActive(true);

        RectTransform optionRect = optionPanel.GetComponent<RectTransform>();
        optionRect.localScale = Vector3.zero;

        iTween.ScaleTo(optionPanel, iTween.Hash(
            "scale", Vector3.one,
            "time", 0.7f,
            "easeType", "easeOutElastic"
        ));
    }

    public void BackToMainMenu()
    {
        Debug.Log("Kembali ke menu utama");
        // Tutup animasi optionPanel
        iTween.ScaleTo(optionPanel, iTween.Hash(
            "scale", Vector3.zero,
            "time", 0.6f,
            "easeType", "easeInBack",
            "oncomplete", "StartShowMain",
            "oncompletetarget", gameObject
        ));
    }

    void StartShowMain()
    {
        Debug.Log("Tutup opsi selesai");
        // Baru matikan option panel setelah animasi tutup selesai
        optionPanel.SetActive(false);
        mainPanel.SetActive(true);

        // Geser mainPanel kembali ke posisi semula
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", mainRect.anchoredPosition.x - 2000,
            "to", mainStartPos.x,
            "time", 0.7f,
            "easeType", "easeOutBack",
            "onupdate", "UpdateMainPanelPos",
            "oncomplete", "OnMainPanelShown"
        ));
    }

    void OnMainPanelShown()
    {
        // Kalau kamu mau, bisa tambahkan efek atau log di sini
        Debug.Log("Main menu aktif kembali!");
    }

    void UpdateMainPanelPos(float value)
    {
        mainRect.anchoredPosition = new Vector2(value, mainStartPos.y);
    }

    public void PlayGame()
    {
        iTween.ScaleTo(mainPanel, iTween.Hash(
            "scale", Vector3.zero,
            "time", 0.5f,
            "easeType", "easeInBack",
            "oncomplete", "LoadGameScene"
        ));

        SceneManager.LoadScene("ThirdScene");
    }
}
