using System;

[Serializable] // ����ȭ

public class Data
{
    // ó�� �÷����ϴ����� ���� �ִϸ��̼� ���� ȿ��
    public bool isFirstPlay = true;
    public int CurrentStoryNumber = 0;
    public int maxHp = 100;
    public int nowHp;
    public int atkDmg = 10;
    // public float atkSpeed { get; set; }
    public float moveSpeed = 4.5f;
    // public float atkRange { get; set; }
    //public float fieldOfVision { get; set; }
}
public class StoryTextData {
    public string[] StoryText = new string[100];
    public StoryTextData() {
        StoryText[0] = "......";
        StoryText[1] = "You are here again.";
        StoryText[2] = "Did you find your Name \nthis time?";
        StoryText[3] = "What is Your Name...";
        StoryText[4] = "No Name...";
        StoryText[5] = "";
        StoryText[6] = "";
        StoryText[7] = "";
        StoryText[8] = "";
        StoryText[9] = "";
        StoryText[10] = "";
        StoryText[11] = "";
        StoryText[12] = "";
        StoryText[13] = "";
        StoryText[14] = "";
        StoryText[15] = "";
    } 
}