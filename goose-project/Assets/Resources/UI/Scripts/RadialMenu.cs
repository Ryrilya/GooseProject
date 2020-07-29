using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RadialMenu : MonoBehaviour
{
    public GameObject menu;
    public TextMeshProUGUI[] texts;
    public ParticleSystem puff;

    private int selectedOption;
    private Vector2 moveInput;
    private GameObject GFX;
    private Party party;
    private GooseDisplay gooseDisplay;
    private Image ringMenuBg;

    private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.Instance;

        GameObject player = GameObject.Find("Player");
        GFX = player.transform.GetChild(0).gameObject;
        party = GameObject.Find("GameManager").GetComponent<Party>();

        gooseDisplay = GFX.GetComponent<GooseDisplay>();

        ringMenuBg = menu.GetComponent<Image>();
        ringMenuBg.fillAmount = 0.2f * party.partyMembers.Length;

        for (int i = 0; i < party.partyMembers.Length; i++)
        {           
            texts[i].text = party.partyMembers[i].name;
            texts[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Activate();

        if (menu.activeInHierarchy)
        {
            // Calculate the mouse position
            moveInput.x = Input.mousePosition.x - (Screen.width / 2);   // take away half of the screen's witdh
            moveInput.y = Input.mousePosition.y - (Screen.height / 2);
            moveInput.Normalize();  // set it from 0 to 1

            if (moveInput != Vector2.zero)
            {
                // calculate the angle in radians
                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;
                angle *= 180;
                angle -= 90f;   // set the circle angle starting from 45°
                if (angle < 0)
                    angle += 360;

                // Debug.Log(angle);

                for (int i = 0; i < party.partyMembers.Length; i++)
                    // Check in which segments we are in
                    if (angle > i * 72 && angle < (i + 1) * 72)
                    {
                        selectedOption = i;
                        menu.transform.GetChild(0).GetComponent<Image>().sprite = party.partyMembers[i].sprite;
                    }
            }

            if (Input.GetMouseButtonDown(0))
            {
                _audioManager.Play("GooseMenuClick");
                Destroy(GFX.transform.GetChild(1).gameObject);
                _audioManager.Play("ChangedGoose");
                puff.Play();

                

                // TODO: cambiare l'oca selezionata con altri scriptable objects
                switch (selectedOption)
                {
                    case 0:
                        gooseDisplay.goose = party.partyMembers[0];
                        gooseDisplay.Spawn();
                        break;

                    case 1:
                        gooseDisplay.goose = party.partyMembers[1];
                        gooseDisplay.Spawn();
                        break;

                    case 2:
                        gooseDisplay.goose = party.partyMembers[2];
                        gooseDisplay.Spawn();
                        break;

                    case 3:
                        gooseDisplay.goose = party.partyMembers[3];
                        gooseDisplay.Spawn();
                        break;

                    case 4:
                        gooseDisplay.goose = party.partyMembers[4];
                        gooseDisplay.Spawn();
                        break;
                }

                menu.SetActive(false);
            }
        }
    }
    private void Activate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!menu.activeSelf)
            {
                _audioManager.Play("GooseMenuOpen");
                menu.SetActive(true);
            }
            else
            {
                _audioManager.Play("GooseMenuClose");
                menu.SetActive(false);
            }
        }
    }
}
