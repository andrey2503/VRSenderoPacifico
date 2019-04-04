using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class AR_PlayVideo : MonoBehaviour {

	public VideoPlayer targetVideo;

	void OnEnable() {
		targetVideo.Play ();
	}
	void OnDisable()
	{
		targetVideo.Stop ();
	}
}
