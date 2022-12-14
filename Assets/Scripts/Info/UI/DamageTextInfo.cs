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
        Color defaultColor = new Color(1,1,1);
        Color critColor = new Color(1,0.75f,0);
        Color headshotColor = new Color(0.4f, 0.1f, 0.05f);
        Vector3 defaultSize = Vector3.one;
        Vector3 critSize = new Vector3(2,2,2);
        public void ResetPos(){

            isUpping = false;
            timer = 0;
            transform.position = templatePos.position;
            damageText.color = defaultColor;
            transform.localScale = defaultSize;
        }

        private void Start() {
            Name = "DamageTextInfo";
            damageText = GetComponent<Text>();
            rect = GetComponent<RectTransform>();
            timer = 0;
        }

        public void InitInfo(float dmg, Transform templatePos, Transform spawnPos, bool isCrit, bool isHeadshot){
            if (timer>0)
            {
                ResetPos();
            }
            damageText.text = dmg.ToString("f0");
            this.templatePos = templatePos;
            transform.position = spawnPos.position;
            isUpping = true;
            if (isHeadshot)
            {
                damageText.color = headshotColor;
            }

            if (isCrit)
            {
                damageText.color = critColor;
                transform.localScale = critSize;
            }
            Invoke("ResetPos", 2.1f);
        }

        private void FixedUpdate() {
            if (isUpping)
            {
                timer += Time.deltaTime;
                rect.offsetMax = new Vector2(rect.offsetMax.x, rect.offsetMax.y + timer * 5);
            }
        }

    }
