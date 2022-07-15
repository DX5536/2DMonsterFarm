using UnityEngine;

namespace PTWO_PR
{
    [CreateAssetMenu(fileName = "DisplayText_Data" , menuName = "StoryTelling/ScriptableObject/CreateDisplayText_Data" , order = 1)]
    public class DisplayText_Data : ScriptableObject
    {
        [SerializeField] private float flowTextDelay = 0.01f; //Display Speed

        [SerializeField] private float closeTextDelay; //Waiting time to close text

        [SerializeField] private bool hasTextBeenPlayed = false;

        [SerializeField] private GameObject whichStoryTMP; //Which TMP text are we talking about

        private string fullText; //Show when all text is complete
        private string currentText = ""; //Starts with empty

        // Setting up properties for the variables to use them
        public float FlowTextDelay
        {
            get { return flowTextDelay; }
            set { flowTextDelay = value; }
        }

        public float CloseTextDelay
        {
            get { return closeTextDelay; }
            set { closeTextDelay = value; }
        }

        public bool HasTextBeenPlayed
        {
            get { return hasTextBeenPlayed; }
            set { hasTextBeenPlayed = value; }
        }

        public GameObject WhichStoryTMP
        {
            get { return whichStoryTMP; }
            set { whichStoryTMP = value; }
        }

        public string FullText
        {
            get { return fullText; }
            set { fullText = value; }
        }

        public string CurrentText
        {
            get { return currentText; }
            set { currentText = value; }
        }
    }

}
