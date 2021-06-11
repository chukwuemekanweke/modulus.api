using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.ContractHandlers;
using System.Threading;
using BulkSender.Contracts.ForwarderProxy.ContractDefinition;

namespace BulkSender.Contracts.ForwarderProxy
{
    public partial class ForwarderProxyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ForwarderProxyDeployment forwarderProxyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ForwarderProxyDeployment>().SendRequestAndWaitForReceiptAsync(forwarderProxyDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ForwarderProxyDeployment forwarderProxyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ForwarderProxyDeployment>().SendRequestAsync(forwarderProxyDeployment);
        }

        public static async Task<ForwarderProxyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ForwarderProxyDeployment forwarderProxyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, forwarderProxyDeployment, cancellationTokenSource);
            return new ForwarderProxyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ForwarderProxyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ActivateDataReaderRequestAsync(ActivateDataReaderFunction activateDataReaderFunction)
        {
             return ContractHandler.SendRequestAsync(activateDataReaderFunction);
        }

        public Task<TransactionReceipt> ActivateDataReaderRequestAndWaitForReceiptAsync(ActivateDataReaderFunction activateDataReaderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateDataReaderFunction, cancellationToken);
        }

        public Task<string> ActivateDataReaderRequestAsync(string reader)
        {
            var activateDataReaderFunction = new ActivateDataReaderFunction();
                activateDataReaderFunction.Reader = reader;
            
             return ContractHandler.SendRequestAsync(activateDataReaderFunction);
        }

        public Task<TransactionReceipt> ActivateDataReaderRequestAndWaitForReceiptAsync(string reader, CancellationTokenSource cancellationToken = null)
        {
            var activateDataReaderFunction = new ActivateDataReaderFunction();
                activateDataReaderFunction.Reader = reader;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateDataReaderFunction, cancellationToken);
        }

        public Task<string> ActivateDataWriterRequestAsync(ActivateDataWriterFunction activateDataWriterFunction)
        {
             return ContractHandler.SendRequestAsync(activateDataWriterFunction);
        }

        public Task<TransactionReceipt> ActivateDataWriterRequestAndWaitForReceiptAsync(ActivateDataWriterFunction activateDataWriterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateDataWriterFunction, cancellationToken);
        }

        public Task<string> ActivateDataWriterRequestAsync(string writer)
        {
            var activateDataWriterFunction = new ActivateDataWriterFunction();
                activateDataWriterFunction.Writer = writer;
            
             return ContractHandler.SendRequestAsync(activateDataWriterFunction);
        }

        public Task<TransactionReceipt> ActivateDataWriterRequestAndWaitForReceiptAsync(string writer, CancellationTokenSource cancellationToken = null)
        {
            var activateDataWriterFunction = new ActivateDataWriterFunction();
                activateDataWriterFunction.Writer = writer;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateDataWriterFunction, cancellationToken);
        }

        public Task<string> ActivateFullAccessRequestAsync(ActivateFullAccessFunction activateFullAccessFunction)
        {
             return ContractHandler.SendRequestAsync(activateFullAccessFunction);
        }

        public Task<TransactionReceipt> ActivateFullAccessRequestAndWaitForReceiptAsync(ActivateFullAccessFunction activateFullAccessFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateFullAccessFunction, cancellationToken);
        }

        public Task<string> ActivateFullAccessRequestAsync(string acessor)
        {
            var activateFullAccessFunction = new ActivateFullAccessFunction();
                activateFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAsync(activateFullAccessFunction);
        }

        public Task<TransactionReceipt> ActivateFullAccessRequestAndWaitForReceiptAsync(string acessor, CancellationTokenSource cancellationToken = null)
        {
            var activateFullAccessFunction = new ActivateFullAccessFunction();
                activateFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(activateFullAccessFunction, cancellationToken);
        }

        public Task<string> DeactivateDataReaderRequestAsync(DeactivateDataReaderFunction deactivateDataReaderFunction)
        {
             return ContractHandler.SendRequestAsync(deactivateDataReaderFunction);
        }

        public Task<TransactionReceipt> DeactivateDataReaderRequestAndWaitForReceiptAsync(DeactivateDataReaderFunction deactivateDataReaderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateDataReaderFunction, cancellationToken);
        }

        public Task<string> DeactivateDataReaderRequestAsync(string reader)
        {
            var deactivateDataReaderFunction = new DeactivateDataReaderFunction();
                deactivateDataReaderFunction.Reader = reader;
            
             return ContractHandler.SendRequestAsync(deactivateDataReaderFunction);
        }

        public Task<TransactionReceipt> DeactivateDataReaderRequestAndWaitForReceiptAsync(string reader, CancellationTokenSource cancellationToken = null)
        {
            var deactivateDataReaderFunction = new DeactivateDataReaderFunction();
                deactivateDataReaderFunction.Reader = reader;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateDataReaderFunction, cancellationToken);
        }

        public Task<string> DeactivateDataWriterRequestAsync(DeactivateDataWriterFunction deactivateDataWriterFunction)
        {
             return ContractHandler.SendRequestAsync(deactivateDataWriterFunction);
        }

        public Task<TransactionReceipt> DeactivateDataWriterRequestAndWaitForReceiptAsync(DeactivateDataWriterFunction deactivateDataWriterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateDataWriterFunction, cancellationToken);
        }

        public Task<string> DeactivateDataWriterRequestAsync(string writer)
        {
            var deactivateDataWriterFunction = new DeactivateDataWriterFunction();
                deactivateDataWriterFunction.Writer = writer;
            
             return ContractHandler.SendRequestAsync(deactivateDataWriterFunction);
        }

        public Task<TransactionReceipt> DeactivateDataWriterRequestAndWaitForReceiptAsync(string writer, CancellationTokenSource cancellationToken = null)
        {
            var deactivateDataWriterFunction = new DeactivateDataWriterFunction();
                deactivateDataWriterFunction.Writer = writer;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateDataWriterFunction, cancellationToken);
        }

        public Task<string> DeactivateFullAccessRequestAsync(DeactivateFullAccessFunction deactivateFullAccessFunction)
        {
             return ContractHandler.SendRequestAsync(deactivateFullAccessFunction);
        }

        public Task<TransactionReceipt> DeactivateFullAccessRequestAndWaitForReceiptAsync(DeactivateFullAccessFunction deactivateFullAccessFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateFullAccessFunction, cancellationToken);
        }

        public Task<string> DeactivateFullAccessRequestAsync(string acessor)
        {
            var deactivateFullAccessFunction = new DeactivateFullAccessFunction();
                deactivateFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAsync(deactivateFullAccessFunction);
        }

        public Task<TransactionReceipt> DeactivateFullAccessRequestAndWaitForReceiptAsync(string acessor, CancellationTokenSource cancellationToken = null)
        {
            var deactivateFullAccessFunction = new DeactivateFullAccessFunction();
                deactivateFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deactivateFullAccessFunction, cancellationToken);
        }

        public Task<string> DeprecateRequestAsync(DeprecateFunction deprecateFunction)
        {
             return ContractHandler.SendRequestAsync(deprecateFunction);
        }

        public Task<string> DeprecateRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DeprecateFunction>();
        }

        public Task<TransactionReceipt> DeprecateRequestAndWaitForReceiptAsync(DeprecateFunction deprecateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(deprecateFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DeprecateRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DeprecateFunction>(null, cancellationToken);
        }

        public Task<string> DistributeNativeCoinRequestAsync(DistributeNativeCoinFunction distributeNativeCoinFunction)
        {
             return ContractHandler.SendRequestAsync(distributeNativeCoinFunction);
        }

        public Task<TransactionReceipt> DistributeNativeCoinRequestAndWaitForReceiptAsync(DistributeNativeCoinFunction distributeNativeCoinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeNativeCoinFunction, cancellationToken);
        }

        public Task<string> DistributeNativeCoinRequestAsync(BigInteger batchId, string sender, List<string> addresses, List<BigInteger> amounts)
        {
            var distributeNativeCoinFunction = new DistributeNativeCoinFunction();
                distributeNativeCoinFunction.BatchId = batchId;
                distributeNativeCoinFunction.Sender = sender;
                distributeNativeCoinFunction.Addresses = addresses;
                distributeNativeCoinFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAsync(distributeNativeCoinFunction);
        }

        public Task<TransactionReceipt> DistributeNativeCoinRequestAndWaitForReceiptAsync(BigInteger batchId, string sender, List<string> addresses, List<BigInteger> amounts, CancellationTokenSource cancellationToken = null)
        {
            var distributeNativeCoinFunction = new DistributeNativeCoinFunction();
                distributeNativeCoinFunction.BatchId = batchId;
                distributeNativeCoinFunction.Sender = sender;
                distributeNativeCoinFunction.Addresses = addresses;
                distributeNativeCoinFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeNativeCoinFunction, cancellationToken);
        }

        public Task<string> DistributeTokenRequestAsync(DistributeTokenFunction distributeTokenFunction)
        {
             return ContractHandler.SendRequestAsync(distributeTokenFunction);
        }

        public Task<TransactionReceipt> DistributeTokenRequestAndWaitForReceiptAsync(DistributeTokenFunction distributeTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeTokenFunction, cancellationToken);
        }

        public Task<string> DistributeTokenRequestAsync(BigInteger batchId, string sender, string tokenAddress, List<string> addresses, List<BigInteger> amounts)
        {
            var distributeTokenFunction = new DistributeTokenFunction();
                distributeTokenFunction.BatchId = batchId;
                distributeTokenFunction.Sender = sender;
                distributeTokenFunction.TokenAddress = tokenAddress;
                distributeTokenFunction.Addresses = addresses;
                distributeTokenFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAsync(distributeTokenFunction);
        }

        public Task<TransactionReceipt> DistributeTokenRequestAndWaitForReceiptAsync(BigInteger batchId, string sender, string tokenAddress, List<string> addresses, List<BigInteger> amounts, CancellationTokenSource cancellationToken = null)
        {
            var distributeTokenFunction = new DistributeTokenFunction();
                distributeTokenFunction.BatchId = batchId;
                distributeTokenFunction.Sender = sender;
                distributeTokenFunction.TokenAddress = tokenAddress;
                distributeTokenFunction.Addresses = addresses;
                distributeTokenFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeTokenFunction, cancellationToken);
        }

        public Task<string> GetDnsContractAddressQueryAsync(GetDnsContractAddressFunction getDnsContractAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDnsContractAddressFunction, string>(getDnsContractAddressFunction, blockParameter);
        }

        
        public Task<string> GetDnsContractAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDnsContractAddressFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> ReAssignFullAccessRequestAsync(ReAssignFullAccessFunction reAssignFullAccessFunction)
        {
             return ContractHandler.SendRequestAsync(reAssignFullAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignFullAccessRequestAndWaitForReceiptAsync(ReAssignFullAccessFunction reAssignFullAccessFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignFullAccessFunction, cancellationToken);
        }

        public Task<string> ReAssignFullAccessRequestAsync(string acessor)
        {
            var reAssignFullAccessFunction = new ReAssignFullAccessFunction();
                reAssignFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAsync(reAssignFullAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignFullAccessRequestAndWaitForReceiptAsync(string acessor, CancellationTokenSource cancellationToken = null)
        {
            var reAssignFullAccessFunction = new ReAssignFullAccessFunction();
                reAssignFullAccessFunction.Acessor = acessor;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignFullAccessFunction, cancellationToken);
        }

        public Task<string> ReAssignReadAccessRequestAsync(ReAssignReadAccessFunction reAssignReadAccessFunction)
        {
             return ContractHandler.SendRequestAsync(reAssignReadAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignReadAccessRequestAndWaitForReceiptAsync(ReAssignReadAccessFunction reAssignReadAccessFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignReadAccessFunction, cancellationToken);
        }

        public Task<string> ReAssignReadAccessRequestAsync(string reader)
        {
            var reAssignReadAccessFunction = new ReAssignReadAccessFunction();
                reAssignReadAccessFunction.Reader = reader;
            
             return ContractHandler.SendRequestAsync(reAssignReadAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignReadAccessRequestAndWaitForReceiptAsync(string reader, CancellationTokenSource cancellationToken = null)
        {
            var reAssignReadAccessFunction = new ReAssignReadAccessFunction();
                reAssignReadAccessFunction.Reader = reader;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignReadAccessFunction, cancellationToken);
        }

        public Task<string> ReAssignWriteAccessRequestAsync(ReAssignWriteAccessFunction reAssignWriteAccessFunction)
        {
             return ContractHandler.SendRequestAsync(reAssignWriteAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignWriteAccessRequestAndWaitForReceiptAsync(ReAssignWriteAccessFunction reAssignWriteAccessFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignWriteAccessFunction, cancellationToken);
        }

        public Task<string> ReAssignWriteAccessRequestAsync(string writer)
        {
            var reAssignWriteAccessFunction = new ReAssignWriteAccessFunction();
                reAssignWriteAccessFunction.Writer = writer;
            
             return ContractHandler.SendRequestAsync(reAssignWriteAccessFunction);
        }

        public Task<TransactionReceipt> ReAssignWriteAccessRequestAndWaitForReceiptAsync(string writer, CancellationTokenSource cancellationToken = null)
        {
            var reAssignWriteAccessFunction = new ReAssignWriteAccessFunction();
                reAssignWriteAccessFunction.Writer = writer;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reAssignWriteAccessFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> UpdateDnsContractAddressRequestAsync(UpdateDnsContractAddressFunction updateDnsContractAddressFunction)
        {
             return ContractHandler.SendRequestAsync(updateDnsContractAddressFunction);
        }

        public Task<TransactionReceipt> UpdateDnsContractAddressRequestAndWaitForReceiptAsync(UpdateDnsContractAddressFunction updateDnsContractAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDnsContractAddressFunction, cancellationToken);
        }

        public Task<string> UpdateDnsContractAddressRequestAsync(string dnsContractAddress)
        {
            var updateDnsContractAddressFunction = new UpdateDnsContractAddressFunction();
                updateDnsContractAddressFunction.DnsContractAddress = dnsContractAddress;
            
             return ContractHandler.SendRequestAsync(updateDnsContractAddressFunction);
        }

        public Task<TransactionReceipt> UpdateDnsContractAddressRequestAndWaitForReceiptAsync(string dnsContractAddress, CancellationTokenSource cancellationToken = null)
        {
            var updateDnsContractAddressFunction = new UpdateDnsContractAddressFunction();
                updateDnsContractAddressFunction.DnsContractAddress = dnsContractAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDnsContractAddressFunction, cancellationToken);
        }

        public Task<string> WithdrawNativeCoinRequestAsync(WithdrawNativeCoinFunction withdrawNativeCoinFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawNativeCoinFunction);
        }

        public Task<string> WithdrawNativeCoinRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawNativeCoinFunction>();
        }

        public Task<TransactionReceipt> WithdrawNativeCoinRequestAndWaitForReceiptAsync(WithdrawNativeCoinFunction withdrawNativeCoinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawNativeCoinFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawNativeCoinRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawNativeCoinFunction>(null, cancellationToken);
        }

        public Task<string> WithdrawTokenRequestAsync(WithdrawTokenFunction withdrawTokenFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(WithdrawTokenFunction withdrawTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }

        public Task<string> WithdrawTokenRequestAsync(string tokenAddress)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.TokenAddress = tokenAddress;
            
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(string tokenAddress, CancellationTokenSource cancellationToken = null)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.TokenAddress = tokenAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }
    }
}
