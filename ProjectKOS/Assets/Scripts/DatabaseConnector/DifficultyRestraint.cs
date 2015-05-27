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

    /**
     * Class represents a filter to questions based on the difficutly of the question
     * @see Restraint
     * @author Aryk Anderson
     */
 
	public class DifficultyRestraint : Restraint{

        private int _upperBound;
        private int numArgs;


        /**
         * Constructor that takes a single difficulty for the restraint
         * @returns DifficultyRestraint
         */
        
        public DifficultyRestraint(int difficulty)
        {
            Value = "" + difficulty;
            RetraintType = "DIFFICULTY";
            numArgs = 1;
        }


        /**
         * Constructor that takes two values to provide an upper and lower bound
         * @returns DifficultyRestraint
         */
        
        public DifficultyRestraint(int lowerBound, int upperBound)
        {
            Value = "" + lowerBound;
			_upperBound = upperBound;
            RetraintType = "DIFFICULTY";
            numArgs = 2;
        }


        /**
         * Implementation of parent method to return a list of the values the restraint is tracking
         * @returns string[]
         */
        
        public override string[] GetRange()
        {
            string[] returnString = { Value, "" + _upperBound };
            return returnString;
        }


        /**
         * Implementation of parent method to return number of armguments restraint is tracking
         * @returns int
         */
        
        public override int NumArgs()
        {
            return numArgs;
        }
	}
}
