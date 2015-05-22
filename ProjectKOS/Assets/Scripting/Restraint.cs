/**
 * Filename: Restraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
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

        public string Field
        {
            get;

            protected set;
        }

        public abstract string[] getRange();
	}
}
