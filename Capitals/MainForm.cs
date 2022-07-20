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
		string gsVer = "1.00.02";
		string gsLastBuild = "20-Jul-2022";
		
		string[] cont = { "Africa", "Asia", "Europe", "North America", "South America", "Oceania", "Antarctica" };
		List<string> continents = new List<string>();
		List<string> countries = new List<string>(); 
		Dictionary<string, string> dict = new Dictionary<string, string>();
		
		private static readonly Random rnd = new Random();
		
		public MainForm()
		{
			InitializeComponent();
			foreach(string c in cont) {
				continents.Add(c);
			}
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			string sContinent = cbContinent.Text;
			if(sContinent != "All Continents" && !continents.Contains(sContinent)) {
				MessageBox.Show("Please select a continent");
				return;
			}
			
//			countries = LoadCountries(sContinent);
			ChangeContinent();
			RunPuzzle(sContinent);
		}
		
		void RunPuzzle(string sContinent)
		{
			int cnt = countries.Count;
			if(cnt > 0) {
				int rand = rnd.Next(0, cnt - 1);
				string country = countries[rand];
				lCountryName.Text = country;
				tbCapitalCity.Focus();
				Update();
//				bool result = CheckAnswer();
			}
			else {
				lCountryName.Text = string.Empty;
				toolStripStatusLabel1.Text = "Completed task";
			}
		}
		
		List<string> LoadCountries(string sContinent)
		{
			string[] lines = File.ReadAllLines("..//..//countries.txt");
			foreach(string line in lines) {
				string[] values = line.Split(',');
				string continent = values[0].Trim();
				string country = values[1].Trim();
				string capital = values[2].Trim();
				if(continent == sContinent) {
					countries.Add(country);
					dict.Add(country, capital);
				}
				else if(sContinent == "All Continents") {
					countries.Add(country);
					dict.Add(country, capital);
				}
			}
				
			return countries;
		}
		
		void BtnCheckClick(object sender, EventArgs e)
		{
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
			
			if(string.IsNullOrEmpty(country)) {
				return false;
			}

			string capital = dict[country];
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
			
			lbCorrectAnswers.Items.Add(country + ", " + capital);
			lbCorrectAnswers.TopIndex = lbCorrectAnswers.Items.Count - 1;
			Update();
			
			lResult.ForeColor = Color.Red;
			lResult.Text = "Answer is INCORRECT, in fact " + capital + " is the capital city of " + country;
			lbIncorrectAnswers.Items.Add(country + ", " + answer);
			lbIncorrectAnswers.TopIndex = lbIncorrectAnswers.Items.Count - 1;
			Update();
			
			lCountryName.Text = string.Empty;
			RunPuzzle(continent);
			
			return false;
		}
		
		bool SameAnswer(string answer, string capital)
		{
			answer = answer.Trim();
			capital = capital.Trim();
			
			if(string.Equals(answer, capital, StringComparison.CurrentCultureIgnoreCase)) {
				return true;
			}
			
			if(capital.IndexOf(answer) >= 0 && answer.Length > 3) {
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
			dict.Clear();
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
	}
}
