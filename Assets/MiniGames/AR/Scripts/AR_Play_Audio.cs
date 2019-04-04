using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Play_Audio : MonoBehaviour {

	public AudioSource[] audioTexts;
	public GameObject playButton, stopButton;
	private int currAudio;
    public GameObject AnimatedObject1;
    public GameObject AnimatedObject2;

    private void OnEnable()
	{
		playButton.SetActive (true);
		stopButton.SetActive (false);

	}

	public void PlayAudio(){
		audioTexts [currAudio].Play ();
		playButton.SetActive (false);
		stopButton.SetActive (true);

        if (AnimatedObject1 != null) AnimatedObject1.SendMessage("StartRoll");
        if (AnimatedObject2 != null) AnimatedObject2.SendMessage("StartRoll");
    }

	public void StopAudio(){
		audioTexts [currAudio].Stop ();
		playButton.SetActive (true);
		stopButton.SetActive (false);

        if (AnimatedObject1 != null) AnimatedObject1.SendMessage("StopRoll");
        if (AnimatedObject2 != null) AnimatedObject2.SendMessage("StopRoll");
    }

	public void IdentifyAudioTxt(int actualInt){
		currAudio = actualInt;
	}

}
