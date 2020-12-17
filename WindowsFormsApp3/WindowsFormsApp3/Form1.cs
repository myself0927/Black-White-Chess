using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        Chess[] chesses = new Chess[64];
        Bitmap BackGroundBmp = new Bitmap(Application.StartupPath + "\\GamePictures\\BackGround.bmp");
        bool player = true;//默认player1开始，player2为fasle
        bool start = false;//开局指示器
        bool DEBUG = false;//DEBUG指示器
        int black , white;//黑白棋数量
        bool flag9 = true;//黑棋可下状态
        bool flag10 = true;//白棋可下状态
        System.Media.SoundPlayer bgm = new System.Media.SoundPlayer();//游戏背景音乐
        System.Media.SoundPlayer bgm2 = new System.Media.SoundPlayer();//DEBUG模式bgm
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(BackGroundBmp, 0, 0, 500, 500);
            int x = 50;
            int y = 50;
            Pen pen = new Pen(Color.Black, 2);
            for (int i = 0; i < 9; i++)
            {
                Point point1 = new Point(x, y);
                Point point2 = new Point(x + 400, y);
                g.DrawLine(pen, point1, point2);
                y = y + 50;
            }
            x = 50;
            y = 50;
            for (int i = 0; i < 9; i++)
            {
                Point point1 = new Point(x, y);
                Point point2 = new Point(x, y + 400);
                g.DrawLine(pen, point1, point2);
                x = x + 50;
            }
            label5.Text = "黑白棋";
            Application.DoEvents();
            if (start == true&&DEBUG==false)
            {
                for (int i = 0; i < 64; i++)
                {
                    if (chesses[i].GetColor() != null)
                    {
                        if (chesses[i].GetColor() == "Black")
                        {
                            Bitmap BlackBmp = new Bitmap(Application.StartupPath + "\\GamePictures\\Black5.png");
                            BlackBmp.MakeTransparent(Color.Black);
                            g.DrawImage(BlackBmp, chesses[i].GetX()+2, chesses[i].GetY()+2, 46, 46);
                        }
                        else
                        {
                            Bitmap WhiteBmp = new Bitmap(Application.StartupPath + "\\GamePictures\\White5.png");
                            WhiteBmp.MakeTransparent(Color.Black);
                            g.DrawImage(WhiteBmp, chesses[i].GetX()+2, chesses[i].GetY()+2, 46, 46);
                        }
                    }
                }
                black = 0; white = 0;
                for (int k = 0; k < 64; k++)
                {
                    if (chesses[k].GetColor() == "Black")
                    {

                        black++;
                    }
                    else if (chesses[k].GetColor() == "White")
                    {
                        white++;
                    }
                }
                label2.Text = "黑色棋子数:" + black;
                label3.Text = "白色棋子数:" + white;
                int sum = black + white;
                label4.Text = "总棋子数:" + sum;
            }
            else if (DEBUG == true)
            {
                for (int i = 0; i < 64; i++)
                {
                    if (chesses[i].GetColor() != null)
                    {
                        if (chesses[i].GetColor() == "Black")
                        {
                            Bitmap BlackBmp = new Bitmap(Application.StartupPath + "\\GamePictures\\Black5.png");
                            BlackBmp.MakeTransparent(Color.Black);
                            g.DrawImage(BlackBmp, chesses[i].GetX() + 2, chesses[i].GetY() + 2, 46, 46);
                        }
                        else
                        {
                            Bitmap WhiteBmp = new Bitmap(Application.StartupPath + "\\GamePictures\\White5.png");
                            WhiteBmp.MakeTransparent(Color.Black);
                            g.DrawImage(WhiteBmp, chesses[i].GetX() + 2, chesses[i].GetY() + 2, 46, 46);
                        }
                    }
                }
                int black = 0, white = 0;
                for (int k = 0; k < 64; k++)
                {
                    if (chesses[k].GetColor() == "Black")
                    {
                        black++;
                    }
                    else if (chesses[k].GetColor() == "White")
                    {
                        white++;
                    }
                }
                label2.Text = "黑色棋子数:" + black;
                label3.Text = "白色棋子数:" + white;
                int sum = black + white;
                label4.Text = "总棋子数:" + sum;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 50;
            int y = 50;
            for (int i = 0; i < 64; i++)
            {
                chesses[i] = new Chess(x, y, null);
                x = x + 50;
                if (x > 400)
                {
                    y = y + 50;
                    x = 50;
                }
            }
            chesses[27].SetColor("Black");
            chesses[28].SetColor("White");
            chesses[35].SetColor("White");
            chesses[36].SetColor("Black");
        }
        private bool CalculateLocation()//判断是否有可下的地方，没有，本回合被迫弃权
        {
            int i;
            bool flag = false;//横
            bool flag2 = false;
            bool flag3 = false;//竖
            bool flag4 = false;
            bool flag5 = false;//左上-右下
            bool flag6 = false;
            bool flag7 = false;//左下-右上
            bool flag8 = false;
            string us, enemy;
            if (player == true)
            {
                us = "Black";
                enemy = "White";
            }
            else
            {
                us = "White";
                enemy = "Black";
            }
            for (i = 0; i < 64; i++)
            {
                if (chesses[i].GetColor() != null) { }
                else
                {
                    chesses[i].SetColor(us);//假设该点为自己下的棋子
                    int num1 = (int)Math.Floor((double)(i / 8)) * 8;//获取当前所在行的头一个格位置编号
                    //接下来判断[num1,i)的情况                   
                    int num = num1;//临时存储num1
                    for (int j = num; j < i; j++)
                    {
                        if (chesses[j].GetColor() == us)//找到了自己的棋子，接下来判断可不可以吃掉两个棋子之间的对方棋子
                        {
                            int k = j + 1;
                            bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                            for (; k < i; k++)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                {
                                    if (k == i - 1)
                                    {
                                        flag = false;
                                        break;
                                    }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                        {
                                            j = k;//存储该地方为开始点
                                        }//若该位置是自己棋子，将该值赋值给j
                                        else
                                        {
                                          
                                            for (; chesses[k].GetColor() != us && k < i; k++) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j >= i - 1)
                                {
                                    flag = false;
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                            break;//找到一个就可以，判断后直接退出
                        }
                    }
                    //接下来判断(i,num1+7]的情况                  
                    num = num1 + 7;
                    for (int j = num; j > i; j--)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j - 1;
                            bool enter = false;
                            for (; k > i; k--)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)
                                {
                                    if (k == i + 1)
                                    {
                                        flag2 = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)
                                        {
                                            j = k;
                                        }
                                        else
                                        {
                                           
                                            for (; chesses[k].GetColor() != us && k > i; k--) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j <= i - 1)
                                {
                                    flag2 = false;
                                }
                                else
                                {
                                    flag2 = true;
                                }
                            }
                            break;
                        }
                    }
                    //接下来判断竖方向
                    int num2 = i % 8;//获取当前所在列的头一个格位置编号
                    //接下来判断[num2,i)的情况
                    num = num2;
                    for (int j = num; j < i; j = j + 8)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j + 8;
                            bool enter = false;
                            for (; k < i; k = k + 8)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                {
                                    if (k == i - 8)
                                    {
                                        flag3 = false;
                                        break;
                                    }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                        {
                                            j = k;//存储该地方为开始点
                                        }//若该位置是自己棋子，将该值赋值给j
                                        else
                                        {
                                          
                                             for (; chesses[k].GetColor() != us && k < i; k=k+8) ;
                                             j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j >= i - 8)
                                {
                                    flag3 = false;
                                }
                                else 
                                {
                                    flag3 = true;
                                }
                            }
                            break;
                        }
                    }
                    //接下来判断(i,num2+7*8]的情况
                    num = num2 + 7 * 8;
                    for (int j = num; j > i; j = j - 8)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j - 8;
                            bool enter = false;
                            for (; k > i; k = k - 8)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)
                                {
                                    if (k == i + 8)
                                    {
                                        flag4 = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)
                                        {
                                            j = k;
                                        }
                                        else
                                        {
                                            
                                            for (; chesses[k].GetColor() != us && k > i; k=k-8) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j <= i + 8)
                                {
                                    flag4 = false;
                                }
                                else
                                    flag4 = true;
                            }
                            break;
                        }
                    }
                    //接下来判断左上-右下斜线的情况
                    int num3;
                    for (num3 = i; chesses[num3].GetX() > 50 && chesses[num3].GetY() > 50; num3 = num3 - 9) { }
                    num = num3;
                    for (int j = num; j < i; j = j + 9)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j + 9;
                            bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                            for (; k < i; k = k + 9)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                {
                                    if (k == i - 9)
                                    {
                                        flag5 = false;
                                        break;
                                    }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                        {
                                            j = k;//存储该地方为开始点
                                        }//若该位置是自己棋子，将该值赋值给j
                                        else
                                        {
                                            
                                            for (; chesses[k].GetColor() != us && k < i; k=k+9) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j >= i - 9)
                                {
                                    flag5 = false;
                                }
                                else
                                    flag5 = true;

                            }
                            break;//找到一个就可以，判断后直接退出
                        }
                    }
                    for (num3 = i; chesses[num3].GetX() < 400 && chesses[num3].GetY() < 400; num3 = num3 + 9) { }
                    num = num3;
                    for (int j = num; j > i; j = j - 9)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j - 9;
                            bool enter = false;
                            for (; k > i; k = k - 9)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)
                                {
                                    if (k == i + 9)
                                    {
                                        flag6 = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)
                                        {
                                            j = k;
                                        }
                                        else
                                        {
                                            
                                            for (; chesses[k].GetColor() != us && k > i; k=k-9) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j <= i + 9)
                                    flag6 = false;
                                else
                                    flag6 = true;
                            }
                            break;
                        }
                    }
                    //接下来判断右上-左下斜线的情况
                    int num4;
                    for (num4 = i; chesses[num4].GetX() < 400 && chesses[num4].GetY() > 50; num4 = num4 - 7) { }
                    num = num4;
                    for (int j = num; j < i; j = j + 7)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j + 7;
                            bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                            for (; k < i; k = k + 7)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                {
                                    if (k == i - 7)
                                    {
                                        flag7 = false;
                                        break;
                                    }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                        {
                                            j = k;//存储该地方为开始点
                                        }//若该位置是自己棋子，将该值赋值给j
                                        else
                                        {
                                           
                                            for (; chesses[k].GetColor() != us && k < i; k=k+7) ;
                                            j = k;
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j >= i - 7)
                                    flag7 = false;
                                else
                                    flag7 = true;
                            }
                            break;//找到一个就可以，判断后直接退出
                        }
                    }
                    for (num4 = i; chesses[num4].GetX() > 50 && chesses[num4].GetY() < 400; num4 = num4 + 7) { }
                    num = num4;
                    for (int j = num; j > i; j = j - 9)
                    {
                        if (chesses[j].GetColor() == us)
                        {
                            int k = j - 7;
                            bool enter = false;
                            for (; k > i; k = k - 7)
                            {
                                enter = true;
                                if (chesses[k].GetColor() != enemy)
                                {
                                    if (k == i + 7)
                                    {
                                        flag8 = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (chesses[k].GetColor() == us)
                                        {
                                            j = k;
                                        }
                                        else
                                        {
                                            if (k - 7 >= 0)
                                            {
                                                
                                                for (; chesses[k].GetColor() != us && k > i; k=k-7) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                            }
                            if (k == i && enter == true)
                            {
                                if (j <= i + 7)
                                    flag8 = false;
                                else
                                    flag8 = true;
                            }
                            break;
                        }
                    }
                    chesses[i].SetColor(null);
                }
                if (flag == true || flag2 == true || flag3 == true || flag4 == true || flag5 == true || flag6 == true || flag7 == true || flag8 == true)
                    break;
            }
            if (i >= 64)
            {
                return false;
            }
            if (flag == true || flag2 == true || flag3 == true || flag4 == true|| flag5 == true || flag6 == true || flag7 == true || flag8 == true)
                return true;
            else
                return false;
        }
        private bool qiquan()
        {
            bool test;//判断对手是否能走棋
            test = CalculateLocation();
            if (test == false)
            {
                if (player == true)
                {
                    MessageBox.Show("本回合您被迫弃权.....", "黑棋弃权");
                    player = !player;//本回合跳过
                }
                else
                {
                    MessageBox.Show("本回合您被迫弃权.....", "白棋弃权");
                    player = !player;//本回合跳过
                }
            }
            return test;

        }
        private void playerChange()
        {
            if (player == true)
                label1.Text = "当前:执黑玩家走棋";
            else
                label1.Text = "当前:执白玩家走棋";
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (start == true && DEBUG == false)
            {
                bool flag = false;//横
                bool flag2 = false;
                bool flag3 = false;//竖
                bool flag4 = false;
                bool flag5 = false;//左上-右下
                bool flag6 = false;
                bool flag7 = false;//左下-右上
                bool flag8 = false;               
                int i;
                for (i = 0; i < 64; i++)
                {
                    if (e.X >= chesses[i].GetX() && e.X < chesses[i].GetX() + 50 && e.Y >= chesses[i].GetY() && e.Y < chesses[i].GetY() + 50)//若点击点在棋盘上
                    {
                        break;
                    }
                }
                //计算点击点在棋盘上的位置
                if (i >= 64 || i < 0)
                {
                    flag = false;
                }//未在指定位置上，无效
                else
                {
                    string us, enemy;
                    if (player == true)
                    {
                        us = "Black";
                        enemy = "White";
                    }
                    else
                    {
                        us = "White";
                        enemy = "Black";
                    }
                    if (chesses[i].GetColor() == "Black" || chesses[i].GetColor() == "White")
                    {
                        flag = false;
                    }//若点击点位于已存在之棋子上，直接无效（初始所有指示器已经为false,故这里不写语句也可以
                    else
                    {
                        //i为当前点击点位置,首先判断横方向;
                        int num1 = (int)Math.Floor((double)(i / 8)) * 8;//获取当前所在行的头一个格位置编号
                        //接下来判断[num1,i)的情况                   
                        int num = num1;//临时存储num1
                        for (int j = num; j < i; j++)
                        {
                            if (chesses[j].GetColor() == us)//找到了自己的棋子，接下来判断可不可以吃掉两个棋子之间的对方棋子
                            {
                                int k = j + 1;
                                bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                                for (; k < i; k++)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                    {
                                        if (k == i - 1)
                                        {
                                            flag = false;
                                            break;
                                        }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                            {
                                                j = k;//存储该地方为开始点
                                            }//若该位置是自己棋子，将该值赋值给j
                                            else
                                            {
                                                for (; chesses[k].GetColor() != us&&k<i; k++) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j >= i - 1)
                                    {
                                        flag = false;
                                    }
                                    else
                                    {
                                        flag = true;
                                        chesses[i].SetColor(us);
                                        for (k = j + 1; k < i; k++)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }

                                }
                                break;//找到一个就可以，判断后直接退出
                            }
                        }
                        //接下来判断(i,num1+7]的情况                  
                        num = num1 + 7;
                        for (int j = num; j > i; j--)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j - 1;
                                bool enter = false;
                                for (; k > i; k--)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)
                                    {
                                        if (k == i + 1)
                                        {
                                            flag2 = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)
                                            {
                                                j = k;
                                            }
                                            else
                                            {
                                                for (; chesses[k].GetColor() != us&&k>i; k--) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j <= i + 1)
                                    {
                                        flag2 = false;
                                    }
                                    else
                                    {
                                        flag2 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j - 1; k > i; k--)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        //接下来判断竖方向
                        int num2 = i % 8;//获取当前所在列的头一个格位置编号
                        //接下来判断[num2,i)的情况
                        num = num2;
                        for (int j = num; j < i; j = j + 8)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j + 8;
                                bool enter = false;
                                for (; k < i; k = k + 8)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                    {
                                        if (k == i - 8)
                                        {
                                            flag3 = false;
                                            break;
                                        }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                            {
                                                j = k;//存储该地方为开始点
                                            }//若该位置是自己棋子，将该值赋值给j
                                            else
                                            {                                               
                                                for (; chesses[k].GetColor() != us&&k<i; k=k+8) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j >= i - 8)
                                    {
                                        flag3 = false;
                                    }
                                    else
                                    {
                                        flag3 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j + 8; k < i; k = k + 8)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        //接下来判断(i,num2+7*8]的情况
                        num = num2 + 7 * 8;
                        for (int j = num; j > i; j = j - 8)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j - 8;
                                bool enter = false;
                                for (; k > i; k = k - 8)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)
                                    {
                                        if (k == i + 8)
                                        {
                                            flag4 = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)
                                            {
                                                j = k;
                                            }
                                            else
                                            {                                                
                                                for (; chesses[k].GetColor() != us && k > i; k=k-8) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j <= i + 8)
                                    {
                                        flag4 = false;
                                    }
                                    else
                                    {
                                        flag4 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j - 8; k > i; k = k - 8)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        //接下来判断左上-右下斜线的情况
                        int num3;
                        for (num3 = i; chesses[num3].GetX() > 50 && chesses[num3].GetY() > 50; num3 = num3 - 9) { }
                        num = num3;
                        for (int j = num; j < i; j = j + 9)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j + 9;
                                bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                                for (; k < i; k = k + 9)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                    {
                                        if (k == i - 9)
                                        {
                                            flag5 = false;
                                            break;
                                        }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                            {
                                                j = k;//存储该地方为开始点
                                            }//若该位置是自己棋子，将该值赋值给j
                                            else
                                            {
                                               
                                                for (; chesses[k].GetColor() != us && k < i; k=k+9) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j >= i - 9)
                                    {
                                        flag5 = false;
                                    }
                                    else
                                    {
                                        flag5 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j + 9; k < i; k = k + 9)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }

                                }
                                break;//找到一个就可以，判断后直接退出
                            }
                        }
                        for (num3 = i; chesses[num3].GetX() < 400 && chesses[num3].GetY() < 400; num3 = num3 + 9) { }
                        num = num3;
                        for (int j = num; j > i; j = j - 9)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j - 9;
                                bool enter = false;
                                for (; k > i; k = k - 9)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)
                                    {
                                        if (k == i + 9)
                                        {
                                            flag6 = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)
                                            {
                                                j = k;
                                            }
                                            else
                                            {
                                                
                                                for (; chesses[k].GetColor() != us && k > i; k=k-9) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j <= i + 9)
                                    {
                                        flag6 = false;
                                    }
                                    else
                                    {
                                        flag6 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j - 9; k > i; k = k - 9)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        //接下来判断右上-左下斜线的情况
                        int num4;
                        for (num4 = i; chesses[num4].GetX() < 400 && chesses[num4].GetY() > 50; num4 = num4 - 7) { }
                        num = num4;
                        for (int j = num; j < i; j = j + 7)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j + 7;
                                bool enter = false;//判断是否能够进入循环体(即判断k是否已经等于i;等于相当于j==i-1;不合题意)
                                for (; k < i; k = k + 7)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)//发现之间有非对方棋子
                                    {
                                        if (k == i - 7)
                                        {
                                            flag7 = false;
                                            break;
                                        }//若该位置已经在所下棋子旁边，直接宣布该位置无效
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)//发现该地区是自己的棋子
                                            {
                                                j = k;//存储该地方为开始点
                                            }//若该位置是自己棋子，将该值赋值给j
                                            else
                                            {
                                                for (; chesses[k].GetColor() != us && k < i; k=k+7) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j >= i - 7)
                                    {
                                        flag7 = false;
                                    }
                                    else
                                    {
                                        flag7 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j + 7; k < i; k = k + 7)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }

                                }
                                break;//找到一个就可以，判断后直接退出
                            }
                        }
                        for (num4 = i; chesses[num4].GetX() > 50 && chesses[num4].GetY() < 400; num4 = num4 + 7) { }
                        num = num4;
                        for (int j = num; j > i; j = j - 7)
                        {
                            if (chesses[j].GetColor() == us)
                            {
                                int k = j - 7;
                                bool enter = false;
                                for (; k > i; k = k - 7)
                                {
                                    enter = true;
                                    if (chesses[k].GetColor() != enemy)
                                    {
                                        if (k == i + 7)
                                        {
                                            flag8 = false;
                                            break;
                                        }
                                        else
                                        {
                                            if (chesses[k].GetColor() == us)
                                            {
                                                j = k;
                                            }
                                            else
                                            {
                                               
                                                for (; chesses[k].GetColor() != us && k > i; k=k-7) ;
                                                j = k;
                                            }
                                        }
                                    }
                                }
                                if (k == i && enter == true)
                                {
                                    if (j <= i + 7)
                                    {
                                        flag8 = false;
                                    }
                                    else
                                    {
                                        flag8 = true;
                                        chesses[i].SetColor(us);
                                        for (k = j - 7; k > i; k = k - 7)
                                        {
                                            chesses[k].SetColor(us);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }

                }
                if (flag == true || flag2 == true || flag3 == true || flag4 == true || flag5 == true || flag6 == true || flag7 == true || flag8 == true)
                {
                    /*System.Media.SoundPlayer sp = new SoundPlayer();
                    sp.SoundLocation = @Application.StartupPath + "\\GameSounds\\MOVE.WAV";
                    sp.Play();*/
                    player = !player;                   
                    Invalidate();
                    EndGame();
                    if (start == true)
                    {
                        flag9=qiquan();
                        player = !player;
                        flag10 = qiquan();
                        if(flag9==false&&flag10==false)
                        {
                            EndGame();
                        }
                        else if(flag9 == true && flag10 == true)
                        {
                            player = !player;
                            playerChange();
                        }
                        else
                        {
                            playerChange();
                        }
                    }
                    Application.DoEvents();
                }
            }
            if (DEBUG == true)
            {
                int i;
                bool flag10 = false;
                for (i = 0; i < 64; i++)
                {
                    if (e.X >= chesses[i].GetX() && e.X < chesses[i].GetX() + 50 && e.Y >= chesses[i].GetY() && e.Y < chesses[i].GetY() + 50)//若点击点在棋盘上
                    {
                        break;
                    }
                }
                //计算点击点在棋盘上的位置
                if (i >= 64 || i < 0)
                {
                    flag10 = false;
                }//未在指定位置上，无效
                else
                {
                    if (player == true)
                    {
                        chesses[i].SetColor("Black");
                    }
                    else
                    {
                        chesses[i].SetColor("White");
                    }
                }
                /*System.Media.SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = @Application.StartupPath + "\\GameSounds\\MOVE.WAV";
                sp.Play();*/
                Invalidate();
                Application.DoEvents();
            }
        }
        private void EndGame()
        {
            int nullNo=0;
            for (int i = 0; i < 64; i++)
            {
                if (chesses[i].GetColor() == null)
                {
                    nullNo++;
                }
            }
            black = 0; white = 0;
            for (int k = 0; k < 64; k++)
            {
                if (chesses[k].GetColor() == "Black")
                {

                    black++;
                }
                else if (chesses[k].GetColor() == "White")
                {
                    white++;
                }
            }
            if (nullNo == 0 || black == 0 || white == 0||(flag9==false&&flag10==false))
            {
                System.Media.SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = @Application.StartupPath + "\\GameSounds\\游戏结束.WAV";
                sp.Play();
                if (black > white)
                {

                    MessageBox.Show("黑棋获得了胜利", "黑棋胜");
                }
                else if (white > black)
                {
                    MessageBox.Show("白棋获得了胜利", "白棋胜");
                }
                else
                {
                    MessageBox.Show("平局！", "平局");
                }
                start = false;
                Start.Text = "再来一局";
                player = true;
                Application.DoEvents();
            }
        }
        
        private void Start_Click(object sender, EventArgs e)
        {
            if (DEBUG == false)
            {
                start = true;
                player = true;
                flag9 = flag10 = true;
                Start.Text = "开始游戏";
                label1.Text = "当前:执黑玩家走棋";
                Form1_Load(sender, e);
                Invalidate();
                bgm.SoundLocation = @Application.StartupPath+"\\GameSounds\\高山流水.WAV";
                bgm.Load();
                bgm.PlayLooping();               
            }
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            //此为debug模式，可人为介入该游戏。d但这不是外挂！！！！！！！
            DEBUG = !DEBUG;
            
            bgm2.SoundLocation = @Application.StartupPath + "\\GameSounds\\DEBUGMODE.WAV";
            bgm2.Load();
            if (DEBUG == true)
            {
                label5.Visible = false;
                label6.Visible = true;
                blackbuttom.Visible = true;
                WhiteButtom.Visible = true;
                StoreExit.Visible = true;
                bgm2.PlayLooping();
                Application.DoEvents();
                player = true;
                for (int i = 0; i < 64; i++)
                {
                    chesses[i].SetColor(null);
                }
                Debug.Text = "close";
            }
            else
            {
                label5.Visible =true;
                label6.Visible = false;
                blackbuttom.Visible = false;
                WhiteButtom.Visible = false;
                StoreExit.Visible = false;
                Debug.Visible = false;
                bgm2.Stop();
                bgm.PlayLooping();
                Application.DoEvents();
                Form1_Load(sender,e);
                playerChange();
                Debug.Text = "DebugMode";
            }
            Invalidate();
            Application.DoEvents();
        }

        private void blackbuttom_Click(object sender, EventArgs e)
        {
            if (DEBUG == true)
            {
                player = true;
                playerChange();
                Application.DoEvents();
            }
        }
        private void WhiteButtom_Click(object sender, EventArgs e)
        {
            if (DEBUG == true)
            {
                player = false;
                playerChange();
                Application.DoEvents();
            }
        }

        private void StoreExit_Click(object sender, EventArgs e)
        {
            DEBUG = false;
            start = true;
            label5.Visible = true;
            label6.Visible = false;
            blackbuttom.Visible = false;
            WhiteButtom.Visible = false;
            StoreExit.Visible = false;
            Debug.Visible = false;
            bgm2.Stop();
            bgm.PlayLooping();
            Application.DoEvents();
            Debug.Text = "open DEBUG模式";
            playerChange();
            Invalidate();
            Application.DoEvents();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12&&DEBUG==false)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要显示开发者模式?", "开发者模式", messButton);
                if (dr == DialogResult.OK)
                {
                    Debug.Visible = true;
                    Application.DoEvents();
                }
                else
                {
                    Debug.Visible = false;
                    Application.DoEvents();
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  黑白棋\nversion:0.5.3.5(Beta3)","关于游戏");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string s = System.IO.File.ReadAllText(@Application.StartupPath+ "\\UpdateLog\\UpdateLog.txt");
            MessageBox.Show(s, "更新日志");
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
