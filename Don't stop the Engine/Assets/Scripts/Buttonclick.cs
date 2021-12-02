using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttonclick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lifetext;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }
    public void Click()
    {
        GameManager.totallife = 3;
        lifetext.GetComponent<Text>().text = "LIFE: " + GameManager.totallife.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
