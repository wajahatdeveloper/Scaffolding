using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : PanelBase
{
    private const string LogClassName = "ShopPanel";

    [TitleGroup("Buttons")]
    public Button backButton;
    [ReadOnly] public List<Button> skinButtons = new();
    [ReadOnly] public List<Button> offersButtons = new();

    [TitleGroup("Tabs")]
    public Toggle skinToggle;
    public Toggle offersToggle;

    [TitleGroup("Pages")]
    public Transform skinPage;
    public Transform offersPage;

    public override void Init()
    {
        skinButtons.Clear();
        var children = skinPage.GetChildren();
        skinButtons.AddRange(children.Select(x=>x.GetComponent<Button>()));
        
        offersButtons.Clear();
        children = offersPage.GetChildren();
        offersButtons.AddRange(children.Select(x=>x.GetComponent<Button>()));
    }

    public void OnClick_Back()
    {
        DebugX.Log($"{LogClassName} : Back Button Clicked.", LogFilters.None, gameObject);
        MainMenu.Instance.startScreenPanel.Show();
        Hide();
    }
}