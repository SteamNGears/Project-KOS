/**
 * Filename: QuestionPoolSaveData.cs
 * Author: Aryk Anderson
 * Created: 6/7/2015
 * Revision: 1
 * Rev. Date: 6/10/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections.Generic;
using Database;

namespace SaveLoad
{
    [System.Serializable]
    public class QuestionPoolSaveData : SaveData
    {
        private SaveData[] _questions;

        public SaveData[] Questions
        {
            get
            {
                return _questions;
            }

            set
            {

            }
        }

        public QuestionPoolSaveData(QuestionPool pool)
        {
            _questions = new QuestionSaveData[pool.Count];

            for (int i = 0; i < pool.Count; i++)
            {
                _questions[i] = pool[i].Save();
            }
        }
    }
}

