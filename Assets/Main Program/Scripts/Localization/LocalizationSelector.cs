using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLocalizationFile(string text)
    {
        LocalizationManager.instance.LoadLocalizedText(text);
    }
}
