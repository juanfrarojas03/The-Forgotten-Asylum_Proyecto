using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CopyDatabaseOnBuild : MonoBehaviour
{
    [MenuItem("Build/Build Game With Database")]
    public static void BuildGameWithDatabase()
    {
        // Ruta de la base de datos en Assets
        string databasePathInAssets = "Assets/Plugin/HighScoreDB.db";

        // Ruta de destino en la carpeta persistente de la plataforma despu�s de la construcci�n
        string destinationPath = Path.Combine(Application.persistentDataPath, "HighScoreDB.db");

        // Copiar la base de datos a la carpeta persistente de la plataforma durante la construcci�n
        FileUtil.CopyFileOrDirectory(databasePathInAssets, destinationPath);

        // Construir el juego
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "RutaDeSalidaDelBuild", BuildTarget.StandaloneWindows, BuildOptions.None);
    }
}
