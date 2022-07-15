using UnityEngine;

namespace PTWO_PR
{
    public class UpdateChosenDialogWhenBuyingBehaviour : MonoBehaviour
    {
        //Refer our S.O.
        [SerializeField] private DisplayText_Data myDisplayText_Data;

        //Refer our Story Canvas
        [SerializeField] private TextDisplayDialog currentNPCTextCanvas;

        [SerializeField] private FarmManager farmManager;

        [SerializeField] private string shopItemNameID;

        private void OnEnable()
        {
            NPCTextManager.onItemDisplayNPCDialog += UpdateDialog;
        }

        private void OnDisable()
        {
            NPCTextManager.onItemDisplayNPCDialog -= UpdateDialog;
        }


        // Start is called before the first frame update
        void Start()
        {
            //Find farmManager
            farmManager = FindObjectOfType<FarmManager>();
        }

        //a private method
        //that will be activated in "Buy" Button (thought the handler aka. Event System)
        private void UpdateDialog(string shopItemID)
        {
            if(shopItemID == this.shopItemNameID)
            {
                //Only display/update text when player select an item
                if (farmManager.IsPlanting)
                {
                    //Now I want the S.O. in NPC_Text Canvas to be replace with THE S.O. in THIS GameObject
                    currentNPCTextCanvas.GetComponent<TextDisplayDialog>().CurrentDisplayText_Data = myDisplayText_Data;

                    //Once it's assigned to the S.O. in Story Canvas -> Trigger DisplayNPCDialog
                    currentNPCTextCanvas.GetComponent<TextDisplayDialog>().DisplayNPCDialog();
                }
            }
        }
    }
}

