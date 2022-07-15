using UnityEngine;

namespace PTWO_PR
{
    public class DontDestroyAudio : MonoBehaviour
    {

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
            if(objs.Length > 1)
                Destroy(this.gameObject);
       
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
