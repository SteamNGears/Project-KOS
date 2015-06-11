using UnityEngine;
using System.Collections;
using System;

namespace SaveLoad
{
    public class PlayerSaveComponent : MonoBehaviour, ISaveable
    {
        public void OnLevelWasLoaded()
        {
            SaveLoadManager.Instance.SaveObject += this.SaveObject;
            SaveLoadManager.Instance.LoadObject += this.LoadObject;
        }

        
        /**
         * Event method to saved data and re-instantiate it
         */

        public void LoadObject()
        {
            try
            {
                this.Load(SaveLoadManager.Instance.GetSaveData(this.ObjectID()));
            }

            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }


        /**
         * Event method to add the data for the object to the SaveLoadManager
         */

        public void SaveObject()
        {
            try
            {
                SaveLoadManager.Instance.AddSaveData(this.ObjectID(), this.Save());
            }

            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }


        /**
        * Method should return a unique object ID for the object to be saved
        * @returns string ID
        */

        public string ObjectID()
        {
            return "player";
        }


        /**
         * Method should save the relevant data to be saved in a SaveData object that
         * can have all of its fields serialized.
         * @returns SaveData
         */

        public SaveData Save()
        {
			return new PlayerSaveData (this.GetComponent<Transform> ());
        }


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */

        public void Load(SaveData data)
        {
			try
			{
				PlayerSaveData player = (PlayerSaveData) data;

				this.GetComponent<Transform>().position = player.PlayerTransform.position;
				this.GetComponent<Transform>().rotation = player.PlayerTransform.rotation;
			}

			catch (System.InvalidCastException e) 
			{
				Debug.Log (e.Message);
			}
        }
    }
}