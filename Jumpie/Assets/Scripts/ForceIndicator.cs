using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ForceIndicator : MonoBehaviour
{

    public Image forceIndicatorImg;
    [SerializeField] private Controller characterController;

    void Update()
    {
        
        forceIndicatorImg.fillAmount = characterController.jumpForce;
    }
}
