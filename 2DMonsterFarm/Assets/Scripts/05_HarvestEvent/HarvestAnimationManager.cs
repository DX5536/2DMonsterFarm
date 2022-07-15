using UnityEngine;
using System;


namespace PTWO_PR
{
    public class HarvestAnimationManager : MonoBehaviour
    {
        //Make this a singleton
        private static HarvestAnimationManager instance;

        private void Awake()
        {
            //Create an instance
            if (instance != null)
            {
                Debug.Log("There are more than 1 OptionValue ");
                Destroy(this);
            }

            else if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
        }

        //Trigger this event when harvest
        //Aka play beam animation

        public static event Action onPlayAnimationWhenHarvest;
        public static void PlayAnimationWhenHarvest()
        {
            if(onPlayAnimationWhenHarvest != null)
            {
                onPlayAnimationWhenHarvest();
            }
        }
    }
}

