/**
 * Filename: ClassRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/22/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

    /**
     * Represents a filter on the Type of question to be returned from the database
     * @see Restraint
     * @author Aryk Anderson
     */ 

	public class TypeRestraint : Restraint {

        /**
         * Contructor, takes a string representing the relevant type
         * @returns TypeRestraint
         */ 

        public TypeRestraint(string type)
        {
            Value = type;
            RetraintType = "TYPE";
        }


        /**
         * Unimplimented method from parent
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
