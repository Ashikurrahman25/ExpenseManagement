using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FirebaseRestClient;
using System.Linq;
using System;

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

    [Space(10)]
    [Header("UI")]
    [Space(10)]

    [Header("Login")]
    public InputField emailInput;
    public InputField passwordInput;

    [Header("Registration")]
    public InputField displayNameInput;
    public InputField regEmailInput;
    public InputField regPassInput;



    private Controller controller;

    private void Start()
    {
        onLogin = true;
        controller = Controller.self;
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
        GoToPanel(loginPanel, registrationPanel, 0, 840f);
        onLogin = true;
    }

    public void OnLogin()
    {
        new FirebaseAuthentication().SignInWithEmailAndPassword(emailInput.text, passwordInput.text).OnSuccess(user =>
        {
            //GoToPanel(loginPanel, registrationPanel, 0, 840f);
            onLogin = true;
            GoToDashboard();
            controller.dashboardController.FetchData(); //Fetch data
        }).
        OnError(err => ErrorHandling(err));
    }

    public void GoToRegistration()
    {
        GoToPanel(registrationPanel, loginPanel, 0, -840f);
        onRegistration = true;
    }

    public void OnRegistration()
    {
        new FirebaseAuthentication().CreateUserWithEmailAndPassword(regEmailInput.text, regPassInput.text).OnSuccess(user =>
        {
            user.UpdateProfile(displayNameInput.text, "null").OnSuccess(updatedUser =>
            {
                GoToPanel(dashboardPanel, registrationPanel, 0, -840f);
                controller.dashboardController.FetchData(); //Fetch data

            })
            .OnError(err => ErrorHandling(err));
        }).
        OnError(err => ErrorHandling(err));
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

    void ErrorHandling(Exception err)
    {
        string errorText = "";
        RequestErrorHelper.ToDictionary(err).ToList().ForEach(x => errorText += x.Key + " - " + x.Value + "\n");
        Debug.LogError(errorText);
    }


}
