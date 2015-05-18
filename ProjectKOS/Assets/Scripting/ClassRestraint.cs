﻿/**
 * Filename: ClassRestraint.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class ClassRestraint : Restraint {

        public ClassRestraint(string classValue)
        {
            Value = classValue;
            Field = "class";
        }

        public string[] getRange()
        {
            string[] returnString = { Value, Value };

            return returnString;
        }
	}

}
