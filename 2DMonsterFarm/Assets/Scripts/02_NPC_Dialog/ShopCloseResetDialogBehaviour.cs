using UnityEngine;

namespace PTWO_PR
{
    public class ShopCloseResetDialogBehaviour : MonoBehaviour
    {
        [SerializeField] private DisplayText_Data resetDisplayText_Data;

        [SerializeField] private TextDisplayDialog currentNPCTextCanvas;

        [SerializeField] private GameObject myMonsterShop;

        [SerializeField] private bool isPlayerNewCostumer;

        private void OnEnable()
        {
            NPCTextManager.onShopCloseResetNPCDialog += UpdateCustomerStatus;
        }

        private void OnDisable()
        {
            NPCTextManager.onShopCloseResetNPCDialog -= UpdateCustomerStatus;
        }

        private void Start()
        {
            //Idiot-proof -> to put both variable on the same plan
            isPlayerNewCostumer = currentNPCTextCanvas.IsFirstTimeVisit;
        }

        //This will check each time Player open Shop
        private void UpdateCustomerStatus()
        {
            //Constant update the status of isPlayerNewCostumer
            isPlayerNewCostumer = currentNPCTextCanvas.IsFirstTimeVisit;

            //Check if player return for the 2+ times -> if true, update text to welcomeReturn
            if (isPlayerNewCostumer == false)
            {
                //If Shop is closed: reset whatever currentDisplayText to WelcomeText
                if (myMonsterShop.activeSelf == false)
                {
                    ResetNPCDialogToWelcome();
                    Debug.Log("I should welcome them back!");
                }
            }

            //if not -> restart loop until true
            else
            {
                Debug.Log("player is NEW costumer");

            }
        }

        private void ResetNPCDialogToWelcome()
        {
            //Now I want the S.O. in NPC_Text Canvas to be replace with THE S.O. in THIS GameObject
            currentNPCTextCanvas.CurrentDisplayText_Data = resetDisplayText_Data;
        }
    }
}

