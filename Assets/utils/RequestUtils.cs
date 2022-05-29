using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using UnityEngine.Networking;

namespace mspr
{

	public class RequestUtils : MonoBehaviour
	{	    

		private static string url = "https://us-central1-cerealis-a705c.cloudfunctions.net/newUsers";


		public static IEnumerator postRequest(string name, string email)
		{
		    var bodyJsonString = "{\"firstname\": " + "\"" + name + "\"" + ", \"email\": " + "\"" + email + "\"" + "}";
		    var request = new UnityWebRequest(url, "POST");
	        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
	        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
	        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
	        request.SetRequestHeader("Content-Type", "application/json");
	        yield return request.SendWebRequest();
	        Debug.Log("Status Code: " + request.responseCode);
		}

	}

	public class User
    {
       public string Name { get; set; }
       public string Email { get; set; }
       public User(string name, string email)
       {
           Name = name;
           Email = email;
       }
       public void GetUserDetails()
       {
           Debug.Log("Name: " + Name +  "Email: " + Email);
       }
    }
}
