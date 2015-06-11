/**
 * Filename: SceneSave.cs
 * Author: Aryk Anderson
 * Created: 6/10/2015
 * Revision: 0
 * Rev. Date: 6/10/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace SaveLoad
{
    [System.Serializable]
    public class SceneSave
    {
        private Dictionary<string, SaveData> _objectMap;

        public Dictionary<string, SaveData> ObjectMap
        {
            get
            {
                return _objectMap;
            }

            protected set
            {
                _objectMap = value;
            }
        }

        public SceneSave()
        {

        }


        /**
         * Responsible for finding all the objects in the scene that can be saved and
         * storing their save data in the dictionary of this class to uniquely identify the objects
         * against their savedata
         */ 

        public void TakeSnapshot()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("player");
            GameObject[] doors = GameObject.FindGameObjectsWithTag("door");

            foreach (GameObject wObject in players)
            {
                try
                {
                    string id = wObject.GetComponent<PlayerSaveComponent>().ObjectID();
                    SaveData data = wObject.GetComponent<PlayerSaveComponent>().Save();

                    _objectMap.Add(id, data);
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }

            foreach (GameObject wObject in doors)
            {
                try
                {
                    string id = wObject.GetComponent<DoorSaveComponent>().ObjectID();
                    SaveData data = wObject.GetComponent<DoorSaveComponent>().Save();

                    _objectMap.Add(id, data);
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }


        /**
         * Responsible for finding all objects in the scene and then reloading the data into those objects
         */ 

        public void InstantiateSnapshot()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("player");
            GameObject[] doors = GameObject.FindGameObjectsWithTag("door");

            foreach (GameObject wObject in players)
            {
                try
                {
                    string id = wObject.GetComponent<PlayerSaveComponent>().ObjectID();
                    wObject.GetComponent<PlayerSaveComponent>().Load(_objectMap[id]);
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }

            foreach (GameObject wObject in doors)
            {
                try
                {
                    string id = wObject.GetComponent<DoorSaveComponent>().ObjectID();
                    wObject.GetComponent<PlayerSaveComponent>().Load(_objectMap[id]);
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }
    }
}

