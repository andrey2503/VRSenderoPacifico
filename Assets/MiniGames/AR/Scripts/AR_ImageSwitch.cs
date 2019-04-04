using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AR_ImageSwitch : MonoBehaviour {

    public Image[] imageElements;
    private float timer;
    private int currentIndex;

	// Use this for initialization
	void Start () {
        timer = 0f;
        currentIndex = 0;
        StartCoroutine(ImageRotator());
	}
	
    private IEnumerator ImageRotator() {
        yield return new WaitForSeconds(0.5f);
        while(true) {
            imageElements[currentIndex].DOFade(1f, 1f);
            yield return new WaitForSeconds(3f);
            imageElements[currentIndex].DOFade(0f, 1f);
            yield return new WaitForSeconds(1.5f);
            currentIndex++;
            if(currentIndex >= imageElements.Length) {
                currentIndex = 0;
            }
        }
    }
}
