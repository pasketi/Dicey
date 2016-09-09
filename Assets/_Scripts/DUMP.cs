
//public class Skill : ScriptableObject
//{
//    string name;
//    string descripiton;
//    List<Effect> effects;
//    List<Target> targets;
//    public int attackTimes;

//    public void Activate(Player player, Player target)
//    {
//        var damage = 0;
//        foreach (var effect in effects)
//        {
//            effect.Init(player);
//            damage += effect.Damage();
//        }

//        target.TakeDamage(damage);
//        //apply damage

//        //apply other things
//    }
//}

//public class Target
//{
//}

//public abstract class Effect
//{
//    public abstract Init(Player player); //Get whatever information you need from player
//    public abstract int Damage();
//}

//public class DiceGroup : Effect
//{
//    public DiceGroup(int numDice, int diceSize) { }

//    public override int Damage()
//    {
//        throw new NotImplementedException();
//    }

//    public override void Init(Player player)
//    {
//        throw new NotImplementedException();
//    }
//}

//public class BaseDamage : DiceGroup
//{
//    public BaseDamage() : base(1, 20)
//    {
//    }
//}

//public class StatModifier : Effect
//{

//}

//public class WeaponModifier : Effect
//{

//}