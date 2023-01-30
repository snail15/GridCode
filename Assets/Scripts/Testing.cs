using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using Unity.Notifications.iOS;
using UnityEngine;

public class Testing : MonoBehaviour {
   private Grid _grid;
   private void Start()
   {
      _grid = new Grid(4, 2, 10f, new Vector3(30, 0));
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         _grid.SetValue(UtilsClass.GetMouseWorldPosition(), 22);
      }

      if (Input.GetMouseButtonDown(1))
      {
         Debug.Log(_grid.GetValue(UtilsClass.GetMouseWorldPosition()));
      }
   }
}
