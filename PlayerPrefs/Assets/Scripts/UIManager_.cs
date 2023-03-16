using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class UIManager_ : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerInputText;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TMP_InputField _playerInput;
    //setquality qraifk ayarlaari
    //private CustomPlayerPrefs _playerPrefsInstance;
    [SerializeField] private GameObject EnterNamePanel;
    [SerializeField] private GameObject WelcomePanel;

    [SerializeField] private Toggle _checkBox;
    private void Start()
    {
        // Check to see if the key exists in the Player Prefs file
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            OpenWelcomePanel();
            GetName();
        }

    }
    public void SetName()
    {
        //To set data
        //First variable is reference name of saved data, second variable is string value or what type you want to save.
        PlayerPrefs.SetString("PlayerName", _playerInput.text);

        // If the game crashes, or is forced to close unexpectedly, you may lose any changes that were made.
        // Save function, which will manually write all Player Prefs changes to disk when it’s called. This can cause a slight pause, so it’s generally a good idea to only use the Save function occasionally and when it makes the most sense to do so.
        PlayerPrefs.Save();
    }
    public void GetName()
    {
        //To get data
        //You can get saved data by calling its referenc name
        _playerName.text = "Welcome, " + PlayerPrefs.GetString("PlayerName") + "!";
    }
    public void DeleteName()
    {
        //To delete data
        //You can delete spesific saved data by calling it reference name
        PlayerPrefs.DeleteKey("PlayerName");

        _playerInput.text = null;
        _checkBox.isOn = false;

        //To delete all created keys
        PlayerPrefs.DeleteAll();

    }
    public void OpenWelcomePanel()
    {
        // int acceptedCookies = _checkBox.isOn ? 1 : 0;
        // To save boolen variable by using integer. Convert it to 1 if condition is true, 0 if false
        PlayerPrefs.SetInt("acceptedCookies", _checkBox.isOn ? 1 : 0);
        if (PlayerPrefs.GetInt("acceptedCookies") == 1)
        {
            EnterNamePanel.SetActive(false);
            WelcomePanel.SetActive(true);
        }
    }
    public void OpenEnterNamePanel()
    {
        EnterNamePanel.SetActive(true);
        WelcomePanel.SetActive(false);
    }

    #region MultipleSlots
    //This allows you to save and load different versions of the same data, without changing the key.
    //For example when logging into a computer with a different account.

    //public int slot;
    //public float sfxVolume;
    //public float musicVolume;
    //public float dialogueVolume;
    //public void LoadSettings()
    //{
    //    sfxVolume = PlayerPrefs.GetFloat("sfxVolume" + slot);
    //    musicVolume = PlayerPrefs.GetFloat("musicVolume" + slot);
    //    dialogueVolume = PlayerPrefs.GetFloat("dialogueVolume" + slot);
    //}
    //public void SaveSettings()
    //{
    //    PlayerPrefs.SetFloat("sfxVolume" + slot, sfxVolume);
    //    PlayerPrefs.SetFloat("musicVolume" + slot, musicVolume);
    //    PlayerPrefs.SetFloat("dialogueVolume" + slot, dialogueVolume);
    //}
    #endregion

    #region PlayerPref files location
    // Player Prefs location(working in the editor)
    //MacOS: /Library/Preferences/unity.Company.Project.plist
    //Windows(in the Registry): HKCU\Software\Unity\UnityEditor\Company\Project
    //Player Prefs location(in the finished game)
    //MacOS: ~/Library/Preferences/com.Company.Project.plist
    //Windows(in the Registry): HKCU\Software\Company\Project
    //Windows Store Apps: %userprofile%\AppData\Local\Packages\ProductPackageId\LocalState\playerprefs.dat
    //Linux: ~/.config/unity3d/Company/Product
    //Android: /data/data/pkg-name/shared_prefs/pkg-name.v2.playerprefs.xml
    //iOS: /Library/Preferences/BundleIdentifier.plist
    #endregion
}
