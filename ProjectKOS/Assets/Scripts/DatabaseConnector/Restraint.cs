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
    /**
     */
        
	public abstract class Restraint 
	{
        /**
         * Readonly access to the string representing the value that the restraint is filtering on
         * @returns string
         */
        
        public string Value
        {
            get; //actually should probably have an sql filter on the get for the restraint value. This is the place to do it.

            protected set;
        }


        /**
         * Readonly access to the string representing the type of restraint the object is
         * (maybe not very OO)
         * @returns string
         */
        
        public string RetraintType
        {
            get;

            protected set;
        }


        /**
         * Abstract method. This is supposed to hold the values that the restraint can hold. Not implemented for
         * Type and Subject restraints. Most obvious use of this would be for range searches against the database,
         * but could also be used to hold multiple values in a custom filter
         * @returns string[]
         */
        
        public abstract string[] GetRange();


        /**
         * Abstract method should return the number of arguments being tracked by the restraint. Should
         * be consistent with GetRange
         * @returns int
         */
        
        public abstract int NumArgs();
	}
}
