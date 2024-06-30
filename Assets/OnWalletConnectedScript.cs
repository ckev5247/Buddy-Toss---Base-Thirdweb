using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Numerics;

public class OnWalletConnectedScript : MonoBehaviour
{
    public string Address { get; private set; }
    public GameObject playButton;
    public GameObject leaderboardPanel;
    public Text bestScore;
    public Button NFTTokenGateButton;
    public Button LeaderboardButton;

    public Text rank1WalletAddress;
    public Text rank2WalletAddress;
    public Text rank3WalletAddress;
    public Text rank4WalletAddress;
    public Text rank5WalletAddress;
    public Text rank1ScoreText;
    public Text rank2ScoreText;
    public Text rank3ScoreText;
    public Text rank4ScoreText;
    public Text rank5ScoreText;
    public Text bestScoreText;

    public Button walletConnectButton;

    private void Start()
    {
        leaderboardPanel.SetActive(false);
        bestScore.gameObject.SetActive(false);
        NFTTokenGateButton.gameObject.SetActive(false);
        LeaderboardButton.gameObject.SetActive(false);
        walletConnectButton.gameObject.SetActive(true);
    }

    public void LeaderboardButtonClick() {
        Debug.Log("Click");
        leaderboardPanel.SetActive(true);
    }

    public void CloseLeaderboardPanel() {
        leaderboardPanel.SetActive(false);
        bestScore.gameObject.SetActive(true);
        playButton.SetActive(true);
        LeaderboardButton.gameObject.SetActive(true);
    }

    public async void Login()
    {
        DisplayLeaderboard();
        GetHighestScore();
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x34F51a49C558c767FcB428e9294DC8765E9b764B");
        List<NFT> nftList = await contract.ERC721.GetOwned(Address);
        if (nftList.Count == 0)
        {
            NFTTokenGateButton.gameObject.SetActive(true);
        }
        else
        {
            NFTTokenGateButton.gameObject.SetActive(false);
            leaderboardPanel.SetActive(true);
        }
    }

    public async void ClaimNFTPass()
    {
        NFTTokenGateButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x34F51a49C558c767FcB428e9294DC8765E9b764B");
        var result = await contract.ERC721.ClaimTo(Address, 1);
        NFTTokenGateButton.gameObject.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    public async void GetHighestScore()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0xA957a6Dd4af3d2f6501cf0044b51d73c761325Af",
            "[{\"type\":\"constructor\",\"name\":\"\",\"inputs\":[],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"event\",\"name\":\"NewHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"PlayerScoreUpdated\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getHighScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getPlayerHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayers\",\"inputs\":[],\"outputs\":[{\"type\":\"tuple[5]\",\"name\":\"\",\"components\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"internalType\":\"struct HighScore.Player[5]\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"highestScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"owner\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"playerHighScores\",\"inputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"setPlayerScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newScore\",\"internalType\":\"uint256\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"topPlayers\",\"inputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"outputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"}]"
            );
        BigInteger highestScoreOfPlayer = await contract.Read<BigInteger>("getPlayerHighScore", Address);
        Debug.Log(highestScoreOfPlayer);
        bestScoreText.text = "Best: " + FormatNumberWithCommas(highestScoreOfPlayer.ToString());
    }

    string FormatNumberWithCommas(string numberString)
    {
        if (long.TryParse(numberString, out long number))
        {
            return number.ToString("N0");
        }
        else
        {
            return numberString;
        }
    }

    string ShortenString(string input)
    {
        if (input.Length <= 10)
        {
            return input;
        }
        return input.Substring(0, 6) + "…" + input.Substring(input.Length - 4);
    }

    public async void DisplayLeaderboard()
    {
        var contract = ThirdwebManager.Instance.SDK.GetContract(
           "0xA957a6Dd4af3d2f6501cf0044b51d73c761325Af",
           "[{\"type\":\"constructor\",\"name\":\"\",\"inputs\":[],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"event\",\"name\":\"NewHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"PlayerScoreUpdated\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"getHighScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getPlayerHighScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer1Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer2Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer3Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer4Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Address\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayer5Score\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"getTopPlayers\",\"inputs\":[],\"outputs\":[{\"type\":\"tuple[5]\",\"name\":\"\",\"components\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"internalType\":\"struct HighScore.Player[5]\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"highestScore\",\"inputs\":[],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"owner\",\"inputs\":[],\"outputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"playerHighScores\",\"inputs\":[{\"type\":\"address\",\"name\":\"\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"setPlayerScore\",\"inputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newScore\",\"internalType\":\"uint256\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"topPlayers\",\"inputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"outputs\":[{\"type\":\"address\",\"name\":\"playerAddress\",\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"score\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"}]"
           );
        rank1WalletAddress.text = ShortenString(await contract.Read<string>("getTopPlayer1Address"));
        rank2WalletAddress.text = ShortenString(await contract.Read<string>("getTopPlayer2Address"));
        rank3WalletAddress.text = ShortenString(await contract.Read<string>("getTopPlayer3Address"));
        rank4WalletAddress.text = ShortenString(await contract.Read<string>("getTopPlayer4Address"));
        rank5WalletAddress.text = ShortenString(await contract.Read<string>("getTopPlayer5Address"));
        rank1ScoreText.text = FormatNumberWithCommas(await contract.Read<string>("getTopPlayer1Score"));
        rank2ScoreText.text = FormatNumberWithCommas(await contract.Read<string>("getTopPlayer2Score"));
        rank3ScoreText.text = FormatNumberWithCommas(await contract.Read<string>("getTopPlayer3Score"));
        rank4ScoreText.text = FormatNumberWithCommas(await contract.Read<string>("getTopPlayer4Score"));
        rank5ScoreText.text = FormatNumberWithCommas(await contract.Read<string>("getTopPlayer5Score"));
    }
}
