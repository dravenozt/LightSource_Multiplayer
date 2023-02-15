using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Mirror;
using UnityEngine.SceneManagement;

public class SteamLobby : MonoBehaviour
{
    private NetworkManager networkManager;
    public GameObject buttons;
    private const string hostAdressKey = "HostAdress";
    protected Callback<LobbyCreated_t> lobbyCreated;
    protected Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequested;
    protected Callback<LobbyEnter_t> lobbyEntered;

    private void Start() {
        networkManager= GetComponent<NetworkManager>();

        if (!SteamManager.Initialized)
        {   
            buttons.SetActive(false);
            return;
        }

        lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        gameLobbyJoinRequested= Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);

        lobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);


    }


    public void HostLobby(){
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly,networkManager.maxConnections);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );

    }

    private void OnLobbyCreated(LobbyCreated_t callback){
        if (callback.m_eResult != EResult.k_EResultOK)
        {   

            buttons.SetActive(true);
            return;
        }

        networkManager.StartHost();

        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby),hostAdressKey,SteamUser.GetSteamID().ToString());
    }


    private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback){
        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
    }


    
    private void OnLobbyEntered(LobbyEnter_t callback){
        if (NetworkServer.active)
        {
            return;
        }

        string hostAdress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby),hostAdressKey);
        networkManager.networkAddress= hostAdress;
        networkManager.StartClient();
        //buttons.SetActive(false);
    }
}
