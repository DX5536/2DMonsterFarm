using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PTWO_PR
{
    public class SoundFXEventManager : MonoBehaviour
    {
        //Make this a singleton
        private static SoundFXEventManager instance;

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

        //Play HarvestSound through event
        public static event Action onPlayHarvestSound;
        public static void PlayHarvestSound()
        {
            if (onPlayHarvestSound != null)
            {
                onPlayHarvestSound();
            }
        }

        //Play PlantSound through event
        public static event Action onPlayPlantSound;
        public static void PlayPlantSound()
        {
            if (onPlayPlantSound != null)
            {
                onPlayPlantSound();
            }
        }

        //Play FoodSound through event
        public static event Action onPlayFoodSound;
        public static void PlayFoodSound()
        {
            if (onPlayFoodSound != null)
            {
                onPlayFoodSound();
            }
        }

        //Play NormalTileSound through event
        public static event Action onPlayNormalTileSound;
        public static void PlayNormalTileSound()
        {
            if (onPlayNormalTileSound != null)
            {
                onPlayNormalTileSound();
            }
        }

        //Play SkyTileSound through event
        public static event Action onPlaySkyTileSound;
        public static void PlaySkyTileSound()
        {
            if (onPlaySkyTileSound != null)
            {
                onPlaySkyTileSound();
            }
        }

        //Play LavaTileSound through event
        public static event Action onPlayLavaTileSound;
        public static void PlayLavaTileSound()
        {
            if (onPlayLavaTileSound != null)
            {
                onPlayLavaTileSound();
            }
        }

        //Play ReadyToHarvestSound through event
        public static event Action onPlayReadyToHarvestSound;
        public static void PlayReadyToHarvestSound()
        {
            if (onPlayReadyToHarvestSound != null)
            {
                onPlayReadyToHarvestSound();
            }
        }
    }
}
