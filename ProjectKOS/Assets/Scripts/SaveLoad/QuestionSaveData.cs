/**
 * Filename: QuestionSaveData.cs
 * Author: Aryk Anderson
 * Created: 6/7/2015
 * Revision: 1
 * Rev. Date: 6/10/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;
using Database;

namespace SaveLoad
{
    public class QuestionSaveData : SaveData
    {
        private string _id, _subject, _type, _qString;
        private int _diff;
        private Answer[] _answers;

        public QuestionSaveData(string id, string subject, string type, int diff, string qString, AnswerPool answers)
        {
            _id = id;
            _subject = subject;
            _type = type;
            _diff = diff;
            _qString = qString;
            _answers = new Answer[answers.Size];

            foreach (Answer temp in answers)
            {

            }

        }

    }
}

