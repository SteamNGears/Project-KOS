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

		public float x = 0;
		public float y = 0;
		public float z = 0;
		public Vector3 PlayerTransform
		{
			get{return new Vector3(x,y,z);}
			set{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}

		}

		public PlayerSaveData(Vector3 transform)
		{
			this.PlayerTransform = transform;
		}
        
    }
}