﻿using ComponentFactory.Krypton.Toolkit;
using KAutoHelper;
using KT_Timer_App.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_Timer_App
{
    internal class Module
    {
        public List<KTTask> Tasks {  get; set; }
        public DateTime minStartDateTime { get; set; }
        public int taskIDCurrent { get; set; }
        public List<KeyCodeItem> keyCodeList { get; set; }

        //
        private static Module instance;
        public static Module Instance()
        {
            if(instance == null) instance = new Module();
            return instance;
        }
        private Module()
        {
            Tasks = new List<KTTask>();
            minStartDateTime = DateTime.MaxValue;
            keyCodeList = GetListKeyCode();
        }
        //
        
        public void SetMinStartDateTime()
        {
            //set lại minStartDateTime mới
            minStartDateTime = DateTime.MaxValue;
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].StartTime <= minStartDateTime && !Tasks[i].IsComplete)
                {
                    minStartDateTime = Tasks[i].StartTime;
                }
            }
        }

        /// <summary>
        /// Keycode handle
        /// </summary>
        public class KeyCodeItem
        {
            public string NameKey { get; set; }
            public short Value { get; set; }
            public KeyCode KeyCode { get; set; }
        }

        public List<KeyCodeItem> GetListKeyCode()
        {
            return Enum.GetValues(typeof(KeyCode))
                    .Cast<KeyCode>()
                    .Select(k => new KeyCodeItem { NameKey = k.ToString(), Value = (short)k, KeyCode = k })
                    .ToList();
        }
        public List<KeyCodeItem> GetSelectedKeyCodeValues(params short[] selectedValues)
        {
            List<KeyCodeItem> result = new List<KeyCodeItem>();
            foreach(KeyCodeItem item in keyCodeList)
            {
                if(selectedValues.Contains(item.Value))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        
    }

}