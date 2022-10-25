using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Game.Scripts
{
    public class Pooling : MonoBehaviour
    {
        [System.Serializable]
        public class ThePool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        public static Pooling Instance;
        public List<ThePool> Poolings;
        public Dictionary<string, Queue<GameObject>> PoolDictionary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            PoolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (ThePool thePool in Poolings)
            {
                Queue<GameObject> objPool = new Queue<GameObject>();
                for (int i = 0; i <thePool.size; i++)
                {
                    GameObject obj = thePool.prefab;
                    obj.SetActive(false);
                   
                }
            }
        }

        public void AppearPool(string tags, Vector3 position, Quaternion rotation)
        {
            
        }
    }
}
