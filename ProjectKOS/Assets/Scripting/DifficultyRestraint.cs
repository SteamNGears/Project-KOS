/**
 * Filename: DifficultyRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class DifficultyRestraint : Restraint{

        private int _upperBound;
        public DifficultyRestraint(int difficulty)
        {
            Value = "" + difficulty;
            Field = "difficulty";
        }

        public DifficultyRestraint(int lowerBound, int upperBound)
        {
            Value = "" + lowerBound;
            Field = "difficulty";
        }

        public string[] getRange()
        {
            string[] returnString = { Value, "" + _upperBound };
            return returnString;
        }
	}
}
