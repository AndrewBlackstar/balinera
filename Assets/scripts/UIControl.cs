using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string Name)
    {
        // Load the scene with the specified name
        UnityEngine.SceneManagement.SceneManager.LoadScene(Name);
    }
}
