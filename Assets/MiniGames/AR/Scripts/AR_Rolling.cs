using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Rolling : MonoBehaviour {

    public float speed = 15f;

    public bool rolling = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(rolling)
            this.gameObject.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}

    void StartRoll() {
        rolling = true;
    }

    void StopRoll()
    {
        rolling = false;
    }
}
