using System;

namespace modul7_1302204081
{
    public class Program
    {

		static void Main(string[] args)
        {
			try
			{
            BankTransferConfig config = new BankTransferConfig();
            config.config();
			}catch(Exception ex)
			{
                Console.WriteLine(ex.ToString());   
			}
        }
    }
}