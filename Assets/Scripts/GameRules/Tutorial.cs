using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private interface ITutorialState
    {
        public void OnEnter();
        public void OnExit();
        public ITutorialState Update();
    }

    public static GameObject FindTutorial(string name)
    {
        var gameObjects = FindObjectsOfType<GameObject>(true);

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == name)
            {
                return gameObject;
            }
        }

        return null;
    }

    private class Introduction : ITutorialState
    {
        private GameObject m_Introduction;

        private GameState m_GameState;

        public void OnEnter()
        {
            m_Introduction = FindTutorial("BasicTutorial");
            m_Introduction.SetActive(true);
            m_GameState = FindFirstObjectByType<GameState>();
        }

        public void OnExit()
        {
            m_Introduction.SetActive(false);
        }

        public ITutorialState Update()
        {
            if (m_GameState.state == GameState.State.ForgingStation)
            {
                Debug.Log("tutorial basic complete");
                return new Forging();
            }

            return null;
        }
    }

    private class Forging : ITutorialState
    {
        private GameObject m_Forging;

        private Inventory m_Inventory;

        public void OnEnter()
        {
            m_Forging = FindTutorial("ForgingTutorial");
            m_Forging.SetActive(true);
            m_Inventory = FindFirstObjectByType<Inventory>();
        }

        public void OnExit()
        {
            m_Forging.SetActive(false);
        }

        public ITutorialState Update()
        {
            if (m_Inventory.hasBlade)
            {
                Debug.Log("tutorial blade complete");
                return new Dyeing();
            }

            return null;
        }
    }

    private class Dyeing : ITutorialState
    {
        private GameObject m_Dyeing;

        private Inventory m_Inventory;
        private OrderQueue m_OrderQueue;

        public void OnEnter()
        {
            m_Dyeing = FindTutorial("DyeingTutorial");
            m_Dyeing.SetActive(true);
            m_Inventory = FindFirstObjectByType<Inventory>();
            m_OrderQueue = FindFirstObjectByType<OrderQueue>();

            m_OrderQueue.AddOrder(1, OrderQueue.Order.OrderType.slow);
        }

        public void OnExit()
        {
            m_Dyeing.SetActive(false);
        }

        public ITutorialState Update()
        {
            if (m_Inventory.hasHandle)
            {
                Debug.Log("tutorial dyeing complete");
                return new Combining();
            }

            return null;
        }
    }

    private class Combining : ITutorialState
    {
        private GameObject m_Combining;

        private Inventory m_Inventory;

        public void OnEnter()
        {
            m_Combining = FindTutorial("CombiningTutorial");
            m_Combining.SetActive(true);
            m_Inventory = FindFirstObjectByType<Inventory>();
        }

        public void OnExit()
        {
            m_Combining.SetActive(false);
        }

        public ITutorialState Update()
        {
            if (m_Inventory.hasSword)
            {
                Debug.Log("tutorial combining complete");
                return new Selling();
            }

            return null;
        }
    }

    private class Selling : ITutorialState
    {
        private GameObject m_Selling;

        private OrderQueue m_OrderQueue;

        public void OnEnter()
        {
            m_Selling = FindTutorial("SellingTutorial");
            m_Selling.SetActive(true);
            m_OrderQueue = FindFirstObjectByType<OrderQueue>();
        }

        public void OnExit()
        {
            m_Selling.SetActive(false);
        }

        public ITutorialState Update()
        {
            if (m_OrderQueue.orders.Count == 0)
            {
                Debug.Log("finished tutorial");
                return new EndState();
            }

            return null;
        }
    }

    private class EndState : ITutorialState
    {
        private GameObject m_End;

        public void OnEnter()
        {
            m_End = FindTutorial("EndTutorial");
            m_End.SetActive(true);
        }

        public void OnExit()
        {
            m_End.SetActive(false);
        }

        public ITutorialState Update()
        {
            return null;
        }
    }

    private class TutorialStateManager
    {
        private ITutorialState m_TutorialState;

        public void SetTutorialState(ITutorialState tutorialState)
        {
            if (m_TutorialState != null)
            {
                m_TutorialState.OnExit();
            }
            m_TutorialState = tutorialState;
            if (m_TutorialState != null)
            {
                m_TutorialState.OnEnter();
            }
        }

        public void Update()
        {
            ITutorialState newState = m_TutorialState.Update();

            if (newState != null)
            {
                SetTutorialState(newState);
            }
        }
    }

    private TutorialStateManager m_TutorialStateManager;

    void Start()
    {
        m_TutorialStateManager = new TutorialStateManager();

        m_TutorialStateManager.SetTutorialState(new Introduction());
    }

    void FixedUpdate()
    {
        m_TutorialStateManager.Update();
    }
}
