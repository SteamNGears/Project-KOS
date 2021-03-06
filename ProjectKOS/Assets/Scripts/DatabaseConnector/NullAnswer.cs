﻿/**
 * Filename: AnswerPool.cs
 * Author: Aryk Anderson
 * Created: 5/15/2015
 * Revision: 0
 * Rev. Date: 5/15/2015
 * Rev. Author: Aryk Anderson
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    /**
     * Null Object to be a placeholder for a non-answer instead of a null
     */
        
    class NullAnswer : Answer
    {
        /**
         * Default Constructor
         */

        public NullAnswer() 
        {
            AnswerString = "";
            Correct = false;
        }
    }
}
