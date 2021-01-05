using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    public GameObject[] panels;
    public Text sourceText;

    public void EnabeDisablePanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        panels[index].SetActive(true);
    }

    public void EnabeDisablePanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        sourceText.gameObject.SetActive(false);

    }
}
