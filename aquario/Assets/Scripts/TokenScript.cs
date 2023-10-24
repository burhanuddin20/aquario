using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.SceneManagement;

public class TokenScript : MonoBehaviour
{
    public ScoreManager scoreManager;


    public GameObject hasNotClaimedState;
    public GameObject claimingState;
    public GameObject hasClaimedState;

    [SerializeField] private TMPro.TextMeshProUGUI tokenBalanceText;
    [SerializeField] public TMPro.TextMeshProUGUI gemsEarnedText;
    
    private const string TokenContractAddress = "0x421355DF1bC7554591AdD4878272719ce554B81D";
    
    public int gemsToClaim;

    void Start()
    {
        hasNotClaimedState.SetActive(true);
        claimingState.SetActive(false);
        hasClaimedState.SetActive(false);
    }

    void Update()
    {
        gemsEarnedText.text = "Gems Earned: " + scoreManager.gems;
        gemsToClaim = scoreManager.gems;
    }

    // todo Decide when to run token Balance and reset function
    public async void GetTokenBalance()
    {
        try
        {
            // get wallet address
            var walletAddress = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            // get contract
            // might need abi because 
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(TokenContractAddress);
            // get token balance
            var data = await contract.ERC20.BalanceOf(walletAddress);
            // output to system
            tokenBalanceText.text = $"$Gem: {data.displayValue}";
        }
        catch (System.Exception)
        {
            Debug.Log("Error getting token Balance");
        }
    }

    public void resetBalance()
    {
        tokenBalanceText.text = "$Gem: {0}";
    }

    public async void MintERC20()
    {
        Debug.Log("Minting ERC20");
        Contract contract = ThirdwebManager.Instance.SDK.GetContract(TokenContractAddress);
        Debug.Log($"RPC session: {ThirdwebManager.Instance.SDK.session.RPC}");
        hasNotClaimedState.SetActive(false);
        claimingState.SetActive(true);
        Debug.Log($"Token Contract Address{contract.address}");
        Debug.Log($"contract: {contract.GetHashCode()}");
        Debug.Log($"Gems to claim: {gemsToClaim.ToString()}");
        //var results = await contract.ERC20.Mint(gemsToClaim.ToString());
        var results = await contract.ERC20.Claim(gemsToClaim.ToString());
        Debug.Log("ERC20 Minted");
        GetTokenBalance();
        claimingState.SetActive(false);
        hasClaimedState.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}