using UnityEngine;
using System.Collections;

namespace SaveLoad
{
    public class PlayerSaveComponent : MonoBehaviour, ISaveable
    {

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
            return null;
        }


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */

        public void Load(SaveData data)
        {

        }
    }
}
