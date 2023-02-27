using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Lab5Games.Ediotr
{
    public static class ProjectOrganization
    {
        public static void Organize()
        {
            OrganizeProjectFolders();
        }

        private static void OrganizeProjectFolders()
        {
            string[] folders = new string[]
            {
                "Assets/{0}/Art/Animations",
                "Assets/{0}/Art/Materials",
                "Assets/{0}/Art/Models",
                "Assets/{0}/Art/Textures",
                "Assets/{0}/Art/UI",
                "Assets/{0}/Art/Fonts",

                "Assets/{0}/Audio/Musics",
                "Assets/{0}/Audio/Sounds",

                "Assets/{0}/Code/Scripts",
                "Assets/{0}/Code/Shaders",

                "Assets/{0}/Content/Prefabs",
                "Assets/{0}/Content/Scenes",
                "Assets/{0}/Content/Scriptables",


                "Assets/{0}/Doc",
                "Assets/{0}/Settings",

                "Assets/Third Party"
            };

            string projectName = new string(Application.productName.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());

            string rootName = "_" + projectName;

            foreach(string folder in folders)
            {
                string path = String.Format(folder, rootName);

                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            AssetDatabase.Refresh();
        }
    }
}
