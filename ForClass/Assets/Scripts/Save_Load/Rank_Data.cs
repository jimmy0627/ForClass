using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Rank_Data
{
    public List<RankDataEntity> rankDataEntities=new List<RankDataEntity>();
}
[Serializable]
public class RankDataEntity
{
    public string playerName;
    public int score;
}
