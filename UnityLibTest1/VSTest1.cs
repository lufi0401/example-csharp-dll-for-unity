using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;

namespace UnityLibTest1
{

    public class VSTest1 : MonoBehaviour
    {

        public string val;

        /// <summary>
        /// Internal Counter
        /// </summary>
        private int count;

        /// <summary> 
        /// intialize the class
        /// </summary>
        void Start()
        {
            count = 0;
            val = string.IsNullOrEmpty(val) ? "Hello World" : val;
            Debug.Log("VSTest1 version: " + typeof(VSTest1).Assembly.GetName().Version.ToString());
            Debug.Log("Unity version: " + Application.unityVersion);
        }

        /// <summary>
        /// Periodically print message statued
        /// </summary>
        void Update()
        {
            if (count++ % 30 == 0)
                Debug.Log(string.Format("VSTest1: {0}", val));
        }

    }
}
