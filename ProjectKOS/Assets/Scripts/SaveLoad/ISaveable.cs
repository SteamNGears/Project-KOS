/**
 * Filename: ISaveable.cs
 * Author: Aryk Anderson
 * Created: 6/7/2015
 * Revision: 1
 * Rev. Date: 6/9/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;

namespace SaveLoad
{
    public interface ISaveable
    {
        /**
         * Method should return a unique object ID for the object to be saved
         * @returns string ID
         */ 

        string ObjectID();


        /**
         * Method should save the relevant data to be saved in a SaveData object that
         * can have all of its fields serialized.
         * @returns SaveData
         */ 

        SaveData Save();


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */ 

        void Load(SaveData data);
    }
}

