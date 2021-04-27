using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public DashboardController dashboardController;
    public PanelController panelController;
    public TransactionController transactionController;
    public ButtonBehaviourController buttonBehaviourController;

    public static Controller self;

    void Awake()
    {
        if (self == null)
            self = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
