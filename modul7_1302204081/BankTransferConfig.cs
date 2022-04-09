using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace modul7_1302204081
{
	public class Bank
	{
		public string lang { get; set; }
		public Transfer transfer { get; set; }
		public string[] methods { get; set; }
		public Confirmation confirmation { get; set; }

	}
	public class Transfer
	{
		public int threshold { get; set; }
		public int low_fee { get; set; }
		public int high_fee { get; set; }

	}
	public class Confirmation
	{
		public string en { get; set; }
		public string id { get; set; }
	}
	public class BankTransferConfig
	{
		private const string CONFIG1 = "en";
		private const int CONFIG2 = 25000000;
		private const int CONFIG3 = 6500;
		private const int CONFIG4 = 15000;
		private string[] CONFIG5 = new string[4] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
		private const string CONFIG6 = "YES";
		private const string CONFIG7 = "ya";
		public static int uang;
		public static bool en;

		public void config(){
			Bank config = new Bank();
			//transfer
			Transfer transfer = new Transfer();
			transfer.threshold = CONFIG2;
			transfer.low_fee = CONFIG3;
			transfer.high_fee = CONFIG4;
			//confirmation
			Confirmation confirmation = new Confirmation();
			confirmation.en = CONFIG6;
			confirmation.id = CONFIG7;
			//setting config default
			config.lang = CONFIG1;
			config.methods = CONFIG5;
			config.confirmation = confirmation;


			try
			{
				StreamReader reader = new StreamReader("bank_transfer_config.json");
				string jsonString = reader.ReadToEnd();
				JObject parsed = JObject.Parse(jsonString);
				var lang = parsed["lang"];
				if((string)lang == "CONFIG1")
				{
					config.lang = CONFIG1;
					Console.WriteLine(config.lang);
					if (config.lang == CONFIG1)
					{
						Console.WriteLine("Please insert the amount of money to transfer :");
						uang = Convert.ToInt32(Console.ReadLine());
						en = true;
						
					}else if(config.lang == "id")
					{
						Console.WriteLine("Masukan jumlah uang yang akan di transfer :");
						en = false;
					}
				}
				var t = parsed["transfer"];
				var threshold = t["threshold"];
				if((string)threshold == "CONFIG2")
				{
					transfer.threshold = CONFIG2;
					if(uang <= CONFIG2)
					{
						uang+=CONFIG3;
					}
					else
					{
						uang += CONFIG4;
					}
					if (en == true)
					{
						Console.WriteLine("Transfer fee : "+uang);
					}
					else
					{
						Console.WriteLine("Biaya Transfer : "+uang);
					}
				}
				
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
		}



		//Atribute untuk diserialisasi
		//public string lang { get; set; }
		//public string transfer { get; set; }
		//public string methods { get; set; }
		//public string confirmation { get; set; }

		//public BankTransferConfig() { }

		//public BankTransferConfig(string lang, string transfer, string methods,string confirmation)
		//{
		//	this.lang = lang;
		//	this.transfer = transfer;
		//	this.methods = methods;
		//	this.confirmation = confirmation;
		//}
	}
}
