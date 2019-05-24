using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUtilities : MonoBehaviour
{

    public void hidePanel(GameObject panel) {
        panel.SetActive(false);
    }
    public void nextPanel(GameObject panel)
    {
        panel.SetActive(true);   
    }

}
