public class Rootobject
{
    public Medication[] medications { get; set; }
    public Lab[] labs { get; set; }
}

public class Medication
{
    public Aceinhibitor[] aceInhibitors { get; set; }
    public Antianginal[] antianginal { get; set; }
    public Anticoagulant[] anticoagulants { get; set; }
    public Betablocker[] betaBlocker { get; set; }
    public Diuretic[] diuretic { get; set; }
    public Mineral[] mineral { get; set; }
}

public class Aceinhibitor
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Antianginal
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Anticoagulant
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Betablocker
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Diuretic
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Mineral
{
    public string name { get; set; }
    public string strength { get; set; }
    public string dose { get; set; }
    public string route { get; set; }
    public string sig { get; set; }
    public string pillCount { get; set; }
    public string refills { get; set; }
}

public class Lab
{
    public string name { get; set; }
    public string time { get; set; }
    public string location { get; set; }
}
