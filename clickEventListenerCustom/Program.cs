public class clickEventListenerCustom
{
    public static void Main(String[] args)
    {
        OnBitcoinMining bitcoinMining = new OnBitcoinMining();

        bitcoinMining.onReceivingRewards += BitcoinMining_onReceivingRewards;
        bitcoinMining.onBitcoinminingComplete += BitcoinMining_onBitcoinminingComplete;
        bitcoinMining.bitCoin();
        
    }

    private static void BitcoinMining_onReceivingRewards(object? sender, OnBitcoinMining.miniEventArgs e)
    {
        Console.WriteLine("Rewards are {0} ",e.Rewards);
    }

    private static void BitcoinMining_onBitcoinminingComplete(object? sender, EventArgs e)
    {
        Console.WriteLine("Mining Completed");
    }

    public class OnBitcoinMining 
    {
        public class miniEventArgs : EventArgs
        {
            public int Rewards { get; set; }
        }
        public event EventHandler<miniEventArgs> onReceivingRewards;
        public event EventHandler onBitcoinminingComplete;
        public void bitCoin()
        {
            int rewards = 99987;
            for(int i=0;i<6000;i++)
            {
                Console.WriteLine("Bitcoin mining {0}", i);
            }
            onBitcoinminingComplete?.Invoke(this,new EventArgs());
            onReceivingRewards?.Invoke(this,  new miniEventArgs { Rewards= rewards });
        }
    }
}