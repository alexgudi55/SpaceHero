using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOption : MonoBehaviour
{
    [SerializeField] float timeToEnterOption = 5f;
    MenuScript option;
    float timer;
    // Update is called once per frame

    void Start()
    {
        option = GameObject.Find("MenuController").GetComponent<MenuScript>();
        timer = 0;
    }
    void Update()
    {
        RayCastOption();
    }

    void RayCastOption()
    {
        RaycastHit raycast;   
        Debug.DrawRay(transform.position,transform.forward*1000,Color.blue);
        if(Physics.Raycast(transform.position, transform.forward,out raycast,1000))
        {
            Debug.Log(raycast.transform.name);
            //
            if(raycast.transform.tag == "ChooseEye")
            {
                if(raycast.transform.name == "LeftEye")
                {
                    option.Left();
                }
                else
                {
                    option.Right();
                }
            }
            else
            {
                timer += Time.deltaTime;
                if(timer >= timeToEnterOption)
                {
                    if(raycast.transform.name == "ExitGame")
                    {
                        option.Exit();
                    }
                    else if(raycast.transform.name == "PlayGame")
                    {
                        option.LoadScene();
                    }
                }
            }
        }
        else
        {
            timer = 0;
        }
    }
}
