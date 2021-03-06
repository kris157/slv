﻿using UnityEngine;
using UnityEngine.UI;

public class CurrentSkillLevel : TargetSkillLevel
{
    public InputField percentageField;

    protected int _percentage;

    public override int level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;

            if (_level >= 15)
            {
                _level = 15;
                _percentage = 0;
            }
            else if (level < 1)
            {
                _level = 1;
                _percentage = 0;
            }

            levelField.text = level.ToString();
            percentageField.text = percentage.ToString();
        }
    }

    public int percentage
    {
        get
        {
            return _percentage;
        }

        set
        {
            _percentage = value;

            if (level == 15 || _percentage < 0)
                _percentage = 0;

            else if (_percentage > 99)
                _percentage = 99;

            levelField.text = level.ToString();
            percentageField.text = percentage.ToString();
        }
    }

    public override void EV_EndEdit()
    {
        try
        {
            int level = int.Parse(levelField.text);
            int percentage = int.Parse(percentageField.text);

            this.level = level;
            this.percentage = percentage;
        }

        catch (System.Exception)
        {
            levelField.text = level.ToString();
            percentageField.text = percentage.ToString();
        }

        Controller.instance.Calculate();
    }
}
