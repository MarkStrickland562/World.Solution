using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class Country
  {
    private string _code;
    private string _name;
    private string _continent;
    private string _region;
    private float _surface;
    private int _population;

    public Country(string CountryCode, string CountryName, string CountryContinent, string CountryRegion, float CountrySurface, int CountryPopulation)
    {
      _code = CountryCode;
      _name = CountryName;
      _continent = CountryContinent;
      _region = CountryRegion;
      _surface = CountrySurface;
      _population = CountryPopulation;
    }

    public string GetCode()
    {
      return _code;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetContinent()
    {
      return _continent;
    }

    public string GetRegion()
    {
      return _region;
    }

    public float GetSurface()
    {
      return _surface;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Country;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string CountryCode = rdr.GetString(0);
        string CountryName = rdr.GetString(1);
        string CountryContinent = rdr.GetString(2);
        string CountryRegion = rdr.GetString(3);
        float CountrySurface = rdr.GetFloat(4);
        int CountryPopulation= rdr.GetInt32(5);
        Country newCountry = new Country(CountryCode, CountryName, CountryContinent, CountryRegion, CountrySurface, CountryPopulation);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    // public static Country Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }

  //   public List<Country> GetCountries()
  //   {
  //     return _Countries;
  //   }
  //
  //   public void AddCountry(Country country)
  //   {
  //     _countries.Add(country);
  //   }
  }
}
