using UnityEngine;

namespace Assets.Scripts.Stage
{
    class LoaderBackgrounds : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backgroundSlow;
        [SerializeField] private SpriteRenderer _backgroundMedium;
        [SerializeField] private SpriteRenderer _backgroundFast;

        private void Awake()
        {
            _backgroundSlow.sprite = Stage.CurrentStage.BackgroundSlow;
            _backgroundMedium.sprite = Stage.CurrentStage.BackgroundMedium;
            _backgroundFast.sprite = Stage.CurrentStage.BackgroundFast;
        }
    }
}
