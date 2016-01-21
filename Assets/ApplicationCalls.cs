using UnityEngine;

public class ApplicationCalls : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
			Application.LoadLevel(0);
        }
    }
}
