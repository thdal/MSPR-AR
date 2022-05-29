using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShareButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                    Debug.Log("testons le script");

        Button button = GameObject.Find("Button_Share").GetComponent<Button>();
		button.onClick.AddListener(() => {
        	Debug.Log("testons le click");
        	Popup popup = UIController.Instance.CreatePopup();
            popup.Init(UIController.Instance.MainCanvas);
        });
    }

}
