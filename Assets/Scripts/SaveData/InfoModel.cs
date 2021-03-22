using System.Collections.Generic;

public class InfolistItem
{
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 走进晨曦
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<List<string>> content { get; set; }
}

public class InfoModel
{
    /// <summary>
    /// 
    /// </summary>
    public List<InfolistItem> infolist { get; set; }
}