using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel()
    {

        SceneManager.LoadScene(1);
    }
}
