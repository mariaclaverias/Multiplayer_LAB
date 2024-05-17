using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;

    private NetworkManager netManager;

    private void Awake()
    {
        netManager = GetComponentInParent<NetworkManager>();
    }
    private void Start()
    {
        serverBtn.onClick.AddListener(() => {
            netManager.StartServer();
        });

        hostBtn.onClick.AddListener(() => {
            netManager.StartHost();
        });

        clientBtn.onClick.AddListener(() => {
            netManager.StartClient();
        });
    }
}