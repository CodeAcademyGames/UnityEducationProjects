using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TMP_Text usernameText;
    [SerializeField] private TMP_InputField usernameInput;

    private void Start()
    {
        Initialize();
    }

    public void OpenSettingsPanel() => settingsPanel.SetActive(true);
    public void CloseSettingsPanel() => settingsPanel.SetActive(false);

    public void ChangeUsername()
    {
        usernameText.text = usernameInput.text;
        ESDataManager.Instance.gameData.username = usernameInput.text;
        ESDataManager.Instance.Save();
    }

    private void Initialize()
    {
        usernameText.text = ESDataManager.Instance.gameData.username;
    }
}