using FirebaseRestClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class DashboardController : MonoBehaviour
{
    [Header("Welcome")]
    public Text welcomeText;
    public Text emailText;

    [Space]
    [Header("Amounts UI")]
    public Text balanceText;
    public Text incomeText;
    public Text expensesText;
    public Text oweText;
    public Text debtText;

    [Space]
    [Header("Buttons")]
    public Button logOutButton;
    public Button addTransactionButton;
    public Button seeAllButton;
    public Button allFilterButton;
    public Button todayFilterButton;

    [Space]
    [Header("Filtering UI")]
    public Dropdown monthlyDrop;
    public Dropdown weeklyDrop;



    private FirebaseUser user;

    public void FetchData()
    {
        user = new FirebaseAuthentication().CurrentUser;

        welcomeText.text = $"Hi, {user.DisplayName}";
        emailText.text = user.Email;

    }
}

public class Transaction
{
    public int type;
    public string subType;
    public string title;
    public float amount;
    public string trxId;
    public string dateTime;
}