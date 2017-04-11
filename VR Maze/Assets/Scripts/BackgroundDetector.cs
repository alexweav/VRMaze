using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects if the game is sent to background
/// </summary>
public class BackgroundDetector : MonoBehaviour
{
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
            //TODO: Go to pause menu when it exists
        }
    }
}
