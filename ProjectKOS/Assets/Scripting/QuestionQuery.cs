/**
 * Filename: QuestionQuery.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;

namespace Database {

	public class QuestionQuery {

		private List<Restraint> _restraints;

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

		public List<Restraint> receiveRestraints()
		{
			return _restraints;
		}
	}
}
