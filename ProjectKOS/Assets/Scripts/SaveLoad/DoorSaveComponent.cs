/**
 * Filename: DoorSaveComponent.cs
 * Author: Jakob Wilson
 * Created: 6/7/2015
 * Revision: 1
 * Rev. Date: 7/20/2015
 * Rev. Author: Jakob Wilson
 * */

using UnityEngine;
using System.Collections;
using States;
using System;

namespace SaveLoad
{
    public class DoorSaveComponent : MonoBehaviour, ISaveable
    {
		/**
		 * Subscribes to the save event and checks if load data is present
		 * if there is load data, then it initialized the object with that data
		 * */
        public void Start()
        {
            SaveLoadManager.Instance.SaveObject += this.SaveObject;

			SaveData s = SaveLoadManager.Instance.GetSaveData (this.ObjectID());

			if (!(s is NullSaveData)) {
				this.Load(s);
				SaveLoadManager.Instance.RemoveSaveData(this.ObjectID());
			}
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
            return this.gameObject.name;
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
			Door door = GetComponent<Door> ();

			if (load != null && inter != null) 
			{
				if(load.saveState == DoorSaveData.state.OPEN)
				{
					inter.startingState = new OpeningState(this.gameObject, null);
					inter.currentState = new OpeningState(this.gameObject, null);
					door.currentState = Door.DoorState.OPEN;
				}
				else if (load.saveState == DoorSaveData.state.LOCKED)
				{
					inter.startingState = new OpeningState(this.gameObject, null);
				    inter.currentState = new LockingState(this.gameObject, null);
					door.currentState = Door.DoorState.LOCKED;
				}
				else
				{
					inter.startingState = new InteractButtonState(this.gameObject, null);
					inter.currentState = new InteractButtonState(this.gameObject, null);
					door.currentState = Door.DoorState.IDLE;
				}
				inter.currentState.Behave();
			}
        }
    }
}
