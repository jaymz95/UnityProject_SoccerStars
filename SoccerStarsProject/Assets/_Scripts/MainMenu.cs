using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool start;
    // Start is called before the first frame update
    void Start()
    {

        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && start == false)
        {
            start = true;
            //SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
