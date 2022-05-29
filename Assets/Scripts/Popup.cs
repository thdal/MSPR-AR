using System.Collections;
using System.Collections.Generic;
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
    private bool _error;


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
    		Debug.Log(_inputFieldName.text);
			//post method
    		StartCoroutine(RequestUtils.postRequest(_inputFieldName.text, _inputFieldEmail.text));
    	});

    	_buttonClose.onClick.AddListener(() => {
    		GameObject.Destroy(this.gameObject);
    	});

    }
}
