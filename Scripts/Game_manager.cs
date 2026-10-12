using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public GameObject[] myObject;
    Ray ray;
    List<Vector3> mylist = new List<Vector3>();
    public float distancebetweenspawnandnew = 0;
    Vector3 myrandomvector;
    [SerializeField] int myValue;
    Canvas canvas_;
    public GameObject myplane;



    // For another corutine

    GameObject myinstatieObject;

    


    private void OnEnable()
    {
       
        canvas_ = GetComponent<Canvas>();   
        
        
       

        StartCoroutine(corutineM(Random.Range(0.5f,2f)));

    }
    /* void Start()
     {



     } */

    private void Update()
    {
        FireScreenRay();


        

    }
    
    void FireScreenRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hitobject))
        {
            if (hitobject.collider.gameObject.CompareTag("patates") && Input.GetMouseButton(0))
            {
                mylist.Remove(hitobject.collider.transform.position);
                Destroy(hitobject.collider.gameObject);
              


             
            }
            else if(hitobject.collider.gameObject.CompareTag("sisko") && Input.GetMouseButton(0))
            {
                Time.timeScale = 0;
            }
        }


        
    }

    IEnumerator corutineM(float myTime)
    {
      


        while (true) // do while 1 kez calisiyor 
        {

            Debug.Log(mylist.Count);

            // while/do while, foreach, Vector3.Distance distance koyuyorsam onun bir value ya ihtiyacim var. 
            if(canvas_.system == true)
            {
                myValue = Random.Range(2, 4);
            }
            else
            {
                myValue = Random.Range(0, 2);
            }
           // red or green random            

          // buraya UI sistemi lazim ekstra olarak burasi gamemanager olarak kalsin 
          

            bool isPostion = true;

            do
            {
                var tryX = Random.Range(-4.5f, 4.5f); //random position X 
                var tryZ = Random.Range(-4.5f, 4.5f); // random position Z
                
                

                if(canvas_.system == true)
                {
                    myrandomvector = new Vector3(tryX, Random.Range(0f, 30f), tryZ);
                }
                else
                {

                    myrandomvector = new Vector3(tryX, 0f, tryZ);   
                }
                
                isPostion = true;

                foreach (var item in mylist)
                {
                    distancebetweenspawnandnew = Vector3.Distance(myrandomvector, item);

                    if (distancebetweenspawnandnew < 2f)
                    {
                        isPostion = false; break;
                    }
                    


                }
            } while (!isPostion);

            if (isPostion)
            {
                
                myinstatieObject =  Instantiate(myObject[myValue], myrandomvector, Quaternion.identity);
               
                mylist.Add(myrandomvector);

                if(myinstatieObject.CompareTag("sisko"))
                {
                    StartCoroutine(isdestroyingitself(myinstatieObject,myrandomvector,3));
                    
                                         
                }


                if (myinstatieObject.CompareTag("patates"))
                {
                    StartCoroutine(over(myinstatieObject, myrandomvector, 3));
                }
                

            }
            else
            {
                Debug.Log("1 Sec Waiting");
            }



            yield return new WaitForSeconds(myTime); // Time is remaining



        }
       
    }


    IEnumerator isdestroyingitself(GameObject objecttodestroy,Vector3 spawnpoint ,float destroytime)
    {

        yield return new WaitForSeconds(destroytime);
        mylist.Remove(spawnpoint);
        Destroy(objecttodestroy);
        


       

        


    }

    IEnumerator over(GameObject objecttodestroy, Vector3 spawnpoint, float destroytime)
    {

        yield return new WaitForSeconds(destroytime);
        mylist.Remove(spawnpoint);
        Destroy(objecttodestroy);








    }
}
