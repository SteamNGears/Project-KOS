/**
 * Filename: SaveData.cs
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
    public abstract class SaveData
    {

        public string ObjectID
        {
            get;

            protected set;
        }
    }
}

