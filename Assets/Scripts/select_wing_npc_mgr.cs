using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class select_wing_npc_mgr : MonoBehaviour {

	// 처음 시작시 NPC01 아이콘 GameObject를 받아오기 위한 List 변수 선언.
	GameObject[] npc_object = new GameObject[12];

	// Use this for initialization
	void Awake()
	{
		for (int i = 0; i < 12; i++)
		{
			GameObject temp_gameobject = GameObject.Find("select_wing_NPC" + (i + 1).ToString() + "_icon");
			npc_object[i] = temp_gameobject;
		}
	}
	void OnEnable()
	{
		int count_npc = 0;

		// NPC01 캐릭터가 Enabl	e인지 아닌지 Check
		if (NPC01_make.NPC01_struct.enable)
		{
			npc_object[0].SetActive(true);

			// Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
			count_npc++;
		}
		else
		{
			npc_object[0].SetActive(false);
		}

		// NPC02 캐릭터가 Enable인지 아닌지 Check
		if (NPC02_make.NPC02_struct.enable)
		{
			npc_object[1].SetActive(true);

			// Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
			count_npc++;
		}
		else
		{
			npc_object[1].SetActive(false);
		}

		// NPC03 캐릭터가 Enable인지 아닌지 Check
		if (NPC03_make.NPC03_struct.enable)
		{
			npc_object[2].SetActive(true);

			// Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
			count_npc++;
		}
		else
		{
			npc_object[2].SetActive(false);
		}

        // NPC04 캐릭터가 Enable인지 아닌지 Check
        if (NPC04_make.NPC04_struct.enable)
        {
            npc_object[3].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[3].SetActive(false);
        }

        // NPC05 캐릭터가 Enable인지 아닌지 Check
        if (NPC05_make.NPC05_struct.enable)
        {
            npc_object[4].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[4].SetActive(false);
        }
        // NPC06 캐릭터가 Enable인지 아닌지 Check
        if (NPC06_make.NPC06_struct.enable)
        {
            npc_object[5].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[5].SetActive(false);
        }

        // NPC07 캐릭터가 Enable인지 아닌지 Check
        if (NPC07_make.NPC07_struct.enable)
        {
            npc_object[6].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[6].SetActive(false);
        }

        // NPC08 캐릭터가 Enable인지 아닌지 Check
        if (NPC08_make.NPC08_struct.enable)
        {
            npc_object[7].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[7].SetActive(false);
        }

        // NPC09 캐릭터가 Enable인지 아닌지 Check
        if (NPC09_make.NPC09_struct.enable)
        {
            npc_object[8].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[8].SetActive(false);
        }

        // NPC10 캐릭터가 Enable인지 아닌지 Check
        if (NPC10_make.NPC10_struct.enable)
        {
            npc_object[9].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[9].SetActive(false);
        }

        // NPC11 캐릭터가 Enable인지 아닌지 Check
        if (NPC11_make.NPC11_struct.enable)
        {
            npc_object[10].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[10].SetActive(false);
        }

        // NPC12 캐릭터가 Enable인지 아닌지 Check
        if (NPC12_make.NPC12_struct.enable)
        {
            npc_object[11].SetActive(true);

            // Soft Clip 사이즈를 재기 위한 npc icon개수 증가.
            count_npc++;
        }
        else
        {
            npc_object[11].SetActive(false);
        }


        // NPC 아이콘 개수에 따라서 Soft Clip 사이즈를 재 지정하기 위함. NPC 아이콘이 0개면 Soft Clip 사이즈도 제로.
        if (!(count_npc == 0))
		{
            if (count_npc < 7)
            {
                // 마지막에 Pannel 사이즈를 추가된 아이콘 개수에 맞게 지정.
                // Default ( Center : X.-400 Y.0 )
                this.GetComponent<UIPanel>().SetRect((float)(-400 + (80 * (count_npc - 1))), 0, (float)(160 + (160 * (count_npc - 1))), 166f);
            }
            else
            {
                this.GetComponent<UIPanel>().SetRect(0, 0, 950f, 166f);
            }
        }

	}
}
