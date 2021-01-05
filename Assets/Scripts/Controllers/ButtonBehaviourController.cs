using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class ButtonBehaviourController : MonoBehaviour
{

    public ProceduralImage[] dashBoardItems;
    public ProceduralImage[] transactionTypetems;

    public Color selectedColor;
    public Color normalColor;

    private void Start()
    {
        ChangeToFilterColor(transactionTypetems, transactionTypetems[0]);
    }

    public void ChangeDashBoardElement(ProceduralImage image)
    {
        ChangeToFilterColor(dashBoardItems, image);
    }

    public void ChangeTransactinTypeElement(ProceduralImage image)
    {
        ChangeToFilterColor(transactionTypetems, image);
    }

    public void ChangeToFilterColor(ProceduralImage[] arr,ProceduralImage image)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BorderWidth = 3;
            arr[i].color = normalColor;
        }

        image.BorderWidth = 0;
        image.color = selectedColor;
    }
}
