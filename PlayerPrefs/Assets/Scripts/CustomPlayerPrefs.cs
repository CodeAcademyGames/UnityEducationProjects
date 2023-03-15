using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class CustomPlayerPrefs :PlayerPrefs
    {
        public static void SetVector3(string key, Vector3 value)
        {
            SetFloat($"{key}.x", value.x);
            SetFloat($"{key}.y", value.y);
            SetFloat($"{key}.z", value.z);
        }
        public static Vector3 GetVector3(string key)
        {
            return new Vector3(GetFloat($"{key}.x"), GetFloat($"{key}.y"), GetFloat($"{key}.z"));
        }
        //public static void Set<T>(string key, T value)
        //{
        //    PlayerPrefs.SetString(key, JsonUtility.ToJson(value));
        //}
    }
}
