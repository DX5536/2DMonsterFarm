using UnityEngine;
using System;

namespace PTWO_PR
{
    public class NPCTextManager : MonoBehaviour
    {
        //Make this a singleton
        private static NPCTextManager instance;

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

        //Display NPC Dialog Event when click on Items in shop
        public static event Action<string> onItemDisplayNPCDialog;
        public static void ItemDisplayNPCDialog(string itemNameID)
        {
            if (onItemDisplayNPCDialog != null)
            {
                onItemDisplayNPCDialog(itemNameID);
            }
        }

        //Reset NPC Dialog when shop Close
        public static event Action onShopCloseResetNPCDialog;
        public static void ShopCloseResetNPCDialog()
        {
            if (onShopCloseResetNPCDialog != null)
            {
                onShopCloseResetNPCDialog();
            }
        }

        //Display NPC Dialog Event when player click on body parts
        public static event Action<string> onTouchingNPCDialog;
        public static void TouchingNPCDialog(string bodyPartNameID)
        {
            if (onTouchingNPCDialog != null)
            {
                onTouchingNPCDialog(bodyPartNameID);
            }
        }

        //Display NPC dialog when player buying misc
        public static event Action<string> onBuyingMiscNPCDialog;
        public static void BuyingMiscNPCDialog(string miscItemNameID)
        {
            if (onBuyingMiscNPCDialog != null)
            {
                onBuyingMiscNPCDialog (miscItemNameID);
            }
        }

    }
}

