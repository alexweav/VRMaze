using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Detects if the game is sent to background
    /// </summary>
    public class BackgroundDetector : MonoBehaviour
    {
        public GameObject menuObject;
        public GameObject player;

        /// <inheritdoc>
        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Debug.Log("Game brought back to foreground.");
            }
            else
            {
                Debug.Log("Game sent to background.");
                menuObject.SetActive(true);
                WalkingScript WalkingController = player.GetComponent<WalkingScript>();
                WalkingController.enabled = false;
                menuObject.transform.parent = null;
            }
        }
    }
}
