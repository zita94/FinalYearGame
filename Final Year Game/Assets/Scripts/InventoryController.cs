using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        // Start is called before the first frame update
        void Start()
        {
            _panel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (PlayerCharacter.IsPaused)
                {
                    _panel.SetActive(!_panel.activeInHierarchy);
                    PlayerCharacter.IsPaused = false;
                }
                else
                {
                    _panel.SetActive(!_panel.activeInHierarchy);
                    PlayerCharacter.IsPaused = true;
                }
            }
        }
    }
}
