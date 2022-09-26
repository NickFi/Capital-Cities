/*
 * Created by SharpDevelop.
 * User: SY_Serv
 * Date: 04-Jul-22
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Capitals
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string gsVer = "1.00.04";
		string gsLastBuild = "28-Jul-2022";
		
		string[] cont = { "Africa", "Asia", "Europe", "North America", "South America", "Oceania", "Antarctica" };
		List<string> continents = new List<string>();
		List<string> countries = new List<string>(); 
		Dictionary<string, string> capitalsByCountryDict = new Dictionary<string, string>();
		Dictionary<string, string> countriesByCapitalDict = new Dictionary<string, string>();
		Dictionary<string, string> selectedCapitalsByCountryDict = new Dictionary<string, string>();
		
		bool gbStart = false;
		int totalErrors = 0;
		int crtCountryNum = 0;
		
		private static readonly Random rnd = new Random();
		
		public MainForm()
		{
			InitializeComponent();
			foreach(string c in cont) {
				continents.Add(c);
			}
			
			FillAllCountriesDict();
			FillAllCapitalsDict();
			this.Text = "Capitals v" + gsVer + ", " + gsLastBuild;
		}
		
		/// <summary>
		/// Fills countriesByCapitalDict
		/// </summary>
		void FillAllCountriesDict()
		{
			countriesByCapitalDict.Clear();
			
			string[] lines = File.ReadAllLines("..//..//countries.txt");
			foreach(string line in lines) {
				string[] values = line.Split(',');
				string continent = values[0].Trim();
				string country = values[1].Trim();
				string capital = values[2].Trim();
				try {
					countriesByCapitalDict.Add(capital, country);
				}
				catch(Exception) {
					
				}
			}
		}
		
		/// <summary>
		/// Fills capitalsByCountryDict
		/// </summary>
		void FillAllCapitalsDict()
		{
			capitalsByCountryDict.Clear();
			
			string[] lines = File.ReadAllLines("..//..//countries.txt");
			foreach(string line in lines) {
				string[] values = line.Split(',');
				string continent = values[0].Trim();
				string country = values[1].Trim();
				string capital = values[2].Trim();
				try {
					capitalsByCountryDict.Add(country, capital);
				}
				catch(Exception) {
					
				}
			}
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			string sContinent = cbContinent.Text;
			if(sContinent != "All Continents" && !continents.Contains(sContinent) && sContinent != "Difficult Countries") {
				MessageBox.Show("Please select a continent");
				return;
			}
			
			totalErrors = 0;
			crtCountryNum = 0;
			tbCapitalCity.Clear();
//			countries = LoadCountries(sContinent);
			ChangeContinent();
			gbStart = true;
			RunPuzzle(sContinent);
		}
		
		void RunPuzzle(string sContinent)
		{
			crtCountryNum++;
			int cnt = countries.Count;
			if(cnt > 0) {
				int rand = rnd.Next(0, cnt - 1);
				string country = countries[rand];
				lCountryName.Text = crtCountryNum.ToString() + ". " + country;
				tbCapitalCity.Focus();
				Update();
//				bool result = CheckAnswer();
			}
			else {
				lCountryName.Text = string.Empty;
				toolStripStatusLabel1.Text = "Completed task. Total errors: " + totalErrors;
			}
		}
		
		List<string> LoadCountries(string sContinent)
		{

			string[] lines = File.ReadAllLines("..//..//countries.txt");
			if(sContinent != "Difficult Countries") {			
				foreach(string line in lines) {
					string[] values = line.Split(',');
					string continent = values[0].Trim();
					string country = values[1].Trim();
					string capital = values[2].Trim();
					if(continent == sContinent) {
						countries.Add(country);
						selectedCapitalsByCountryDict.Add(country, capital);
					}
					else if(sContinent == "All Continents") {
						countries.Add(country);
						selectedCapitalsByCountryDict.Add(country, capital);
					}
				}
			}
			else {
				lines = File.ReadAllLines("difficult_countries.txt");
				foreach(string line in lines) {
					string country = line.Trim();
					if(string.IsNullOrEmpty(country)) {
						continue;
					}
					
					string capital = CapitalByCountry(country);
					countries.Add(country);
					selectedCapitalsByCountryDict.Add(country, capital);
				}
			}
				
			return countries;
		}
		
		void BtnCheckClick(object sender, EventArgs e)
		{
			if(!gbStart) {
				MessageBox.Show("Press start before!");
			}
			
			CheckAnswer();
		}
		
		void TbCapitalCityKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return) {
				CheckAnswer();
			}
		}
		
		bool CheckAnswer()
		{
			string continent = cbContinent.Text.Trim();
			string country = lCountryName.Text.Trim();
			string answer = tbCapitalCity.Text.Trim();
			
			country = country.Substring(country.IndexOf(".") + 1).Trim();
			
			if(string.IsNullOrEmpty(country)) {
				return false;
			}

			string capital = capitalsByCountryDict[country];
			countries.Remove(country);
			tbCapitalCity.Clear();
			
			if(SameAnswer(answer, capital)) {
				lbCorrectAnswers.Items.Add(country + ", " + capital);
				lbCorrectAnswers.TopIndex = lbCorrectAnswers.Items.Count - 1;
				Update();
				lResult.ForeColor = Color.Green;
				lResult.Text = "Answer is CORRECT, " + capital + " is the capital city of " + country;
				RunPuzzle(continent);
				return true;
			}
			
			totalErrors++;
			lbCorrectAnswers.Items.Add(country + ", " + capital);
			lbCorrectAnswers.TopIndex = lbCorrectAnswers.Items.Count - 1;
			Update();
			
			lResult.ForeColor = Color.Red;
			lResult.Text = "Answer is INCORRECT, in fact " + capital + " is the capital city of " + country;
			AddToDifficultCountries(country);
			if(string.IsNullOrEmpty(answer)) {
				answer = "~";
			}
			
			if(answer != "~") {
				lbIncorrectAnswers.Items.Add(country + ", " + capital + " (" + answer + " is capital of : " + CountryByCapital(answer) + ")");
			}
			else {
				lbIncorrectAnswers.Items.Add(country + ", " + capital);
			}
			
			lbIncorrectAnswers.TopIndex = lbIncorrectAnswers.Items.Count - 1;
			Update();
			
			lCountryName.Text = string.Empty;
			RunPuzzle(continent);
			
			return false;
		}
		
		/// <summary>
		/// If we don' know the capital to a country, we add that country to list 
		/// </summary>
		/// <param name="country"></param>
		void AddToDifficultCountries(string country)
		{
			country = country.Trim();
			if(string.IsNullOrEmpty(country)) {
				return;
			}
			
			SortedSet<string> countries = new SortedSet<string>();
			string file = "difficult_countries.txt";
			if(File.Exists(file)) {
				string[] lines = File.ReadAllLines(file);
				foreach(string line in lines) {
					countries.Add(line.Trim());
				}
			}
			
			countries.Add(country);
			
			File.WriteAllLines(file, countries);
		}
		
		string CountryByCapital(string capital)
		{
			string country = "~";
			try {
				country = countriesByCapitalDict[capital];
			}
			catch(Exception)
			{
				country = CountryByPartialCapital(capital);
			}
			
			return country;
		}
		
		string CountryByPartialCapital(string sCapital)
		{
			string[] lines = File.ReadAllLines("..//..//countries.txt");
			foreach(string line in lines) {
				string[] values = line.Split(',');
				string continent = values[0].Trim();
				string country = values[1].Trim();
				string capital = values[2].Trim();
				
				if(capital.IndexOf(sCapital, StringComparison.CurrentCultureIgnoreCase) >= 0) {
					return country;
				}
			}
			
//			return "~";
			return string.Empty;
		}
		
		string CapitalByCountry(string country)
		{
			string capital = "~";
			try {
				capital = capitalsByCountryDict[country];
			}
			catch(Exception)
			{
				
			}
			
			return capital;
		}
		
		
		bool SameAnswer(string answer, string capital)
		{
			answer = answer.Trim();
			capital = capital.Trim();
			
			if(string.Equals(answer, capital, StringComparison.CurrentCultureIgnoreCase)) {
				return true;
			}
			
			if(capital.IndexOf(answer, StringComparison.CurrentCultureIgnoreCase) >= 0 && answer.Length > 3) {
				return true;
			}
			
			return false;
		}
		
		void FillContinentsToolStripMenuItemClick(object sender, EventArgs e)
		{
			string sCountryFile = "..//..//countries.txt";
			string[] lines = File.ReadAllLines(sCountryFile);
			
			List<string> results = new List<string>();
			foreach(string line in lines) {
				string[] values = line.Split(',');
				string country = values[0].Trim();
				string capital = values[1].Trim();
				string newLine = FindContinent(country) + "," + country + "," + capital;
				results.Add(newLine);
			}
			
			File.WriteAllLines("results.txt", results);
		}
		
		string FindContinent(string country)
		{
			string sAsiaFile = "..//..//Asia.txt";
			string[] asiaLines = File.ReadAllLines(sAsiaFile);
			foreach(string line in asiaLines) {
				if(country == line.Trim()) {
					return "Asia";
				}
			}

			string sAfricaFile = "..//..//Africa.txt";
			string[] africaLines = File.ReadAllLines(sAfricaFile);
			foreach(string line in africaLines) {
				if(country == line.Trim()) {
					return "Africa";
				}
			}
			
			string sEuropeFile = "..//..//Europe.txt";
			string[] europeLines = File.ReadAllLines(sEuropeFile);
			foreach(string line in europeLines) {
				if(country == line.Trim()) {
					return "Europe";
				}
			}

			string sNorthAmericaFile = "..//..//NorthAmerica.txt";
			string[] northAmericaLines = File.ReadAllLines(sNorthAmericaFile);
			foreach(string line in northAmericaLines) {
				if(country == line.Trim()) {
					return "North America";
				}
			}

			string sSouthAmericaFile = "..//..//SouthAmerica.txt";
			string[] southAmericaLines = File.ReadAllLines(sSouthAmericaFile);
			foreach(string line in southAmericaLines) {
				if(country == line.Trim()) {
					return "South America";
				}
			}
			
			string sOceaniaFile = "..//..//Oceania.txt";
			string[] oceaniaLines = File.ReadAllLines(sOceaniaFile);
			foreach(string line in oceaniaLines) {
				if(country == line.Trim()) {
					return "Oceania";
				}
			}
			
			return string.Empty;
		}
		
		void CbContinentSelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = cbContinent.SelectedIndex;
			if(selectedIndex >= 0) {
				ChangeContinent();
			}
		}
		
		void ChangeContinent()
		{
			int selectedIndex = cbContinent.SelectedIndex;			
			toolStripStatusLabel1.Text = string.Empty;
			countries.Clear();
//			capitalsByCountryDict.Clear(); // we will load only the relevant countries in here
			selectedCapitalsByCountryDict.Clear();
			
			lResult.Text = string.Empty;
			lCountryName.Text = string.Empty;
			lbCorrectAnswers.Items.Clear();
			lbIncorrectAnswers.Items.Clear();
			Update();
			string continent = cbContinent.Items[selectedIndex].ToString();
			var contCountries = LoadCountries(continent);
			int cnt = contCountries.Count;
			lTotalCountries.Text = cnt.ToString() + " countries";
		}

		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Version " + gsVer + ", Last Build: " + gsLastBuild);
		}
		
		void ModifyApplicationToolStripMenuItemClick(object sender, EventArgs e)
		{
			string sProgram = Application.ExecutablePath;
			string sProgramName = Path.GetFileNameWithoutExtension(sProgram);
			string sAppPath = Path.GetDirectoryName(sProgram);
			
			sAppPath = sAppPath.Replace("\\bin\\Debug", "");
			sAppPath = sAppPath.Replace("\\bin\\Release", "");
			sAppPath = Directory.GetParent(sAppPath).ToString();
			
			string sSolutionName = sProgramName + ".sln";
			string sSolution = Path.Combine(sAppPath, sSolutionName);
			
			if (File.Exists(sSolution)) {
				Process.Start(sSolution);      
				Application.Exit();			
			} else {
				MessageBox.Show("File " + sProgram + " not found");
			} 
		}
		
		void BtnHintClick(object sender, EventArgs e)
		{
			string country = lCountryName.Text.Trim();
			string answer = tbCapitalCity.Text.Trim();
			
			string capital = capitalsByCountryDict[country];
			tbCapitalCity.Text = capital[0].ToString();
			tbCapitalCity.Focus();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
		
		void OpenDifficultContriesFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			string file = "difficult_countries.txt";
			if(!File.Exists(file)) {
				MessageBox.Show("File " + file + " not found!");
				return;
			}
			
			Process.Start(file);
		}
		
		void OpenAllCountriesToolStripMenuItemClick(object sender, EventArgs e)
		{
			string sCountryFile = "..//..//countries.txt";
			string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), sCountryFile);
			file = Path.GetFullPath(file);
			
			if(File.Exists(file)) {
				Process.Start(file);
			}
			else {
				MessageBox.Show("File " + sCountryFile + " not found!");
			}
		}
	}
}
