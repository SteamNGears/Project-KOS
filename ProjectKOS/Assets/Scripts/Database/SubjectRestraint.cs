/**
 * Filename: SubjectRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class SubjectRestraint : Restraint {

        public SubjectRestraint(string subject)
        {
            Value = subject;
            Field = "subject";
        }

        public override string[] getRange()
        {
            string[] returnString = { Value, Value };

            return returnString;
        }
	}
}
