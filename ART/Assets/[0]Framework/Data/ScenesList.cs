/*===============================================================
Product:    Cryoshock
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       2/9/2018  7:22 PM
================================================================*/

using System.Collections.Generic;
using UnityEngine;
namespace Homebrew
{
    [CreateAssetMenu(fileName = "ScenesList", menuName = "Data/ScenesList")]
    [System.Serializable]
    public class ScenesList : ScriptableObject
    {
        public List<string> scenesNames;
    }

}