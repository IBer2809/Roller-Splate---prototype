using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundNumbers;
    // Start is called before the first frame update
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("ground");
    }

    // Update is called once per frame
    void Update()
    {
        groundNumbers = grounds.Length;
    }

    public void LoadLevel(){
        SceneManager.LoadScene(0);
    }


}
