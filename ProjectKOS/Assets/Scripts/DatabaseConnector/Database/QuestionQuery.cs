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

	public class QuestionQuery {

		private List<Restraint> _restraints;

        public List<Restraint> Restraints
        {
            get 
			{
				return _restraints;
			}

            private set
			{
				_restraints = value;
			}
        }

		public QuestionQuery() 
		{
			_restraints = new List<Restraint> ();
		}

		public void addRestraint(Restraint newRestraint)
		{
			if (newRestraint == null)
				return;

			_restraints.Add (newRestraint);
		}
	}
}
