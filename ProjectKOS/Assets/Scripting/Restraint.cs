/**
 * Filename: Restraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database 
{

	public abstract class Restraint 
	{

        public string Value
        {
            get;

            protected set;
        }

        public string RetraintType
        {
            get;

            protected set;
        }

        public abstract string[] getRange();

        public abstract int numArgs(); //should return 1 or 2
	}
}
