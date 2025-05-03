using System.IO;
using UnityEngine;

namespace Unchord
{
    public class GameData
    {
        private const int GAME_DATA_FILE_VERSION = 0;

        public static GameData Instance
        {
            get
            {
                lock (s_lock)
                {
                    if (s_instance == null)
                    {
                        s_instance = new GameData();
                        s_instance.Load();
                    }

                    return s_instance;
                }
            }
        }

        public static GameData UnsafeInstance
        {
            get => s_instance;
        }

        private static GameData s_instance;
        private static object s_lock = new object();

        #region Save Fields
        // TODO: �����ϰ� ���� �����͸� Save Fields Region�� public���� �����մϴ�.
        public int gameDataFileVersion = GameData.GAME_DATA_FILE_VERSION;

        public float totalAbsolutePlaytime;
        public float totalElapsedPlaytime;
        public int totalGamePlayCount;

        public int maxScore;
        public int totalScore;

        public int maxCombo;
        public int totalCombo;
        
        public int gold;
        #endregion

        public static string GetPersistentDataFilePath()
        {
            return Application.persistentDataPath + "/bullet.json";
        }

        public void Load()
        {
            string path = GameData.GetPersistentDataFilePath();

            if (!File.Exists(path))
            {
                string json = JsonUtility.ToJson(this);
                FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                StreamWriter wr = new StreamWriter(fs);
                wr.Write(json);
                wr.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader rd = new StreamReader(fs);
                string json = rd.ReadToEnd();
                rd.Close();
                fs.Close();
                JsonUtility.FromJsonOverwrite(json, this);
            }
        }

        public void Save()
        {
            string path = GameData.GetPersistentDataFilePath();

            string json = JsonUtility.ToJson(this);
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter wr = new StreamWriter(fs);
            wr.Write(json);
            wr.Close();
            fs.Close();
        }
    }
}