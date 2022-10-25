using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.NPC
{
    public class NpcMap1 : MonoBehaviour
    {
        public GameObject obj;
        public GameObject mission;
        public float showingButton = 1f;
        public float showingMission = 2f;
        public Coroutine Coroutine;
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                obj.SetActive(true);
                if (Coroutine == null)
                {
                    Coroutine = StartCoroutine(ShowButton());
                }
                else
                {
                    StopCoroutine(Coroutine);
                   Coroutine = StartCoroutine(ShowButton());
                }
            }
            
        }

        public void TextMission()
        {
            mission.SetActive(true);
            if (Coroutine == null)
            {
                Coroutine = StartCoroutine(ShowMission());
            }
            else
            {
                StopCoroutine(Coroutine);
                Coroutine = StartCoroutine(ShowMission());
            }
            obj.SetActive(false);
        }
        private IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(showingButton);
            obj.SetActive(false);
            Coroutine= null;
        }
        private IEnumerator ShowMission()
        {
            yield return new WaitForSeconds(showingMission);
            mission.SetActive(false);
            Coroutine= null;
        }
        
    }
    
}
