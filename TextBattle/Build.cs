public class Build
{


public bool SummonerBuild {get; set;}

public bool WarriorBuild {get; set;}

public bool SamuraiBuild {get; set;}
public bool DefaultBuild {get; set;}
public string Name {get;}
public Build(string build)
{


    switch(build)
    {
        case "1":
                SummonerBuild = true;
                Name = "Summoner";
                break;
            case "2":
                WarriorBuild = true;
                Name = "Warrior";
                break;
            case "3":
                SamuraiBuild = true;
                Name = "Samurai";
                break;
            default:
                DefaultBuild = true;
                Name = "Normal";
                break;
    }

}


}