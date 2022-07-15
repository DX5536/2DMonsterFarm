using System.Collections;
using TMPro;
using UnityEngine;

namespace PTWO_PR
{
    public class TextDisplayDialog: MonoBehaviour
    {
        [SerializeField] private DisplayText_Data currentDisplayText_Data; //Ref the scriptable Object

        //need to check the isOpen of Shop
        [SerializeField] private GameObject shopStatus;
        
        //Special 1st time only
        [SerializeField] private bool isFirstTimeVisit = true;

        public bool IsFirstTimeVisit
        {
            get { return isFirstTimeVisit; }
            set { isFirstTimeVisit = value; }
        }

        //Set up a property for the displayText_Data -> So it can be switch later
        public DisplayText_Data CurrentDisplayText_Data
        {
            get { return currentDisplayText_Data; }
            set { currentDisplayText_Data = value; }
        }

        //A method that will display the text
        //Needs to be public to activate else where -> Through the Buy button of X monster
        public void DisplayNPCDialog()
        {
            //With this the text being display is in the TMP Box
            currentDisplayText_Data.FullText = currentDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text; 
            //If shop is active -> Start display text
            if(shopStatus.activeSelf == true)
            {
                //Player lost new customer status ;_;
                isFirstTimeVisit = false;
                StartCoroutine(ShowText());
            }

        }

        IEnumerator ShowText()
        {
            //For-Loop: Run as many times as fullText's character
            //+1 to avoid a character being eaten *nom nom*
            for (int i = 0 ; i < currentDisplayText_Data.FullText.Length + 1 ; i++)
            {
                currentDisplayText_Data.CurrentText = currentDisplayText_Data.FullText.Substring(0 , i); //starts at 0 to i
                this.GetComponent<TextMeshProUGUI>().text = currentDisplayText_Data.CurrentText; //put currentDisplayText_Data.CurrentText in TMP's text box

                yield return new WaitForSeconds(currentDisplayText_Data.FlowTextDelay); //wait for delay-Amount of second
            }

            //Close text Box when For-Loop is finished
            yield return new WaitForSeconds(currentDisplayText_Data.CloseTextDelay);

            //Grab the TMP component in this GameObject
            //And replace it with the Reset0DisplayText_Data
            //Aka. Display no text

            //this.gameObject.GetComponent<TextMeshProUGUI>().text = resetDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text;

            currentDisplayText_Data.HasTextBeenPlayed = true;
            //this.gameObject.SetActive(false);
        }
    }
}
