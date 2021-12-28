using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCard : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    private bool whileContinue;
    private int currentAddingCount;
    private int childcount;
    private void Start()
    {
        whileContinue = true;
        currentAddingCount = 0;
        childcount = transform.childCount;
        GetRandomCard();
    }
    void GetRandomCard()
    {
        while (whileContinue == true)
        {
            int randomCartIndex = Random.Range(0, transform.childCount - 1);
            if (transform.GetChild(randomCartIndex) != null)
            {
                if (whileContinue == true)
                {
                    transform.GetChild(randomCartIndex).transform.SetParent(Background.transform);
                    currentAddingCount++;
                    if (currentAddingCount == childcount)
                    {
                        whileContinue = false;
                        //Background.GetComponent<GridLayoutGroup>().enabled = false; // bunu pasif ettigimiz için hep bizim ilk siraladigimiz gibi siraliyor
                    }
                }
            }

        }

    }
    
    
}
