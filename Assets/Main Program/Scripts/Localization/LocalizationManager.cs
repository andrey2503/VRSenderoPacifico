using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{

    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>> localization_text_es <<<<<<<<<<<<<<<<<<<<<");
        SetLanguage("localization_text_es.json");
    }

    public void SetLanguage (string fileName)
	{
		if (Application.platform == RuntimePlatform.WindowsEditor)
			LoadLocalizedText (fileName);
		else if (Application.platform == RuntimePlatform.OSXEditor)
			LoadLocalizedText (fileName);
		else if (Application.platform == RuntimePlatform.Android)
			StartCoroutine ("LoadLocalizedTextOnAndroid", fileName);
	}

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();

        string filePath = Path.Combine (Application.streamingAssetsPath, fileName);


        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
            SceneManager.LoadScene("Penitenciaria");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;
    }

    IEnumerator LoadLocalizedTextOnAndroid (string fileName)
	{
		localizedText = new Dictionary<string, string> ();
		string filePath;// = Path.Combine(Application.streamingAssetsPath, fileName);
		filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
		string dataAsJson;
		if (filePath.Contains ("://") || filePath.Contains (":///")) {
			//debugText.text += System.Environment.NewLine + filePath;
			Debug.Log ("UNITY:" + System.Environment.NewLine + filePath);
			UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get (filePath);
			yield return www.Send ();
			dataAsJson = www.downloadHandler.text;
		} else {
			dataAsJson = File.ReadAllText (filePath);
		}
		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

		for (int i = 0; i < loadedData.items.Length; i++) {
			localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);
			Debug.Log ("KEYS:" + loadedData.items [i].key);
		}

        SceneManager.LoadScene("Penitenciaria");

		isReady = true;
	}


    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}