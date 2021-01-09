using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionController : MonoBehaviour
{

    public DailyTransaction dailyTransactions;
    public YearlyTransaction transactions;

    DateTime dateTime;

    private void Start()
    {
        dateTime = DateTime.Now;
        Debug.Log(dateTime.Year);
        Debug.Log(dateTime.Month);
        Debug.Log(dateTime.Day);
        Debug.Log((int)dateTime.DayOfWeek);
        Debug.Log(DateTime.DaysInMonth(dateTime.Year, dateTime.Month));

        Debug.Log(GetWeekNumberOfMonth(dateTime));
    }

    private static int GetWeekNumberOfMonth(DateTime date)
    {
        // One Solution
        decimal numberofday = date.Day;
        decimal d = (Math.Floor(numberofday / 7)) + 1;

        if ((numberofday) % 7 == 0)
        {
            return Convert.ToInt32((d)) - 1;
        }
        return Convert.ToInt32(d);

    }
}

[System.Serializable]
public class CommonTransaction
{
    public string date;
    public string time;
    public string title;
    public int amount;

    public CommonTransaction() { }

    public CommonTransaction(string _date, string _time, string _title, int _amount)
    {
        date = _date;
        time = _time;
        title = _title;
        amount = _amount;
    }
}

[System.Serializable]
public class DailyTransaction
{
    public List<CommonTransaction> dailyIncomeList = new List<CommonTransaction>();
    public List<CommonTransaction> dailyExpenseList = new List<CommonTransaction>();
    public List<CommonTransaction> dailyOweList = new List<CommonTransaction>();
    public List<CommonTransaction> dailyDueList = new List<CommonTransaction>();

    public int dayIndex;

    public DailyTransaction() { }
    public DailyTransaction(int dayIndex)
    {
        this.dayIndex = dayIndex;
    }
}

[System.Serializable]
public class WeeklyTransaction
{
    public int weekIndex;
    public List<DailyTransaction> dailyTransaction = new List<DailyTransaction>();

    public WeeklyTransaction() { }
    public WeeklyTransaction(int weekIndex)
    {
        this.weekIndex = weekIndex;
    }
}

[System.Serializable]
public class MonthlyTransaction
{
    public int monthIndex;
    public List<WeeklyTransaction> weeklyTransaction = new List<WeeklyTransaction>();

    public MonthlyTransaction() { }
    public MonthlyTransaction(int monthIndex)
    {
        this.monthIndex = monthIndex;
    }
}

[System.Serializable]
public class YearlyTransaction
{
    public int currentYear;
    public List<MonthlyTransaction> monthlyTransaction = new List<MonthlyTransaction>();

    public YearlyTransaction() { }
    public YearlyTransaction(int currentYear)
    {
        this.currentYear = currentYear;
    }
}
