/**
 * Filename: DifficultyRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class DifficultyRestraint : Restraint{

        private int _upperBound;
        private int numArgs;
        public DifficultyRestraint(int difficulty)
        {
            Value = "" + difficulty;
            RetraintType = "DIFFICULTY";
            numArgs = 1;
        }

        public DifficultyRestraint(int lowerBound, int upperBound)
        {
            Value = "" + lowerBound;
			_upperBound = upperBound;
            RetraintType = "DIFFICULTY";
            numArgs = 2;
        }

        public override string[] GetRange()
        {
            string[] returnString = { Value, "" + _upperBound };
            return returnString;
        }

        public override int NumArgs()
        {
            return numArgs;
        }
	}
}
