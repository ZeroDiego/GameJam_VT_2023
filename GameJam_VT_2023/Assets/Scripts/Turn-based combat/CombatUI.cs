using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private SkillController skillController;
    [SerializeField] private TurnController turnController;

    [SerializeField] private Button zioButton;
    [SerializeField] private Button garuButton;
    [SerializeField] private Button bufuButton;
    [SerializeField] private Button[] targetButtons;

    [SerializeField] private GameObject buttonPrefab;

    [SerializeField] private Entity yu;
    [SerializeField] private Entity[] targets;

    private void Awake()
    {
        Array.Resize(ref targetButtons, targets.Length);

        for (int i = 0; i < targets.Length; i++)
        {
            GameObject targetGameObject = Instantiate(buttonPrefab);
            targetGameObject.transform.position = gameObject.GetComponentInChildren<RectTransform>().position;
            targetGameObject.GetComponent<RectTransform>().SetParent(gameObject.transform);
            Debug.Log(i);
            targetButtons[i] = targetGameObject.GetComponent<Button>();
            targetButtons[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        zioButton.gameObject.SetActive(false);
        garuButton.gameObject.SetActive(false);
        bufuButton.gameObject.SetActive(false);
    }

    public void ShowSkillUI(Entity user)
    {
        if (user != null)
        {
            if (user.entityName.Equals("Yu Narukami"))
            {
                zioButton.onClick.AddListener(delegate { ChooseTarget(user); });
                zioButton.gameObject.SetActive(true);
            }
            else if (user.entityName.Equals("Yosuke Hanamura"))
            {
                garuButton.onClick.AddListener(delegate { ChooseTarget(user); });
                garuButton.gameObject.SetActive(true);
            }
            else if (user.entityName.Equals("Chie Satonaka"))
            {
                bufuButton.onClick.AddListener(delegate { ChooseTarget(user); });
                bufuButton.gameObject.SetActive(true);
            }
            else
            {
                skillController.LastResort(user, yu);
            }
        }
        else
        {
            zioButton.gameObject.SetActive(false);
            garuButton.gameObject.SetActive(false);
            bufuButton.gameObject.SetActive(false);

            foreach (Button targetButton in targetButtons)
            {
                targetButton.gameObject.SetActive(false);
            }
        }
    }

    private void ChooseTarget(Entity user)
    {
        for (int i = 0; i < targetButtons.Length; i++)
        {
            if (user.entityName.Equals("Yu Narukami"))
                targetButtons[i].onClick.AddListener(delegate { skillController.Zio(user, targets[i - 1]); });
            else if (user.entityName.Equals("Yosuke Hanamura"))
                targetButtons[i].onClick.AddListener(delegate { skillController.Garu(user, targets[i - 1]); });
            else if (user.entityName.Equals("Chie Satonaka"))
                targetButtons[i].onClick.AddListener(delegate { skillController.Bufu(user, targets[i - 1]); });
            targetButtons[i].gameObject.SetActive(true);
        }
    }
}
