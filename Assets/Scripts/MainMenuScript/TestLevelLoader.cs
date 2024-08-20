using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel()
    {
        StartCoroutine(StopAndLoadNextScene());
    }
    private IEnumerator StopAndLoadNextScene()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(1);
    }
}
