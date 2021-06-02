using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildVersionView : MonoBehaviour
{
	[SerializeField]
	private Text _buildVersion;
    // Start is called before the first frame update
    void Start()
    {
	    _buildVersion.text += Application.version;
    }
}
