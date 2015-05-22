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
            get 
            { 
                return Value; 
            }
            
            protected set 
            { 
                Value = value; 
            }
		}

        public string Field
        {
            get
            {
                return Field;
            }

            protected set
            {
                Field = value;
            }
        }

        public abstract string[] getRange();
	}
}
