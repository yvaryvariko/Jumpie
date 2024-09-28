using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ForceIndicator : MonoBehaviour
{

    public Image forceIndicatorImg;
    public Controller characterController;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        forceIndicatorImg.fillAmount = characterController.jumpForce;
    }
}
