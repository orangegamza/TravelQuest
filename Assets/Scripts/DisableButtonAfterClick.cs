using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtonAfterClick : MonoBehaviour {

    public void BtnOnClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
}
