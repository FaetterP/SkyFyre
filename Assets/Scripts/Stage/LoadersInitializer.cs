using UnityEngine;

namespace Assets.Scripts.Stage
{
    class LoadersInitializer : MonoBehaviour
    {
        private void Awake()
        {
            Instantiate(WavesHandler.CurrentLoader);
        }
    }
}
