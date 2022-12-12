using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public sealed class DamageTextInfo : UIInfo{
        Text damageText;
        bool isUpping;
        Transform templatePos;
        RectTransform rect;
        float timer; 
        public void ResetPos(){

            isUpping = false;
            timer = 0;
            transform.position = templatePos.position;
        }

        private void Start() {
            Name = "DamageTextInfo";
            damageText = GetComponent<Text>();
            rect = GetComponent<RectTransform>();
            timer = 0;
        }

        public void InitInfo(float dmg, Transform templatePos, Transform spawnPos){
            if (timer>0)
            {
                ResetPos();
            }
            damageText.text = dmg.ToString("f0");
            this.templatePos = templatePos;
            transform.position = spawnPos.position;
            isUpping = true;
            Invoke("ResetPos", 2.1f);
        }

        private void Update() {
            if (isUpping)
            {
                timer += Time.deltaTime;
                rect.offsetMax = new Vector2(rect.offsetMax.x, rect.offsetMax.y + timer * 5);
            }
        }

    }
