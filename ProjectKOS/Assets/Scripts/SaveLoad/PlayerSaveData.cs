/**
 * Filename: PlayerSaveData.cs
 * Author: Aryk Anderson
 * Created: 6/10/2015
 * Revision: 0
 * Rev. Date: 6/10/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;

namespace SaveLoad
{
    [System.Serializable]
    public class PlayerSaveData : SaveData
    {
		public Transform PlayerTransform 
		{
			get;
			private set;
		}

		public PlayerSaveData(Transform transform)
		{
			this.PlayerTransform = transform;
		}
        
    }
}