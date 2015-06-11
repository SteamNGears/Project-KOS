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
    [System.Serializable]
    public class QuestionSaveData : SaveData
    {
        private string _id, _subject, _type, _qString;
        private int _diff;
        private string[] _answerStrings;
        private bool[] _answerVals;

        public QuestionSaveData(string id, string subject, string type, int diff, string qString, AnswerPool answers)
        {
            _id = id;
            _subject = subject;
            _type = type;
            _diff = diff;
            _qString = qString;
            _answerStrings = new string[answers.Size];
            _answerVals = new bool[answers.Size];

            for (int i = 0; i < answers.Size; i++)
            {
                _answerVals[i] = answers[i].Correct;
                _answerStrings[i] = answers[i].AnswerString;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }

            set
            {

            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }

            set
            {

            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {

            }
        }

        public string QuestionString
        {
            get
            {
                return _qString;
            }

            set
            {

            }
        }

        public int Difficulty 
        {
            get
            {
                return _diff;
            }

            set
            {

            }
        }

        public AnswerPool Answers
        {
            get
            {
                AnswerPool answers = new AnswerPool();

                for (int i = 0; i < _answerVals.Length; i++)
                {
                    answers.AddAnswer(new Answer(_answerStrings[i], _answerVals[i]));
                }

                return answers;
            }

            set
            {

            }
        }
    }
}

