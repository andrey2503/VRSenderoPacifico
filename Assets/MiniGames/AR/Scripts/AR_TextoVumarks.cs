using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_TextoVumarks : MonoBehaviour {
    public GameObject[] texts;
	public GameObject textPanel, derecha, izquierda;
    public int actualText;
	public AR_Play_Audio audioHelp;

	public void NextPrevText(int nextPrevNum) {
		audioHelp.StopAudio ();
		actualText += nextPrevNum;
		Debug.Log("Actual Text: " + actualText);
		audioHelp.IdentifyAudioTxt (actualText);

		ValidateRightLeftActive ();
		ShowText ();

		Debug.Log("Actual Final: " + actualText);

	}

	private void ValidateRightLeftActive() {
		if (actualText <= 0) {
			izquierda.SetActive(false);
			derecha.SetActive (true);
			actualText = 0;
		}

		else if (actualText >= texts.Length-1) {
			actualText = texts.Length-1;
			derecha.SetActive (false);
			izquierda.SetActive(true);
		}
		else {
			izquierda.SetActive (true);
			derecha.SetActive (true);
		}

	}

	private void ShowText() {	
		for (int i = 0; i < texts.Length; i++) {
			if (actualText == i){
				texts[i].SetActive(true);
			}
			else {
				texts[i].SetActive(false);
			}

		}
	}

    private void OnEnable()
    {
        textPanel.SetActive(true);
        actualText = 0;
        audioHelp.IdentifyAudioTxt(actualText);
        texts[0].SetActive(true);
        izquierda.SetActive(false);
        if (texts.Length == 1) {
            derecha.SetActive(false);
            izquierda.SetActive(false);

        }
    }

    private void OnDisable() {
        actualText = 0;
		audioHelp.IdentifyAudioTxt (actualText);
        StopAllCoroutines();
    }
}
