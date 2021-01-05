using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class CustomButtonController : MonoBehaviour
{
    public Text sourceText;
    public Color normalColor;
    public Color selectedColor;
    public CustomButton[] buttons;

    private void Start()
    {
        SelectButton(0);
    }

    public void SelectButton(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].button.GetComponent<ProceduralImage>().borderWidth = 3;
            buttons[i].button.GetComponent<ProceduralImage>().color = normalColor;
        }

        buttons[index].button.GetComponent<ProceduralImage>().borderWidth = 0;
        buttons[index].button.GetComponent<ProceduralImage>().color = selectedColor;

        if (sourceText != null)
        {
            sourceText.gameObject.SetActive(true);
            sourceText.text = buttons[index].buttonDescription;
        }
    }

    
}

[System.Serializable]
public class CustomButton
{
    public Button button;
    public string buttonDescription;
}