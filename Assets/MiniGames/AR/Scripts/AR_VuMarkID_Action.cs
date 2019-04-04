using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

[System.Serializable]
public class AudioText {
    [TextArea]
    public string texto;
    public AudioClip audioClip;
}

[System.Serializable]
public class ElementObject {
    public string name;
    public string idVumark;
    public GameObject model;
    public AudioText[] audioTexts;
}

public class AR_VuMarkID_Action : MonoBehaviour {
    public ElementObject[] elements;
    public Text title;
    public Text tbody;
    public Button bnext;
    public Button bprevious;
    public Button bplay;
    public Button bstop;
    public AudioSource audioSource;
    public GameObject timeLimitBar;
    public float inactivityLimitSeconds = 45f;

	private int _modelNumber;
    private VuMarkManager _vuMarkManager;
    private int _audioTextIndex;
    private ElementObject _currentElement;
    private float _timeLeft;
    public bool _onActivity = false;

	void Start () {
		_vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
		_vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
		_vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);
        foreach(ElementObject item in elements) {
            item.model.SetActive(false);
        }
        _timeLeft = 0f;
        //StartCoroutine(InactivitySensor());
	}

	void Update () {
        if(!_onActivity) {
            _timeLeft += Time.deltaTime;
        }
        else {
            timeLimitBar.transform.localScale = Vector3.zero;
            _timeLeft = 0f;
        }

        if (_timeLeft > inactivityLimitSeconds) {
            GameControl.instance.ChangeScene(3);
        }
        else {
            timeLimitBar.transform.localScale = new Vector3(_timeLeft / inactivityLimitSeconds, 1f, 1f);
        }
	}

	private string getVuMarkID(VuMarkTarget vuMark) {
		switch (vuMark.InstanceId.DataType){
    		case InstanceIdType.BYTES: return vuMark.InstanceId.HexStringValue;
    		case InstanceIdType.STRING: return vuMark.InstanceId.StringValue;
    		case InstanceIdType.NUMERIC: return vuMark.InstanceId.NumericValue.ToString();
		}
		return null;
	}

	public void onVuMarkDetected(VuMarkTarget target) {
        
        foreach(ElementObject element in elements) {
            if(element.idVumark == getVuMarkID(target)) {
                _onActivity = true;

                _currentElement = element;
                _audioTextIndex = 0;

                _currentElement.model.SetActive(true);
                title.text = _currentElement.name;
                LoadAudioText();

                if(_currentElement.audioTexts.Length == 1) {
                    bnext.gameObject.SetActive(false);
                    bprevious.gameObject.SetActive(false);
                }   
                else {
                    bnext.gameObject.SetActive(true);
                    bprevious.gameObject.SetActive(true);
                }
                break;
            }
        }
	}

	public void onVuMarkLost(VuMarkTarget target){
        foreach (ElementObject element in elements) {
            if (element.idVumark == getVuMarkID(target)) {
                element.model.SetActive(false);
                audioSource.Stop();
                _onActivity = false;
            }
        }
	}

    public void PlayAudio() {
        audioSource.Play();
        bplay.gameObject.SetActive(false);
        bstop.gameObject.SetActive(true);
    }

    public void StopAudio() {
        audioSource.Stop();
        bplay.gameObject.SetActive(true);
        bstop.gameObject.SetActive(false);
    }

    public void NextAudioText() {
        StopAudio();
        _audioTextIndex++;
        if(_currentElement.audioTexts.Length-1 < _audioTextIndex) {
            _audioTextIndex = 0;
        }
        LoadAudioText();
    }

    public void PrevousAudioText() {
        StopAudio();
        _audioTextIndex--;
        if (_currentElement.audioTexts.Length < 0) {
            _audioTextIndex = _currentElement.audioTexts.Length - 1;
        }
        LoadAudioText();
    }

    private void LoadAudioText() {
        tbody.text = _currentElement.audioTexts[_audioTextIndex].texto;
        audioSource.clip = _currentElement.audioTexts[_audioTextIndex].audioClip;
    }
}
