/**
 * Filename: SaveLoadManager.cs
 * Author: Aryk Anderson
 * Created: 6/7/2015
 * Revision: 1
 * Rev. Date: 6/10/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoad
{
    public class SaveLoadManager
    {

        public static string SaveFileDirectory = "Assets/SavedGames/";

        private SaveLoadManager _instance;
        public SaveLoadManager Instance
        {
            get
            {
                if (_instance != null)
                    return Instance;

                return _instance = new SaveLoadManager();
            }

            private set
            {
                _instance = value;
            }
        }


        /**
         * Default constructor. Don't know if something should be inside this /yet/
         */ 

        private SaveLoadManager()
        {

        }


        /**
         * Method is in charge of taking the snapshot of the game, serializing that snapshot to a new savefile
         * and saving that file
         * @returns string : returns a string with the filepath to the saved game
         */ 

        public string SaveGame()
        {
            string savePath = "" + SaveFileDirectory;

            SceneSave scene = new SceneSave();
            scene.TakeSnapshot();

            try
            {
                savePath += System.DateTime.Now + ".save";

                FileStream fout = File.Open(savePath, FileMode.Create);
                BinaryFormatter writer = new BinaryFormatter();

                writer.Serialize(fout, scene);

                fout.Close();
            }

            catch (IOException e)
            {
                Debug.Log(e.Message);
            }

            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return savePath;
        }


        /**
         * Method takes the filename passed in, opens that file, attempts to deserialize the object and sets
         * all the objects in the scene to have the correct data from that save file.
         * 
         * @param string filePath : the file location to open
         */ 

        public void LoadGame(string filePath)
        {
            if (!File.Exists(filePath)) 
            {
                Debug.Log(filePath + " does not exist!");
                return;
            }

            try
            {
                FileStream fin = File.Open(filePath, FileMode.Open);
                BinaryFormatter reader = new BinaryFormatter();

                SceneSave scene = (SceneSave)reader.Deserialize(fin);
                scene.InstantiateSnapshot();

                fin.Close();
            }

            catch (IOException e)
            {
                Debug.Log(e.Message);
            }

            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }


        /**
         * Scans the directory for all saved game files and returns an array of the filepaths
         * 
         * @returns string[] : array of the filepath names to saved games
         */ 

        public string[] GetFilePaths()
        {
            return Directory.GetFiles(@SaveFileDirectory);
        }


        /**
         * Finds the newest save file and returns that as the default file. Needs to be changed later
         * to non-naievely search all files. It should only search .save files instead
         * 
         * @returns string defaultFilePath
         */

        public string DefaultSave()
        {
            string[] files = Directory.GetFiles(@SaveFileDirectory);

            System.DateTime newest = System.DateTime.MinValue; //might need to change this to max value, not sure
            int newestIndex = 0;

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    System.DateTime wTime = File.GetLastWriteTimeUtc(files[i]);

                    if (i == 0)
                    {
                        newest = wTime;
                    }

                    else
                    {
                        if (newest.CompareTo(wTime) > 0)
                        {
                            newest = wTime;
                            newestIndex = i;
                        }
                    }
                }

                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            } //end loop i

            return files[newestIndex];
        }
    }
}

