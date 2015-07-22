using UnityEngine;
using System.Collections;
using Database;
using SaveLoad;

public class SaveTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
        QuestionPool testPool = DatabaseConnector.Instance.GetQuestions(new QuestionQuery());

        SaveLoadManager.Instance.SaveObject += testPool.SaveObject;

        string savePath = SaveLoadManager.Instance.SaveGame();
        Debug.Log(savePath);

		SaveLoadManager.Instance.LoadGame(savePath);
	}
}
