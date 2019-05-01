using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUtilities : MonoBehaviour
{
    
    public GameObject panel0;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;


    public void hidePanel(GameObject panel) {
        panel.SetActive(false);
    }
    public void nextPanel(GameObject panel)
    {
        panel.SetActive(true);   
    }

}
