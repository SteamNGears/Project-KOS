using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {


	private Button ok; 
	// Use this for initialization
	void Start () {
		ok = this.GetComponentInChildren<Button>();
		ok.onClick.AddListener (this.OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		ok.onClick.RemoveListener (this.OnClick);
		Application.LoadLevel ("mainScene");
	}
}
