using NBitcoin;
using System.Collections.Generic;
using WalletWasabi.Blockchain.TransactionOutputs;
using WalletWasabi.Blockchain.Transactions;
using WalletWasabi.Helpers;
using WalletWasabi.Stores;

namespace WalletWasabi.Blockchain.TransactionBuilding
{
	public class BuildTransactionResult
	{
		public BuildTransactionResult(BitcoinStore store, Network network, SmartTransaction transaction, PSBT psbt, bool spendsUnconfirmed, bool signed, Money fee, decimal feePercentOfSent, IEnumerable<SmartCoin> outerWalletOutputs, IEnumerable<SmartCoin> innerWalletOutputs, IEnumerable<SmartCoin> spentCoins)
		{
			Store = Guard.NotNull(nameof(store), store);
			Network = Guard.NotNull(nameof(network), network);
			Transaction = Guard.NotNull(nameof(transaction), transaction);
			Psbt = Guard.NotNull(nameof(psbt), psbt);
			SpendsUnconfirmed = spendsUnconfirmed;
			Signed = signed;
			Fee = fee ?? Money.Zero;
			FeePercentOfSent = feePercentOfSent;
			OuterWalletOutputs = outerWalletOutputs ?? new List<SmartCoin>();
			InnerWalletOutputs = innerWalletOutputs ?? new List<SmartCoin>();
			SpentCoins = Guard.NotNullOrEmpty(nameof(spentCoins), spentCoins);
		}
		public BitcoinStore Store { get; }
		public Network Network { get; }
		public SmartTransaction Transaction { get; }
		public PSBT Psbt { get; }
		public bool SpendsUnconfirmed { get; }
		public bool Signed { get; }
		public Money Fee { get; }
		public decimal FeePercentOfSent { get; }
		public IEnumerable<SmartCoin> OuterWalletOutputs { get; }
		public IEnumerable<SmartCoin> InnerWalletOutputs { get; }
		public IEnumerable<SmartCoin> SpentCoins { get; }
	}
}
