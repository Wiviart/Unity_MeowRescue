using UnityEngine;

namespace MeowRescue.Data
{
    public class Saver
    {
        public static void Save(string para, int value)
        {
            PlayerPrefs.SetInt(para, value);
        }

        public static void Save(string para, float value)
        {
            PlayerPrefs.SetFloat(para, value);
        }

        public static void Save(string para, string value)
        {
            PlayerPrefs.SetString(para, value);
        }

        public static void Reset()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}