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
            get; //actually should probably have an sql filter on the get for the restraint value. This is the place to do it.

            protected set;
        }

        public string RetraintType
        {
            get;

            protected set;
        }

        public abstract string[] GetRange();

        public abstract int NumArgs(); //should return 1 or 2
	}
}
