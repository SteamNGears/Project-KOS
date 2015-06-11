/**
 * Filename: DoorSaveData.cs
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
    
	public class DoorSaveData : SaveData
    {
		public enum state{LOCKED, OPEN, IDLE};
		public state saveState;
    }
}