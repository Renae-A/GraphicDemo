using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionList : MonoBehaviour {

    public List<Action> actions = new List<Action>();
    public UIAction uiPrefab;
    public Player player;

    Dictionary<Action, UIAction> uiActions = new Dictionary<Action, UIAction>();

    private void Start()
    {
        uiPrefab.gameObject.SetActive(false);
        SetActions(player);
    }

    public void SetActions(Player p)
    {
        actions = p.actions;
        UpdateActions();
    }

    void UpdateActions()
    {
        List<Action> graveyard = new List<Action>();

        foreach (KeyValuePair<Action, UIAction> pair in uiActions)
        {
            if (actions.Contains(pair.Key))
            {
                graveyard.Add(pair.Key);
            }
        }

        foreach (Action a in graveyard)
        {
            Destroy(uiActions[a].gameObject);
            uiActions.Remove(a);
        }

        foreach (Action a in actions)
        {
            if (uiActions.ContainsKey(a))
            {
                GameObject action = Instantiate(uiPrefab.gameObject, transform);
                action.SetActive(true);
                uiActions[a] = action.GetComponent<UIAction>();
                uiActions[a].SetAction(a);
            }
        }
    }

    IEnumerator UpdateSize()
    {
        yield return new WaitForEndOfFrame();
        RectTransform rect = GetComponent<RectTransform>();
        LayoutGroup layout = GetComponent<LayoutGroup>();
        if (layout)
        {
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, layout.preferredWidth);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, layout.preferredHeight);
        }

        yield return null;
    }
}
