using UnityEngine;

namespace Game.UI
{
    public class TutorialUI : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 0f;
        }

        public void OnOkClicked()
        {
            Destroy(gameObject);
            Time.timeScale = 1f;
        }
    }
}
