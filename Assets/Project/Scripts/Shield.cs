using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int initialHealth = 100;
    [SerializeField] int curHealth;
    [SerializeField] int regenerationAmount = 1; // 1 every 2 seconds
    [SerializeField] float regenerationRate = 20f;
    
    RectTransform bar;
    RectTransform bar2;
    

    void Awake()
    {
        curHealth = initialHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("barL").GetComponent<RectTransform>();
        bar2 = GameObject.Find("barR").GetComponent<RectTransform>();
        
        UpdateShieldBar();
        InvokeRepeating("Regenerate",regenerationRate, regenerationRate);
    }

    void OnEnable()
    {
        EventManager.onStartGame += UpdateShieldBar;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= UpdateShieldBar;
    }

    void Regenerate()
    {
        if(curHealth < initialHealth)
        {
            curHealth += regenerationAmount;
            UpdateShieldBar();
            Debug.Log("Regenerado");
        }
    }

    public void TakeDamage(int damage = 1)
    {
        curHealth = (curHealth - damage <= 0) ? 0 : curHealth - damage;
        UpdateShieldBar();
        Debug.Log("Damage LOL");
        if(curHealth < 1)
        {
            GetComponent<Explosion>().BlowUp();
            Debug.Log("Dead");
        }
    }

    void UpdateShieldBar()
    {   
        bar.sizeDelta = new Vector2((curHealth / (float) initialHealth) * 200, 30f);   
        bar2.sizeDelta = new Vector2((curHealth / (float) initialHealth) * 200, 30f);   
             
    }
}
