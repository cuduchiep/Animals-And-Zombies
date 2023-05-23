using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using Mono.Data.Sqlite;

public static class SQLiteCore {

    //public static string connectionString = "URI=file:" + Application.dataPath + "/Database/mydatabase.sqlite";
    //public static IDbConnection con = new SqliteConnection(connectionString);

    //Android
    public static SqliteConnection con;
    public static SqliteCommand cmd_db;
    public static SqliteDataReader rdr;
    public static string path;

    public static void Connect()
    {

        /*if(con.State != ConnectionState.Open)
        {
            con.Open();
        }*/

        try
        {
            if(Application.platform != RuntimePlatform.Android)
            {
                path = Application.dataPath + "/StreamingAssets/mydatabase.sqlite";
            } else
            {
                path = Application.persistentDataPath + "/mydatabase.sqlite";
                if(!File.Exists(path))
                {
                    WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "mydatabase.sqlite");
                    while(!load.isDone) { }
                    File.WriteAllBytes(path, load.bytes);
                }
            }
            con = new SqliteConnection("URI=file:" + path);
            con.Open();
        }catch(Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public static List<Database> GetDatabases()
    {
        string query = "SELECT * FROM Player";
        Connect();
        List<Database> listUser = new List<Database>();

        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    IDataReader datas = cmd.ExecuteReader();
                    while (datas.Read())
                    {
                        Database database = new Database();
                        database.ID = Convert.ToInt32(datas[0]);
                        database.LEVEL = Convert.ToInt32(datas[1]);
                        database.CARD = Convert.ToInt32(datas[2]);
                        database.CURRENTLEVEL = Convert.ToInt32(datas[3]);
                        listUser.Add(database);
                    }
                    return listUser;
                }
            }
        }
        catch (Exception ex)
        {
            return new List<Database>();
        }
    }

    public static List<Database2> GetDatabases2()
    {
        string query = "SELECT * FROM Cards";
        Connect();
        List<Database2> listUser = new List<Database2>();
        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    IDataReader datas = cmd.ExecuteReader();
                    while (datas.Read())
                    {
                        Database2 database = new Database2();
                        database.ID = Convert.ToInt32(datas[0]);
                        database.NAME = Convert.ToString(datas[1]);
                        database.GOLD = Convert.ToInt32(datas[2]);
                        database.NUMBER = Convert.ToInt32(datas[3]);

                        listUser.Add(database);
                    }
                    return listUser;
                }
            }
        }
        catch (Exception ex)
        {
            return new List<Database2>();
        }
    }

    public static bool CreatePlayer(int id, int level, int card, int currentLevel) 
    {
        //const string Format = "INSERT INTO Player (id, level, card) VALUES(NULL, '{level}', '{card}')";
        //string query = string.Format(Format, level.ToString(), card.ToString());
        string query = "INSERT INTO Player (id, level, card, currentLevel) VALUES (" + id + ", " + level + ", " + card + ", " + currentLevel + ")";
        Connect();

        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Debug.Log("OK");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("ERROR: " + ex.ToString());
            return false;
        }
    }


    public static bool UpLevel(int level, int card)
    {
        //const string Format = "INSERT INTO Player (id, level, card) VALUES(NULL, '{level}', '{card}')";
        //string query = string.Format(Format, level.ToString(), card.ToString());
        string query = "UPDATE Player SET level = " + level + ", card = " + card + " WHERE id = 1";
        Connect();

        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Debug.Log("OK");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("ERROR: " + ex.ToString());
            return false;
        }
    }


    public static bool ChooseLevel(int currentLevel)
    {
        //const string Format = "INSERT INTO Player (id, level, card) VALUES(NULL, '{level}', '{card}')";
        //string query = string.Format(Format, level.ToString(), card.ToString());
        string query = "UPDATE Player SET currentLevel = " + currentLevel + " WHERE id = 1";
        Connect();

        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Debug.Log("OK");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("ERROR: " + ex.ToString());
            return false;
        }
    }


    public static bool ChooseCard(int id, string name, int gold, int number)
    {
        //const string Format = "INSERT INTO Player (id, level, card) VALUES(NULL, '{level}', '{card}')";
        //string query = string.Format(Format, level.ToString(), card.ToString());
        string query = "UPDATE Cards SET name = '" + name + "', gold = " + gold + ", number = " + number + " WHERE id = " + id;
        Connect();

        try
        {
            using (con)
            {
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Debug.Log("OK");
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("ERROR: " + ex.ToString());
            return false;
        }
    }
}
