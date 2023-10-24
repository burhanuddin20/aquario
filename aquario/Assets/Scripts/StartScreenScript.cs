using System;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenScript : MonoBehaviour
{
    private ThirdwebSDK sdk;

    public GameObject NoNFT;
    public GameObject HasNFT;
    public GameObject PlayButton;

    public LoadNFTs ownedNFTs;

    public GameObject characterLoader;
    
    
    private string addressSDK;

    private Contract Contract;

    // Start is called before the first frame update
    void Start()
    {
        sdk = ThirdwebManager.Instance.SDK;
        HasNFT.SetActive(false);
        NoNFT.SetActive(false);
        PlayButton.SetActive(false);
        characterLoader.SetActive(false);
    }


    public async void toggleStartScreen(GameObject ConnectedState, GameObject DisconnectedState, string address)
    {
        ConnectedState.SetActive(true);
        DisconnectedState.SetActive(false);
        // move this to a different class any everything can be hidden
        Contract = sdk.GetContract("0xF27Ab5d5e71c165A69879c7fE3eef103d5707f3e");
        
        
        //todo rename 
        List<NFT> owned = await CheckBalance(address, Contract);
        print("NFT balance: " + owned.Count);

        if (owned.Count > 0)
        {
            HasNFT.SetActive(true);
            Debug.Log("Loading all NFTs.....");
            //todo add some loading text or indicator

            LoadingNFTs(owned);
            

            PlayButton.SetActive(true);
        }
        else
        {
            NoNFT.SetActive(true);
        }
    }

    
    public async Task<List<NFT>> CheckBalance(string address,Contract contract)
    {
        var nfts = await contract.ERC1155.GetOwned(address);
        return nfts;
    }

    public void LoadingNFTs(List<NFT> nfts)
    {
        GameObject[] tempCharacters = new GameObject[nfts.Count];
        int i = 0;
    
        foreach (NFT nft in nfts)
        {
            string assetName = nft.metadata.name;
            Debug.Log(assetName);
        
            if (string.IsNullOrEmpty(assetName))
            {
                Debug.LogWarning("Asset name is null or empty!");
                continue; // Skip this NFT and continue with the next one
            }
        
            // Load the corresponding asset from the Resources folder
            GameObject assetPrefab = Resources.Load<GameObject>(assetName);
        
            if (assetPrefab == null)
            {
                Debug.LogWarning($"Asset with name {assetName} not found in Resources folder!");
                continue; // Move onto the next asset
            }
        
            GameObject characterInstance = Instantiate(assetPrefab);
            characterInstance.transform.position = new Vector3(0, -0.4f, 0);
            characterInstance.transform.localScale = new Vector3(2.7f, 2.7f, 1);

            tempCharacters[i] = characterInstance;
            i++;
        }
    
        if (characterLoader != null)
        {
            Debug.Log("Character Loader found!");
            CharacterSelectionScript characterSelection = characterLoader.GetComponent<CharacterSelectionScript>();
            if (characterSelection != null)
            {
                characterSelection.characters = tempCharacters;
                characterLoader.SetActive(true);
            }
            else
            {
                Debug.LogError("Character Selection Script not found on the Character Loader!");
            }
        }
        else
        {
            Debug.LogError("Character Loader is null!");
        }

        Debug.Log($"Temporary characters: {tempCharacters.Length}");
    }

    
    public void LoadGame()
    {
        CharacterSelectionScript.Instance.DisableUnchosenCharacters();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}