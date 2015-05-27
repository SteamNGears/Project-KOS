/**
 * Filename: QuestionQuery.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;

namespace Database {

    /**
     * Object encapsulates a list of filters to apply against the database to select questions
     * Restraints of the same type represent an OR operation (E.G. a TypeRestraint of MultiChoice and
     * a TypeRestraint of TrueFalse would give MultiChoice and TrueFalse questions) and restraints of
     * different types represent AND operations (E.G. TypeRestraint of MultiChoice and Difficulty Restraint
     * of 1 gives MultiChoice questions with difficutly 1)
     * @author Aryk Anderson
     */
        
	public class QuestionQuery {

		private List<Restraint> _restraints;


        /**
         * Property to access the list of restraints in the query
         * @returns List<Restraint>
         */
        
        public List<Restraint> Restraints
        {
            get 
			{
                return new List<Restraint>(_restraints);
			}

            private set
			{
				_restraints = value;
			}
        }


        /**
         * Default constructor, creates the list
         * @returns QuestionQuery
         */
        
		public QuestionQuery() 
		{
			_restraints = new List<Restraint> ();
		}


        /**
         * Access to add a new restraint to the list of restraints
         * @param Restraint newRestraint - the restraint to add to the list
         */
        
		public void AddRestraint(Restraint newRestraint)
		{
			if (newRestraint == null)
				return;

			_restraints.Add (newRestraint);
		}
	}
}
