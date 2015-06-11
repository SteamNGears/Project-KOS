using UnityEngine;
using System.Collections;
using States;
using System;

namespace SaveLoad
{
    public class DoorSaveComponent : MonoBehaviour, ISaveable
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
            return null;
        }


        /**
         * Method should save the relevant data to be saved in a SaveData object that
         * can have all of its fields serialized.
         * @returns SaveData
         */

        public SaveData Save()
        {
			Interaction inter = this.gameObject.GetComponent<Interaction> ();
			DoorSaveData save = new DoorSaveData ();
			save.saveState =  DoorSaveData.state.IDLE;

			if(inter != null)
			{
				if(inter.currentState is OpenState)
					save.saveState = DoorSaveData.state.OPEN;
				if(inter.currentState is LockedState)
					save.saveState = DoorSaveData.state.LOCKED;
			}

			return save;
        }


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */

        public void Load(SaveData data)
        {
			DoorSaveData load = (DoorSaveData)data;
			Interaction inter = GetComponent<Interaction> ();

			if (load != null && inter != null) 
			{
				if(load.saveState == DoorSaveData.state.OPEN)
					inter.currentState = new OpeningState(this.gameObject, null);
				else if (load.saveState == DoorSaveData.state.LOCKED)
				         inter.currentState = new OpeningState(this.gameObject, null);
				else
					inter.currentState = new InteractButtonState(this.gameObject, null);
			}
        }
    }
}
