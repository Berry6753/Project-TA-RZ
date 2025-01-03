public class PC_Common_Stat : Stat
{
    public int Id { get;}
    public string Type { get; set; }
    public float Atk_Power { get; set; }
    public float HP { get; set; }
    public float Move_Speed { get; set; }
    public int Resource_Own_Num { get; set; }
    public float Stamina_Gain { get; set; }
    public float Drain_Stamina { get; set; }
    public float Dash_Stamina { get; set; }
    public float Drain_MaxRange { get; set; }
    public float Range_Speed { get; set; }
    public float Pull_Speed { get; set; }
    public float PassiveAtk_Power { get; set; }
    public float Damaged_Stiff_T { get; set; }
    public float Damaged_KnockBack_T { get; set; }

    public PC_Common_Stat()
        : this(101, "PC_Type1", 20f, 100f, 6f, 50, 60f, 20f, 35f,5,2,1,10,0.5f,0.7f)
    {
    }

    public PC_Common_Stat(int id, string type, float atk_Power, float hp, float move_Speed, int resource_Own_Num, float stamina_Gain, float drain_Stamina, float dash_Stamina, float drain_MaxRange, float range_Speed, float pull_Speed, float passiveAtk_Power, float damaged_Stiff_T, float damaged_KnockBack_T)
    {
        Id = id;
        Type = type;
        Atk_Power = atk_Power;
        HP = hp;
        Move_Speed = move_Speed;
        Resource_Own_Num = resource_Own_Num;
        Stamina_Gain = stamina_Gain;
        Drain_Stamina = drain_Stamina;
        Dash_Stamina = dash_Stamina;
        Drain_MaxRange = drain_MaxRange;
        Range_Speed = range_Speed;
        Pull_Speed = pull_Speed;
        PassiveAtk_Power = passiveAtk_Power;
        Damaged_Stiff_T = damaged_Stiff_T;
        Damaged_KnockBack_T = damaged_KnockBack_T;
    }

    public override Stat DeepCopy()
    {
        return new PC_Common_Stat(Id, Type, Atk_Power, HP, Move_Speed, Resource_Own_Num, Stamina_Gain, Drain_Stamina, Dash_Stamina, Drain_MaxRange, Range_Speed, Pull_Speed, PassiveAtk_Power, Damaged_Stiff_T, Damaged_KnockBack_T);
    }

    public override string ToString()
    {
        return $"ID: {Id}, Type: {Type}, Attack Power: {Atk_Power}, HP: {HP}, Move Speed: {Move_Speed}, Resource Own Num: {Resource_Own_Num}, Stamina Gain: {Stamina_Gain}, Drain Stamina: {Drain_Stamina}, Dash Stamina: {Dash_Stamina}, Drain MaxRange: {Drain_MaxRange}, Range Speed: {Range_Speed}, Pull Speed: {Pull_Speed}";
    }
}
