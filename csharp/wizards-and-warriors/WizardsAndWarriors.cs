using System;

abstract class Character
{
    private string type;

    protected Character(string characterType)
    {
        type = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {type}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (!target.Vulnerable()) return 6;
        return 10;
    }
}

class Wizard : Character
{
    private bool spellPrepared = false;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared) return 12;
        return 3;
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }
}
