//using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
public class StarWarsCharacterModel
{
    [required]

    public string Name { get; set; }

    public string Character { get; set; }

    public string NumberOfTimes { get; set; }

    public StarWarsCharacterModel() {}
}
