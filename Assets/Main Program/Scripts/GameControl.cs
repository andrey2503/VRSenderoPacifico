using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class UnlockedElements {
    public string name;
    public int status;
}


[System.Serializable]
public class MyScenes{ 
	public string namescenes;
	public bool requireVuforia;
}

public class GameControl : MonoBehaviour {

    public static GameControl instance = null;


	public MyScenes[] myScenes;

    private List<UnlockedElements> _unlokedElements;

    void Awake() {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		if(VuforiaBehaviour.Instance != null) VuforiaBehaviour.Instance.enabled = false;
	}

	void Update () {
		
	}

    public void ChangeScene(int sceneNumber) {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene(myScenes[sceneNumber].namescenes);
		//VuforiaBehaviour.Instance.enabled = myScenes[sceneNumber].requireVuforia;
    }

    public void ChangeSceneByName(string sceneName) {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene(sceneName);
		//VuforiaBehaviour.Instance.enabled = myScenes[sceneNumber].requireVuforia;
    }

    public void WriteData() {

    }

    public void ReadData() {

    }
}
