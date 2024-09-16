using UnityEngine;

public class Manual : MonoBehaviour
{
    [SerializeField] GameObject manualBackground;

    public void StartManual()
    {
        manualBackground.SetActive(true);
    }
}
