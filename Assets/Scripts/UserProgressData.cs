using System;
using System.Collections.Generic;

[Serializable]
public class UserProgressData
{
    public string Name = "";
    public int Age = 0;
    public int Weight = 0;
    public Gender Gender = Gender.Male;
    public bool Authorized = false;
    public List<int> RecipesId = new();
}
