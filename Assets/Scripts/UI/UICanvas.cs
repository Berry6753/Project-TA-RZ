using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UICanvas : MonoBehaviour
{
    [Inject] UIEvent UIEvent;
    [SerializeField] PlayerUIView PlayerUIView;
    [SerializeField] BlueChipUI BlueChipUI;
    [SerializeField] GameUI GameUI;
    [SerializeField] LoadingUI LoadUI;
    [SerializeField] ShopUI ShopUI;
    [SerializeField] PassiveShopUI PassiveShopUI;
    [SerializeField] InteractUI InteractUI;
    [SerializeField] AchievementUI AchievementUI;
    [SerializeField] QuestUI QuestUI;
    [SerializeField] MenuUI MenuUI;
    [SerializeField] PlayerBlueChipUI PlayerBlueChipUI;

    public void Awake()
    {
        UIEvent.RegisterPlayerUI(PlayerUIView);
        UIEvent.RegisterBlueChipUI(BlueChipUI);
        UIEvent.RegisterGameUI(GameUI);
        UIEvent.RegisterLoadUI(LoadUI);
        UIEvent.RegisterShopUI(ShopUI);
        UIEvent.RegisterPassiveShopUI(PassiveShopUI);
        UIEvent.RegisterInteractUI(InteractUI);
        UIEvent.RegisterAchievementUI(AchievementUI);
        UIEvent.RegisterQuestUI(QuestUI);
        UIEvent.RegisterMenuUI(MenuUI);
        UIEvent.RegisterPlayerBlueChipUI(PlayerBlueChipUI);
    }
}
