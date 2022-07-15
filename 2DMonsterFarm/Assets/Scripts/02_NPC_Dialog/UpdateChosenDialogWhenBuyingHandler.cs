using UnityEngine;

namespace PTWO_PR
{
    public class UpdateChosenDialogWhenBuyingHandler : MonoBehaviour
    {
        [Header("Attach to BuyButton")]
        
        [SerializeField] private string handlerShopItemID;

        //Will attach to the buy button and activate per Event
        public void ActivateNPCTextThroughEvent()
        {
            NPCTextManager.ItemDisplayNPCDialog(handlerShopItemID);
        }
    }
}


