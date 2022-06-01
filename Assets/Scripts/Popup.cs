using System.Collections;
using System.Collections.Generic;
using System;  
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using mspr;

public class Popup : MonoBehaviour
{

	[SerializeField] Button _buttonValidation;
	[SerializeField] Button _buttonClose;
	[SerializeField] InputField _inputFieldName;
	[SerializeField] InputField _inputFieldEmail;
    [SerializeField] Text _textFormErrorMsg;
    public GameObject mainObject;
    private bool _error;
    private Texture2D ss;

    // Start is called before the first frame update
   	void Start()
    {
    _inputFieldName.onEndEdit.AddListener(delegate {checkFormError(); }); 
    _inputFieldEmail.onEndEdit.AddListener(delegate {checkFormError(); }); 
    //_textFormErrorMsg.onEndEdit.AddListener(delegate {OnStoppedEditing(_textFormErrorMsg); }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void checkFormError(){
		if(!FormUtils.validNickname(_inputFieldName.text) && !FormUtils.validEmail(_inputFieldEmail.text) ){
			_textFormErrorMsg.text = "Nom et email invalides"; 
			_error = true;
		}
		else if(!FormUtils.validNickname(_inputFieldName.text) && FormUtils.validEmail(_inputFieldEmail.text) ){
			_textFormErrorMsg.text = "Nom invalide"; 
			_error = true;
		}
		else if(FormUtils.validNickname(_inputFieldName.text) && !FormUtils.validEmail(_inputFieldEmail.text) ){
			_textFormErrorMsg.text = "Email invalide"; 
			_error = true;
		}
		else{
			_textFormErrorMsg.text = ""; 
			_error = false;
		}

	}

    public void Init(Transform canvas){
    	
    	ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	    ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
	    ss.Apply();

    	transform.SetParent(canvas);
		transform.localScale = Vector3.one;
		GetComponent<RectTransform>().offsetMin = Vector2.zero;
		GetComponent<RectTransform>().offsetMax = Vector2.zero;
		
    	_buttonValidation.onClick.AddListener(() => {
    		//Display errors
			checkFormError();
			if(_error){
				return;
			}
			//post method
    		StartCoroutine(RequestUtils.postRequest(_inputFieldName.text, _inputFieldEmail.text));
    		//Partage SNS
    		Share();
    	});

    	_buttonClose.onClick.AddListener(() => {
    		GameObject.Destroy(this.gameObject);
    	});

    }

    public void Share()
	{
		StartCoroutine(TakeScreenShotAndShare());
	}

    private IEnumerator TakeScreenShotAndShare(){
    	
    	yield return new WaitForEndOfFrame();

		mainObject.SetActive(false);
		//new WaitForSeconds(5);

    	string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "share.png");
    	System.IO.File.WriteAllBytes(filePath, ss.EncodeToPNG());

    	Destroy(ss);

    	new NativeShare().AddFile(filePath)
    	.SetSubject(uniqHashtag(_inputFieldName.text)).SetText(uniqHashtag(_inputFieldName.text)).SetUrl("")
    	.SetCallback((res, target) => Debug.Log($"result {res}, target app: {target}"))
    	.Share();

    }

    public string uniqHashtag(string name)
    {
    	    var dateString = DateTime.Now.ToString("dd_MM_yyyy");
    	    var hashtag = '#' + name + '_' + dateString;
    	    return hashtag;
    }
}
