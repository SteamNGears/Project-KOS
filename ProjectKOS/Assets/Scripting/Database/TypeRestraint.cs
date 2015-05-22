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

	public class TypeRestraint : Restraint {

        public TypeRestraint(string type)
        {
            Value = type;
            RetraintType = "TYPE";
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
