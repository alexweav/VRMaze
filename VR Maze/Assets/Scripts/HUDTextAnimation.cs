using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class HUDTextAnimation{
		
		private bool visible = false; 

		public bool promptVisible{
			get{
				return visible;
			}
			set{
				visible = value;
			}
		}
	}
}