using UnityEngine;

namespace MeowRescue.Data
{
    public class Loader
    {
        public static void Load(string para, out int value)
        {
            value = PlayerPrefs.GetInt(para, 0);
        }

        public static void Load(string para, out float value)
        {
            value = PlayerPrefs.GetFloat(para, 0);
        }

        public static void Load(string para, out string value)
        {
            value = PlayerPrefs.GetString(para, "");
        }
    }
}