using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace mspr
{

	public class FormUtils : MonoBehaviour
	{

	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }

	    // Update is called once per frame
	    void Update()
	    {
	        
	    }

	    //Check the validity of nickname before sending it to API
	    //Return boolean true or false
	    public static bool validNickname(string nickname)
	    {
	    	if(nickname == null || nickname == ""){
	    		return false;
	    	}
	    	return true;
	    }

		//Check the validity of email before sending it to API
	    //Return boolean true or false
	    public static bool validEmail(string email)
	    {
	    	Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
	    	Match match = regex.Match(email);

	    	if(email == null || email == "" || !match.Success)
	    	{
	    		return false;
	    	}
	    	return true;

	    }
	}

}