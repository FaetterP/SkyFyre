using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerProjectile : MonoBehaviour
    {
        private void Update()
        {
            transform.localPosition += new Vector3(1, 0, 0);
        }
    }
}
