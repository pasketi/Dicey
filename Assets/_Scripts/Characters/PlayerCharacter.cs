using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : BaseCharacter {

    public override void CreateCharacter(RaceID race)
    {
        _characterName = "Lost Vagabond";

        //Ability Scores
        int[] stats = { -1, -1, -1, -1, -1, -1 };
        int[] values = { 16, 14, 13, 12, 11, 10 };
        int tempNum = 0;
        int roundKill = 0;
        int trained1 = -1, trained2 = -1, trained3 = -1;

        for (int i = 0; i < 6;)
        {
            tempNum = Random.Range(0, 6);
            if (System.Array.Exists(stats, stat => stat == tempNum) == false)
            {
                stats[i] = tempNum;
                i++;
            }

            roundKill++;
            if (roundKill >= 500)
            {
                Debug.LogError("BAD RNG, KILLED");
                break;
            }

        }

        for (int i = 0; i < 6; i++)
        {
            SetAbilityScore((AbilityID)stats[i], values[i]);
        }

        for (int i = 0; i < 3;)
        {
            switch (i)
            {
                case 0:
                    trained1 = Random.Range(1, 17);
                    i++;
                    break;
                case 1:
                    trained2 = Random.Range(1, 17);
                    if (trained2 == trained1)
                        trained2 = -1;
                    else
                        i++;
                    break;
                case 2:
                    trained3 = Random.Range(1, 17);
                    if (trained3 == trained1 || trained3 == trained2)
                        trained3 = -1;
                    else
                        i++;
                    break;
            }
        }

        _trainedSkills[trained1] = true;
        _trainedSkills[trained2] = true;
        _trainedSkills[trained3] = true;
        _trainedSkills[0] = true;

        base.CreateCharacter(race);
    }
}
