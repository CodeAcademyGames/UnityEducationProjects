using UnityEngine;

public class ESDataManager : MonoBehaviour
{
    private static ESDataManager _instance;

    public static ESDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ESDataManager>();
            }

            return _instance;
        }
    }

    private const string DataKey = "gameData";

    [SerializeField] public GameData gameData;
   
    private void Awake()
    {
        Load();
    }
    public void Load()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists(DataKey)) gameData = ES3.Load(DataKey, gameData);
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        ES3.Save(DataKey, gameData);
    }
}