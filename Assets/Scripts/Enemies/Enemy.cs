using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;
    }
}
