using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEnemyWrite : MonoBehaviour
{
    [SerializeField] Text wordText;

    private void Start()
    {
        wordText.text = gameObject.name;
    }
}
