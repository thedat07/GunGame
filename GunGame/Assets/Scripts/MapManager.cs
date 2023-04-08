using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject map;
    public Transform player;
    public List<ArenaBlock> m_LstArenaBlocks;

    [SerializeField] private float m_ArenaWidth = 100;
    [SerializeField] private float m_ArenaHeight = 100;
    private int m_PlayerArenaBlockPos;

    public int playerArenaBlockPos
    {
        get { return m_PlayerArenaBlockPos; }
        set
        {
            if (m_PlayerArenaBlockPos != value)
            {
                m_PlayerArenaBlockPos = value;
                UpdateArenaModel();
            }
        }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        m_LstArenaBlocks = new List<ArenaBlock>(new ArenaBlock[9]);
        for (int i = 0; i < 9; i++)
        {
            var mapClone = Instantiate(map, transform.position, map.transform.rotation,transform);
            ArenaBlock ab = new ArenaBlock()
            {
                Pos = i,
                TheObject = mapClone
            };
             m_LstArenaBlocks[i] = ab;
            PlaceArenaBlock(ab, i);
        }
        playerArenaBlockPos = m_LstArenaBlocks[4].Pos;
    }

    private void Update()
    {
        playerArenaBlockPos = GetArenaPosClosesToPlayer();
    }

    private void PlaceArenaBlock(ArenaBlock ab, int pos, int steps = 1)
    {
        Vector3 dir = GetDirectionFromPos(pos) * steps;
        Vector3 curPos = ab.TheObject.transform.position;

        Vector3 newPos = curPos + new Vector3(
            (m_ArenaWidth * 2) * dir.x,
            0f,
            (m_ArenaHeight * 2) * dir.z
        );
newPos.y = -1f;
        ab.TheObject.transform.localPosition = newPos;
    }

    private int GetArenaPosClosesToPlayer()
    {
        float dist = Mathf.Infinity;
        int champ = -1;
        for (int i = 0; i < 9; i++)
        {
            ArenaBlock tmpBlock = m_LstArenaBlocks[i];
            float tmpDist = Vector3.Distance(
                tmpBlock.TheObject.transform.position,
               player.transform.position
            );
            if (tmpDist < dist)
            {
                dist = tmpDist;
                champ = tmpBlock.Pos;
            }
        }
        return champ;
    }
    private void UpdateArenaModel()
    {
        switch (playerArenaBlockPos)
        {
            case 0:
                PlaceArenaBlock(m_LstArenaBlocks[2], 0, 1);
                PlaceArenaBlock(m_LstArenaBlocks[6], 0, 1);
                PlaceArenaBlock(m_LstArenaBlocks[5], 0, 2);
                PlaceArenaBlock(m_LstArenaBlocks[7], 0, 2);
                PlaceArenaBlock(m_LstArenaBlocks[8], 0, 3);

                m_LstArenaBlocks[8].Pos = 0;
                m_LstArenaBlocks[5].Pos = 1;
                m_LstArenaBlocks[7].Pos = 3;
                m_LstArenaBlocks[0].Pos = 4;
                m_LstArenaBlocks[1].Pos = 5;
                m_LstArenaBlocks[7].Pos = 7;
                m_LstArenaBlocks[4].Pos = 8;
                break;
            case 1:
                PlaceArenaBlock(m_LstArenaBlocks[6], 1, 3);
                PlaceArenaBlock(m_LstArenaBlocks[7], 1, 3);
                PlaceArenaBlock(m_LstArenaBlocks[8], 1, 3);

                m_LstArenaBlocks[6].Pos = 0;
                m_LstArenaBlocks[7].Pos = 1;
                m_LstArenaBlocks[8].Pos = 2;
                m_LstArenaBlocks[0].Pos = 3;
                m_LstArenaBlocks[1].Pos = 4;
                m_LstArenaBlocks[2].Pos = 5;
                m_LstArenaBlocks[3].Pos = 6;
                m_LstArenaBlocks[4].Pos = 7;
                m_LstArenaBlocks[5].Pos = 8;
                break;
            case 2:
                PlaceArenaBlock(m_LstArenaBlocks[0], 2, 1);
                PlaceArenaBlock(m_LstArenaBlocks[8], 2, 1);
                PlaceArenaBlock(m_LstArenaBlocks[3], 2, 2);
                PlaceArenaBlock(m_LstArenaBlocks[7], 2, 2);
                PlaceArenaBlock(m_LstArenaBlocks[6], 2, 3);

                m_LstArenaBlocks[3].Pos = 0;
                m_LstArenaBlocks[6].Pos = 1;
                m_LstArenaBlocks[1].Pos = 3;
                m_LstArenaBlocks[2].Pos = 4;
                m_LstArenaBlocks[7].Pos = 5;
                m_LstArenaBlocks[4].Pos = 7;
                m_LstArenaBlocks[5].Pos = 8;
                break;
            case 3:
                PlaceArenaBlock(m_LstArenaBlocks[2], 3, 3);
                PlaceArenaBlock(m_LstArenaBlocks[5], 3, 3);
                PlaceArenaBlock(m_LstArenaBlocks[8], 3, 3);

                m_LstArenaBlocks[2].Pos = 0;
                m_LstArenaBlocks[0].Pos = 1;
                m_LstArenaBlocks[1].Pos = 2;
                m_LstArenaBlocks[5].Pos = 3;
                m_LstArenaBlocks[3].Pos = 4;
                m_LstArenaBlocks[4].Pos = 5;
                m_LstArenaBlocks[8].Pos = 6;
                m_LstArenaBlocks[6].Pos = 7;
                m_LstArenaBlocks[7].Pos = 8;
                break;
            case 4:
                break;
            case 5:
                PlaceArenaBlock(m_LstArenaBlocks[0], 5, 3);
                PlaceArenaBlock(m_LstArenaBlocks[3], 5, 3);
                PlaceArenaBlock(m_LstArenaBlocks[6], 5, 3);

                m_LstArenaBlocks[1].Pos = 0;
                m_LstArenaBlocks[2].Pos = 1;
                m_LstArenaBlocks[0].Pos = 2;
                m_LstArenaBlocks[4].Pos = 3;
                m_LstArenaBlocks[5].Pos = 4;
                m_LstArenaBlocks[3].Pos = 5;
                m_LstArenaBlocks[7].Pos = 6;
                m_LstArenaBlocks[8].Pos = 7;
                m_LstArenaBlocks[6].Pos = 8;
                break;
            case 6:
                PlaceArenaBlock(m_LstArenaBlocks[0], 6, 1);
                PlaceArenaBlock(m_LstArenaBlocks[8], 6, 1);
                PlaceArenaBlock(m_LstArenaBlocks[1], 6, 2);
                PlaceArenaBlock(m_LstArenaBlocks[5], 6, 2);
                PlaceArenaBlock(m_LstArenaBlocks[2], 6, 3);

                m_LstArenaBlocks[3].Pos = 1;
                m_LstArenaBlocks[4].Pos = 2;
                m_LstArenaBlocks[1].Pos = 3;
                m_LstArenaBlocks[6].Pos = 4;
                m_LstArenaBlocks[7].Pos = 5;
                m_LstArenaBlocks[2].Pos = 6;
                m_LstArenaBlocks[5].Pos = 7;
                break;
            case 7:
                PlaceArenaBlock(m_LstArenaBlocks[0], 7, 3);
                PlaceArenaBlock(m_LstArenaBlocks[1], 7, 3);
                PlaceArenaBlock(m_LstArenaBlocks[2], 7, 3);

                m_LstArenaBlocks[3].Pos = 0;
                m_LstArenaBlocks[4].Pos = 1;
                m_LstArenaBlocks[5].Pos = 2;
                m_LstArenaBlocks[6].Pos = 3;
                m_LstArenaBlocks[7].Pos = 4;
                m_LstArenaBlocks[8].Pos = 5;
                m_LstArenaBlocks[0].Pos = 6;
                m_LstArenaBlocks[1].Pos = 7;
                m_LstArenaBlocks[2].Pos = 8;
                break;
            case 8:
                PlaceArenaBlock(m_LstArenaBlocks[2], 8, 1);
                PlaceArenaBlock(m_LstArenaBlocks[6], 8, 1);
                PlaceArenaBlock(m_LstArenaBlocks[1], 8, 2);
                PlaceArenaBlock(m_LstArenaBlocks[3], 8, 2);
                PlaceArenaBlock(m_LstArenaBlocks[0], 8, 3);

                m_LstArenaBlocks[4].Pos = 0;
                m_LstArenaBlocks[5].Pos = 1;
                m_LstArenaBlocks[7].Pos = 3;
                m_LstArenaBlocks[8].Pos = 4;
                m_LstArenaBlocks[1].Pos = 5;
                m_LstArenaBlocks[3].Pos = 7;
                m_LstArenaBlocks[0].Pos = 8;
                break;
            default:
                break;
        }
        m_LstArenaBlocks.Sort((x, y) => x.Pos.CompareTo(y.Pos));
    }
    private Vector3 GetDirectionFromPos(int pos)
    {
        switch (pos)
        {
            case 0:
                return new Vector3(-1, 0, 1);
            case 1:
                return new Vector3(0, 0, 1);
            case 2:
                return new Vector3(1, 0, 1);
            case 3:
                return new Vector3(-1, 0, 0);
            case 4:
                return new Vector3(0, 0, 0);
            case 5:
                return new Vector3(1, 0, 0);
            case 6:
                return new Vector3(-1, 0, -1);
            case 7:
                return new Vector3(0, 0, -1);
            case 8:
                return new Vector3(1, 0, -1);
            default:
                return new Vector3(0, 0, 0);
        }
    }
}
public class ArenaBlock
{
    public int Pos;
    public GameObject TheObject;
}
