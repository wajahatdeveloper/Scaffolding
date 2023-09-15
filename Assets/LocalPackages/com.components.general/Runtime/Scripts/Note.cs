using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityEngineX
{
	[HideMonoScript]
	public class Note : MonoBehaviour
	{
		[TextArea(5,100)]
	    [HideLabel]
		public string text = "Type your note here";
	}
}