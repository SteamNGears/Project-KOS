/**
 * Filename: SubjectRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class SubjectRestraint : Restraint {

        public SubjectRestraint(string subject)
        {
            Value = subject;
            RetraintType = "SUBJECT";
        }

        public override string[] GetRange()
        {
            throw new System.NotImplementedException();
        }

        public override int NumArgs()
        {
            return 1;
        }
	}
}
