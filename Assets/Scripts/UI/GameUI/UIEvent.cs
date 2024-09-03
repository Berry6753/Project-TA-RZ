using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UIEvent
{
    [Inject] Player player { get; }

    private Action<float> _progressCallBack;
    private Action<StageType> _stageCallBack;
    private GameUI _gameUI;
    private MapManager _mapManager;
    public LoadingUI _loadUI { get; private set; }
    public BlueChipUI BlueChipUI { get; private set; }
    public ShopUI ShopUI { get; private set; }
    public InteractUI InteractUI { get; private set; }
    
    #region ChoiceEvent
    public void RegisterGameUI(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    public void OnGameUI()
    {
        _gameUI.gameObject.SetActive(true);
    }

    public void RequestChangeStage(StageType type)
    {
        _stageCallBack?.Invoke(type);
    }

    public void RegisterChangeStage(MapManager mapManager)
    {
        _mapManager = mapManager;
        _stageCallBack += mapManager.ChangeMap;
    }

    public void UnRegisterChangeStage()
    {
        _stageCallBack = null;
    }

    public float GetProgressValue()
    {
        return _mapManager.ProgressValue;
    }

    #endregion

    #region ProgressUIEvent
    //이 메서드 호출
    public void RequestChangeProgressBar(float currentValue)
    {
        _progressCallBack?.Invoke(currentValue);
    }

    public void RegisterChangeProgressUI(ProgressUIViewModel viewModel)
    {
        _progressCallBack += viewModel.OnResponseChangeCurrentStage;
    }

    public void UnRegisterChangeProgressUI(ProgressUIViewModel viewModel)
    {
        _progressCallBack -= viewModel.OnResponseChangeCurrentStage;
    }
    #endregion

    #region BlueChipEvent
    public void RegisterBlueChipUI(BlueChipUI blueChipUI)
    {
        BlueChipUI = blueChipUI;
    }

    public void ActiveBlueChipUI()
    {
        BlueChipUI.gameObject.SetActive(true);
        InteractUI.gameObject.SetActive(false);
    }

    public void DeActiveBlueChipUI()
    {
        BlueChipUI.gameObject.SetActive(false);
        InteractUI.gameObject.SetActive(true);
    }
    #endregion

    #region ShopEvent
    public void RegisterShopUI(ShopUI shopUI)
    {
        ShopUI = shopUI;
    }

    public void ActiveShopUI()
    {
        ShopUI.gameObject.SetActive(true);
        InteractUI.gameObject.SetActive(false);
    }

    public void DeActiveShopUI()
    {
        ShopUI.gameObject.SetActive(false);
        InteractUI.gameObject.SetActive(true);
    }
    #endregion
    #region
    public void RegisterInteractUI(InteractUI interactUI)
    {
        InteractUI = interactUI;
    }

    public void ActiveInteractUI(string interactStr)
    {
        InteractUI.gameObject.SetActive(true);
        InteractUI.OnSetText(interactStr);
    }

    public void DeActiveInteractUI()
    {
        InteractUI.gameObject.SetActive(false);
    }
    #endregion

    #region PlayerControl
    public void SetActivePlayerControl(bool isActive)
    {
        var input = player.GetComponent<PlayerInput>();
        input.enabled = isActive;
    }
    #endregion

    #region LoadUI
    public void RegisterLoadUI(LoadingUI loadingUI)
    {
        _loadUI = loadingUI;
    }
    #endregion
}


