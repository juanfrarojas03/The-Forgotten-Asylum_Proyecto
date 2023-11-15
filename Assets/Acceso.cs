using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Acceso : MonoBehaviour
{
    private string connectionString;
    private IDbConnection connection;
    public string nombreUsuarioActual;

    public void Abrir()
    {
        connectionString = "URI=file:Assets/Plugin/HighScoreDB.db";
        connection = new SqliteConnection(connectionString);
        connection.Open();
    }

    public void Cerrar()
    {
        connection.Close();
        connection = null;
        GC.Collect();
    }

    private SqliteCommand CrearComando(string sql)
    {
        SqliteCommand cmd = new SqliteCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = (SqliteConnection)connection;

        return cmd;
    }

    public DataTable Leer(string sql)
    {
        SqliteDataAdapter adaptador = new SqliteDataAdapter();
        adaptador.SelectCommand = CrearComando(sql);

        DataTable tabla = new DataTable();
        adaptador.Fill(tabla);

        return tabla;
    }

    public bool VerificarInicioSesion(string nombreUsuario, string contraseña)
    {
        string consulta = "SELECT COUNT(*) FROM Jugador WHERE User = @Nombre AND Password = @Password";

        using (SqliteCommand cmd = CrearComando(consulta))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombreUsuario);
            cmd.Parameters.AddWithValue("@Password", contraseña);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                nombreUsuarioActual = nombreUsuario;
                Debug.Log("Inicio de sesión exitoso para el usuario: " + nombreUsuarioActual);
                return true;
            }
            else
            {
                Debug.Log("Inicio de sesión fallido para el usuario: " + nombreUsuario);
                return false;
            }
        }
    }

    public bool AgregarUsuario(string nombreUsuario, string contraseña)
    {
        string consulta = "INSERT INTO Jugador (User, Password) VALUES (@Nombre, @Password)";

        using (SqliteCommand cmd = CrearComando(consulta))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombreUsuario);
            cmd.Parameters.AddWithValue("@Password", contraseña);

            try
            {
                cmd.ExecuteNonQuery();
                Debug.Log("Usuario agregado correctamente: " + nombreUsuario);
                return true;
            }
            catch (SqliteException ex)
            {
                Debug.LogError("Error al agregar usuario: " + ex.Message);
                return false;
            }
        }
    }
}
