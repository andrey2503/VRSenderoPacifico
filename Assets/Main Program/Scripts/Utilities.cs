using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Utilities : MonoBehaviour {
	public bool startVuforia;

	void Start() {
		if (startVuforia) {
            if(VuforiaBehaviour.Instance != null) VuforiaBehaviour.Instance.enabled = true;
		} else {
            if (VuforiaBehaviour.Instance != null) VuforiaBehaviour.Instance.enabled = false;
		}
	}


    public void ChangeScene(int scene) {
        GameControl.instance.ChangeScene(scene);
    }
}
