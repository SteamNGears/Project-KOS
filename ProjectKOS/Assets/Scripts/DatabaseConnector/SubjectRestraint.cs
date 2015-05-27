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

    /**
     * Represents a filter for questions based on the subject of the question
     * @see Restraint
     * @author Aryk Anderson
     */
        
	public class SubjectRestraint : Restraint {

        /**
         * Constructor
         * @param string subject - the subject to filter on
         */
        
        public SubjectRestraint(string subject)
        {
            Value = subject;
            RetraintType = "SUBJECT";
        }


        /**
         * Unimplemented method from parent
         * @throws System.NotImplementedException
         */
        
        public override string[] GetRange()
        {
            throw new System.NotImplementedException();
        }


        /**
         * Unimplemented method from parent
         * @returns int
         */
        
        public override int NumArgs()
        {
            return 1;
        }
	}
}
