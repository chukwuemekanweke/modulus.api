using BulkSenderAPI.Web3Integration.Models;
using Nethereum.BlockchainProcessing.BlockStorage.Entities.Mapping;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkSenderAPI.Web3Integration
{
    public class Web3Utility
    {
        private readonly Web3 _web3;

        public Web3Utility(Web3 web3)
        {
            _web3 = web3;
        }

        public ValidWalletAddressResponse IsValidAddress(string walletAddress)
        {
            AddressUtil addressUtil = new AddressUtil();
            bool isValid = addressUtil.IsNotAnEmptyAddress(walletAddress) &&
            addressUtil.IsValidEthereumAddressHexFormat(walletAddress) &&
            addressUtil.IsValidAddressLength(walletAddress);

            if (!isValid)
            {
                return new ValidWalletAddressResponse(false,null);
            }

            if (!addressUtil.IsChecksumAddress(walletAddress))
            {
                walletAddress = addressUtil.ConvertToChecksumAddress(walletAddress);
            }

            return new ValidWalletAddressResponse(true, walletAddress);           
        }

        public async Task<ulong> GetLatestBlockNumberAsync(string nodeUrl)
        {
            HexBigInteger blockNumber = await _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            return ulong.Parse(blockNumber.Value.ToString());
        }
    }
}
