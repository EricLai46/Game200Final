using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    //public GameObject deadtext;
    public GameObject player;
    public float starttime ;
    public GameObject lifetext;
    public WheelCollider[] wheel;
    public AudioClip[] soundcontrol;
    public GameObject panel;
    public GameObject paneldeadtext;
    GameManager gameManager;
    void Start()
    {
        //deadtext.GetComponent<Text>().text = "";
        starttime = 1.0f;
        paneldeadtext.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
      if(collider.tag.CompareTo("Player")==0)
        {
            foreach (var o in wheel)
            {
                o.brakeTorque = 30000000;

            }
            StartCoroutine(bombeffect());
            this.GetComponent<AudioSource>().clip = soundcontrol[1];
            
            this.GetComponent<AudioSource>().loop = false;
            this.GetComponent<AudioSource>().Play();

            GameManager.totallife--;
            updatelife();
            foreach (var o in wheel)
            {
                o.brakeTorque = 0;
            }
        }
    }
    IEnumerator bombeffect()
    {
        while (starttime >= 0)
        {

            explosion.SetActive(true);
            yield return new WaitForSeconds(1);
            starttime--;
        }
        explosion.SetActive(false);
        starttime = 1.0f;
        player.transform.position = new Vector3(CheckPoints.currentcheckpoint.x, 2, CheckPoints.currentcheckpoint.z);

        yield return null;
    }
    void updatelife()
    {
        if(GameManager.totallife>0)
        lifetext.GetComponent<Text>().text = "LIFE: " + GameManager.totallife.ToString();
        else if(GameManager.totallife==0)
        {
            CarControl.istime = false;
            lifetext.GetComponent<Text>().text = "LIFE: " + GameManager.totallife.ToString();
            this.GetComponent<AudioSource>().clip = soundcontrol[0];
            this.GetComponent<AudioSource>().playOnAwake = false;
           
            this.GetComponent<AudioSource>().Play();
            panel.SetActive(true);
            paneldeadtext.GetComponent<Text>().text = "YOU DIED! PRESS BUTTON TO PLAY IT AGAIN!";

        }
    }
}
