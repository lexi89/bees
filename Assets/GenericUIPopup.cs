using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenericUIPopup : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _header;
    [SerializeField] TextMeshProUGUI _body;
    [SerializeField] Image _icon;
    [SerializeField] GameObject _secondaryBtn;
    Action primaryCallback;
    Action secondaryCallback;
    Action closeCallback;
    
    public void SetupAndShowUI(string headerText, string bodyText, Sprite iconSprite = null, Action newPrimaryBtnCallback = null, Action newSecondaryBtnCallback = null, Action newCloseCallback = null)
    {
        _header.text = headerText;
        _icon.gameObject.SetActive(iconSprite != null);
        _icon.sprite = iconSprite;
        _body.text = bodyText;
        primaryCallback = newPrimaryBtnCallback ?? Hide;
        _secondaryBtn.SetActive(newSecondaryBtnCallback != null);
        secondaryCallback = newSecondaryBtnCallback;
        closeCallback = newCloseCallback;
        gameObject.SetActive(true);
    }

    public void OnPrimaryBtnPressed()
    {
        if (primaryCallback != null) primaryCallback();
        Hide();
    }

    public void OnSecondaryBtnPressed()
    {
        if (secondaryCallback != null) secondaryCallback();
        Hide();
    }

    public void OnClosePressed()
    {
        if (closeCallback != null) closeCallback();
        Hide();
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
