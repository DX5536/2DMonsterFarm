using UnityEngine;

namespace PTWO_PR
{
    public class IsometricZFix : MonoBehaviour
    {
        void Start()
        {
            transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.y / 100);
        }

    }
}