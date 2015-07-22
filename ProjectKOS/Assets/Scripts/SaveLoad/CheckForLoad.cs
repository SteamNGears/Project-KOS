/**
 * Filename: CheckForLoad.cs
 * Author: Jakob Wilson
 * Created: 6/20/2015
 * Revision: 1
 * Rev. Date: 7/20/2015
 * Rev. Author: Jakob Wilson
 * */


using UnityEngine;
using System.Collections;
using SaveLoad;

/**
 * CheckForLoad waits until the scene is loaded, then checks
 * if any load data was specified. If so, then the loaddata is used
 * else, defaults(new level) are used
 * */
public class CheckForLoad : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	/**
	 * Checks if load data is present, and if so, loads that level data
	 * */
	void OnLevelWasLoaded(int level)
	{

	}
}
