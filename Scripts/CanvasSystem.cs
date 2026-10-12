using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Canvas : MonoBehaviour
{

    public GameObject panel;
    public TextMeshProUGUI myText;
    public GameObject blackPanel;
     public Game_manager manager;

    public bool system = false;



    void Start()
    {
      
        myText.text = "Do you want to play with Y axis to ? ";
        manager.GetComponent<Game_manager>();

        InvokeRepeating("UICheck", 1f, 3f);
    }


    void Update()
    {
        
    }



    public  void dropSystemPositive()
    {
       system = true;

        var tryz = Random.Range(0f, 25f);


        myText.text = system.ToString();

        StartCoroutine(waitfor3sec());


  

    }

    public void dropSystemNegative()
    {

        system = false;
        

        myText.text = system.ToString();

        StartCoroutine(waitfor3sec());
        
        
       



    }


  

    public void UICheck()
    {
        if(myText.text.Length == 0)
        {
            myText.text = "";
        }
      
    }


    IEnumerator waitfor3sec()
    {
        myText.text = "waiting.";
        yield return new WaitForSeconds(.5f);
        myText.text = "waiting..";
        yield return new WaitForSeconds(.5f);
        myText.text = "waiting...";
        yield return new WaitForSeconds(.5f);

        blackPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        manager.enabled = true;
        StopAllCoroutines();    


    }


}
