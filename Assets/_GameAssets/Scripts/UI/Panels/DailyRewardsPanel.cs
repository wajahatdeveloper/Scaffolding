using System.Collections;
using System.Collections.Generic;
using NiobiumStudios;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardsPanel : PanelBase
{
    private const string LogClassName = "DailyRewardsPanel";

    public bool dailyRewardsEnabled = false;
    
    [TitleGroup("References")]
    public DailyRewardsInterface dailyRewardsInterface;
    
    [TitleGroup("Buttons")]
    public Button backButton;

    private GameObject referencedDailyRewardObject;

    public override void Init()
    {
        if (!dailyRewardsEnabled) { return; }
        referencedDailyRewardObject = Instantiate(dailyRewardsInterface.gameObject);
    }

    protected override void OnBeforeHide()
    {
        Destroy(referencedDailyRewardObject);
    }

    void OnEnable()
    {
        DailyRewards.GetInstance().onClaimPrize += OnClaimPrizeDailyRewards;
    }

    void OnDisable()
    {
        DailyRewards.GetInstance().onClaimPrize -= OnClaimPrizeDailyRewards;
    }

    // this is your integration function. Can be on Start or simply a function to be called
    private void OnClaimPrizeDailyRewards(int day)
    {
        //This returns a Reward object
        Reward myReward = DailyRewards.GetInstance().GetReward(day);

        // And you can access any property
        print(myReward.unit);   // This is your reward Unit name
        print(myReward.reward); // This is your reward count

        var rewardsCount = PlayerPrefs.GetInt ("MY_REWARD_KEY", 0);
        rewardsCount += myReward.reward;

        PlayerPrefs.SetInt ("MY_REWARD_KEY", rewardsCount);
        PlayerPrefs.Save ();
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.startScreenPanel.Show();
        Hide();
    }
}