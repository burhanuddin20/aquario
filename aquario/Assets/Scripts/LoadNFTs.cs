using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using Thirdweb;


[Serializable]
public class LoadNFTs : MonoBehaviour
{
    [Header("SETTINGS")] public NFTQuery query;


    public async Task<List<NFT>> LoadImages()
    {
        List<NFT> nftsToLoad = new List<NFT>();


        try
        {
            foreach (OwnedQuery ownedQuery in query.loadOwnedNfts)
            {
                Contract tempContract = ThirdwebManager.Instance.SDK.GetContract(ownedQuery.contractAddress);

                List<NFT> tempNFTList = ownedQuery.type == NFTType.ERC1155
                    ? await tempContract.ERC1155.GetOwned(ownedQuery.owner)
                    : await tempContract.ERC721.GetOwned(ownedQuery.owner);

                nftsToLoad.AddRange(tempNFTList);
            }

        }
        catch (Exception e)
        {
            print($"Error Loading OwnedQuery NFTs: {e.Message}");
        }
        return nftsToLoad;
    }
}