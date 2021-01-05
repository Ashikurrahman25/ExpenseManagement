using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    public bool onLogin;
    public bool onRegistration;

    public bool onDashBoard;
    public bool onTransactions;
    public bool onAddTransaction;

    public GameObject loginPanel;
    public GameObject registrationPanel;
    public GameObject dashboardPanel;
    public GameObject transactionPanel;
    public GameObject addTransactionPanel;

    private void Start()
    {
        onLogin = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onLogin)
                Application.Quit();
            else if (onRegistration)
                GoToLogin();
            else if (onTransactions || onAddTransaction)
                GoToDashboard();
            else if (onDashBoard)
                Application.Quit();
        }
    }

    public void GoToLogin()
    {
        GoToPanel(loginPanel,registrationPanel, 0,840f);
        onLogin = true;
    }

    public void GoToRegistration()
    {
        GoToPanel(registrationPanel, loginPanel, 0, -840f);
        onRegistration = true;
    }

    public void GoToDashboard()
    {

        if(onLogin)
            GoToPanel(dashboardPanel,loginPanel,0, -840f);

        else if(onTransactions)
            GoToPanel(dashboardPanel,transactionPanel,0, 840f);

        else if (onAddTransaction)
            GoToPanel(dashboardPanel, addTransactionPanel, 0, -840f);

        onDashBoard = true;
    }

    public void GoToTransactions()
    {
        GoToPanel(transactionPanel, dashboardPanel, 0, -840f);
        onTransactions = true;
    }

    public void GoToAddTransactions()
    {
        GoToPanel(addTransactionPanel, dashboardPanel, 0, 840f);
        onAddTransaction = true;
    }



    public void GoToPanel(GameObject panelToActivate, GameObject panelToDeactivate, float activatePanelValue, float deactivatePanelValue)
    {
        panelToDeactivate.transform.GetComponent<RectTransform>().DOAnchorPos3DX(deactivatePanelValue, .2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            panelToActivate.SetActive(true);

            panelToActivate.transform.GetComponent<RectTransform>().DOAnchorPos3DX(activatePanelValue, .2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                panelToDeactivate.SetActive(false);
            });
        });

        SetBoolFalse();

    }

    public void SetBoolFalse()
    {
        onLogin = false;
        onRegistration = false;
        onDashBoard = false;
        onTransactions = false;
        onAddTransaction = false;
    }


}
