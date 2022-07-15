using UnityEngine;

namespace PTWO_PR
{
    public class ShopCloseResetDialogHandler : MonoBehaviour
    {
        //This event will be trigger when PLayer click Shop button -> Update status and say Welcome
        public void ActivateUpdateCustomerStatus()
        {
            NPCTextManager.ShopCloseResetNPCDialog();
        }
    }
}